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
    private string downloadFileName = "Church_Plan-PreBeta.zip";

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
        using (WebClient client = new WebClient())
        {
            client.Headers.Add("User-Agent", "C# App");
            string url = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";
            string json = await client.DownloadStringTaskAsync(url);
            JObject release = JObject.Parse(json);
            string downloadUrl = (string)release["assets"][0]["browser_download_url"]; //assuming the zip is the first asset.

            await client.DownloadFileTaskAsync(downloadUrl, downloadFileName);
        }
    }

    private void ExtractAndReplaceFiles()
    {
        //ZipFile.ExtractToDirectory(downloadFileName, "./tempUpdateFolder/", true);

        //replace files from the tempUpdateFolder to the current application folder.
        //use System.IO.File.Move, System.IO.File.Copy, System.IO.File.Delete, System.IO.Directory.Move, and System.IO.Directory.Delete.
        //delete the tempUpdateFolder after the file replacement.
    }

    private void RestartApplication()
    {
        Process.Start(applicationExeName);
        Application.Exit();
    }
}

// In your Form load event, you would call the following.
// GitHubUpdater updater = new GitHubUpdater();
// updater.CheckForUpdates();