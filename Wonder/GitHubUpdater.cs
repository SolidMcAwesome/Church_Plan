using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using Newtonsoft.Json.Linq; // Install Newtonsoft.Json via NuGet
using System.IO.Compression;
using System.Xml.Linq;

public class GitHubUpdater
{
    private string owner = "SolidMcAwesome"; // Replace with your GitHub username
    private string repo = "Church_Plan"; // Replace with your repository name
    private string applicationExeName = "Wonder.exe";
    private string downloadFileName = "new_release.zip";

    public async void CheckForUpdates()
    {
        try
        {
            MessageBox.Show("Checking for Updates.");
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Version latestReleaseVersion = await GetLatestReleaseVersion();

            if (latestReleaseVersion > currentVersion)
            {
                await DownloadLatestRelease();
                ExtractAndReplaceFiles();
                RestartApplication();
            }
            else
            {
                MessageBox.Show("Application is up to date.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error checking for updates: " + ex.Message);
        }
    }

    private async System.Threading.Tasks.Task<Version> GetLatestReleaseVersion()
    {
        using (WebClient client = new WebClient())
        {
            client.Headers.Add("User-Agent", "C# App"); // GitHub requires a User-Agent
            string url = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";
            string json = await client.DownloadStringTaskAsync(url);
            JObject release = JObject.Parse(json);
            string tagName = (string)release["tag_name"];
            Version latestVersion = new Version(tagName.TrimStart('b')); //remove the v from v1.0.0
            return latestVersion;
        }
    }

    private async System.Threading.Tasks.Task DownloadLatestRelease()
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent", "C# App");
                string url = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";
                string json = await client.DownloadStringTaskAsync(url);
                JObject release = JObject.Parse(json);

                if (release["assets"] == null || !release["assets"].HasValues)
                {
                    MessageBox.Show("No assets found in the latest release.");
                    return; // Exit the function.
                }

                string downloadUrl = (string)release["assets"][0]["browser_download_url"];

                if (string.IsNullOrEmpty(downloadUrl))
                {
                    MessageBox.Show("Download URL not found in the release assets.");
                    return;
                }

                await client.DownloadFileTaskAsync(downloadUrl, downloadFileName);
            }
        }
        catch (WebException ex)
        {
            MessageBox.Show($"Web exception during download: {ex.Message}");
        }
        catch (Newtonsoft.Json.JsonReaderException ex)
        {
            MessageBox.Show($"JSON parsing error during download: {ex.Message}");
        }
        catch (IndexOutOfRangeException ex)
        {
            MessageBox.Show($"Index out of range error during asset retrieval: {ex.Message}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error downloading latest release: {ex.Message}");
        }
    }

    private void ExtractAndReplaceFiles()
    {
        string extractPath = "./temp/";
        string appPath = Application.StartupPath;
        string zipPath = downloadFileName;

        if (Directory.Exists(extractPath))
        {
            Directory.Delete(extractPath, true); // Clean up previous temp folder
        }
        Directory.CreateDirectory(extractPath);

        // Using ZipArchive for extraction
        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                // Gets the full path to ensure subdirectories are created
                string destinationFilePath = Path.Combine(extractPath, entry.FullName);

                // Ensure the directory exists for the entry
                string destinationDirectory = Path.GetDirectoryName(destinationFilePath);
                if (!string.IsNullOrEmpty(destinationDirectory) && !Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Only extract files, not directories (directories are created automatically by files)
                if (!string.IsNullOrEmpty(entry.Name)) // entry.Name is empty for directories
                {
                    entry.ExtractToFile(destinationFilePath, true); // 'true' overwrites if file exists
                }
            }
        }

        // 2. Stop the running application (as before)
        StopApplication();

        // 3. Replace the files.
        ReplaceFiles(extractPath, appPath);

        // 4. Clean up.
        Directory.Delete(extractPath, true);
        File.Delete(downloadFileName);
    


        //ZipFile.ExtractToDirectory(downloadFileName, "./tempUpdateFolder/", true);

        //replace files from the tempUpdateFolder to the current application folder.
        //use System.IO.File.Move, System.IO.File.Copy, System.IO.File.Delete, System.IO.Directory.Move, and System.IO.Directory.Delete.
        //delete the tempUpdateFolder after the file replacement.
    }

    private void StopApplication()
    {
        Process currentProcess = Process.GetCurrentProcess();
        Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);

        foreach (Process process in processes)
        {
            if (process.Id != currentProcess.Id)
            {
                process.Kill(); // Forcefully close other instances.
            }
        }
    }
    private void ReplaceFiles(string sourcePath, string destinationPath)
    {
        string[] files = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            string relativePath = file.Substring(sourcePath.Length);
            string destinationFile = Path.Combine(destinationPath, relativePath);

            // Create the destination directory if it doesn't exist.
            string destinationDirectory = Path.GetDirectoryName(destinationFile);
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            File.Copy(file, destinationFile, true); // overwrite existing files.
        }
    }

    private void RestartApplication()
    {
        //Process.Start(applicationExeName);
        //Application.Exit();
    }
}

// In your Form load event, you would call the following.
// GitHubUpdater updater = new GitHubUpdater();
// updater.CheckForUpdates();