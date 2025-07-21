using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.InteropServices; // Still need this for MessageBox.Show
using Newtonsoft.Json.Linq;

namespace Launcher
{
    internal class Program
    {
        // --- Win32 MessageBox P/Invoke Declaration ---
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        // MessageBox Button & Icon Styles (common ones)
        public const uint MB_OK = 0x00000000;
        public const uint MB_OKCANCEL = 0x00000001;
        public const uint MB_ICONERROR = 0x00000010;
        public const uint MB_ICONWARNING = 0x00000030;
        public const uint MB_ICONINFORMATION = 0x00000040;
        public const uint MB_YESNO = 0x00000004;
        public const uint MB_YESNOCANCEL = 0x00000003;
        // You can add more constants from https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-messagebox

        // --- Configuration ---
        private const string GitHubOwner = "SolidMcAwesome";
        private const string GitHubRepo = "Church_Plan";
        private const string MainAppName = "Wonder.exe";
        private const string TempDownloadZip = "update.zip";
        private const string TempExtractFolder = "update_temp";

        [STAThread] // Keep this for any potential COM interop or future UI needs, though not strictly for this MessageBox.
        static async Task Main(string[] args)
        {
            try
            {
                await CheckAndUpdateApplication();
            }
            catch (Exception ex)
            {
                // Replace MessageBox.Show with the Win32 MessageBox call
                MessageBox(IntPtr.Zero, $"An error occurred during the update process: {ex.Message}\n\nLaunching main app anyway...", "Update Error", MB_OK | MB_ICONERROR);
            }
            finally
            {
                LaunchMainApplication();
            }
        }

        // --- All the helper methods (GetCurrentApplicationVersion, GetLatestReleaseVersionFromGitHub,
        //     DownloadLatestReleaseFromGitHub, CloseMainApplicationInstances, ExtractAndReplaceFiles,
        //     LaunchMainApplication) go here, adapted to be static if they were instance methods. ---

        private static Version GetCurrentApplicationVersion()
        {
            string mainAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, MainAppName);
            if (File.Exists(mainAppPath))
            {
                try { return AssemblyName.GetAssemblyName(mainAppPath).Version; }
                catch { return new Version("0.0.0.0"); }
            }
            return new Version("0.0.0.0");
        }

        private static async Task CheckAndUpdateApplication()
        {
            Version currentAppVersion = GetCurrentApplicationVersion();
            Version latestReleaseVersion = await GetLatestReleaseVersionFromGitHub();

            if (latestReleaseVersion > currentAppVersion)
            {
                // Replace MessageBox.Show with the Win32 MessageBox call
                MessageBox(IntPtr.Zero, $"New version ({latestReleaseVersion}) available! Updating...", "Update Available", MB_OK | MB_ICONINFORMATION);
                await DownloadLatestReleaseFromGitHub();
                CloseMainApplicationInstances();
                ExtractAndReplaceFiles();
                // Replace MessageBox.Show with the Win32 MessageBox call
                MessageBox(IntPtr.Zero, "Update complete!", "Success", MB_OK | MB_ICONINFORMATION);
            }
            else
            {
                Console.WriteLine("Application is up to date."); // For debug, if form is hidden
            }
        }

        // ... (Include your GetLatestReleaseVersionFromGitHub, DownloadLatestReleaseFromGitHub,
        //          CloseMainApplicationInstances, ExtractAndReplaceFiles, and LaunchMainApplication methods here.
        //          Make sure they are static.)

        private static async Task<Version> GetLatestReleaseVersionFromGitHub()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "C# MyApp Updater");
                    string url = $"https://api.github.com/repos/{GitHubOwner}/{GitHubRepo}/releases/latest";
                    string json = await client.DownloadStringTaskAsync(url);

                    if (string.IsNullOrEmpty(json))
                    {
                        throw new Exception("Empty response from GitHub API.");
                    }

                    JObject release = JObject.Parse(json);
                    string tagName = (string)release["tag_name"];

                    if (string.IsNullOrEmpty(tagName))
                    {
                        throw new Exception("Tag name not found in GitHub API response.");
                    }

                    return new Version(tagName.TrimStart('v'));
                }
            }
            catch (WebException ex)
            {
                throw new Exception($"Network error checking for updates: {ex.Message}", ex);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                throw new Exception($"JSON parsing error from GitHub API: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get latest release version from GitHub: {ex.Message}", ex);
            }
        }

        private static async Task DownloadLatestReleaseFromGitHub()
        {
            string tempDownloadPath = Path.Combine(Path.GetTempPath(), TempDownloadZip);

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "C# MyApp Updater");
                    string url = $"https://api.github.com/repos/{GitHubOwner}/{GitHubRepo}/releases/latest";
                    string json = await client.DownloadStringTaskAsync(url);
                    JObject release = JObject.Parse(json);

                    JArray assets = (JArray)release["assets"];
                    if (assets == null || assets.Count == 0)
                    {
                        throw new Exception("No assets found in the latest GitHub release.");
                    }

                    string downloadUrl = (string)assets[0]["browser_download_url"];

                    if (string.IsNullOrEmpty(downloadUrl))
                    {
                        throw new Exception("Download URL not found for the asset.");
                    }

                    if (File.Exists(tempDownloadPath))
                    {
                        File.Delete(tempDownloadPath);
                    }

                    await client.DownloadFileTaskAsync(downloadUrl, tempDownloadPath);

                    FileInfo downloadedFile = new FileInfo(tempDownloadPath);
                    if (downloadedFile.Length == 0)
                    {
                        File.Delete(tempDownloadPath);
                        throw new Exception("Downloaded update ZIP file is empty.");
                    }
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(tempDownloadPath)) File.Delete(tempDownloadPath);
                throw new Exception($"Failed to download latest release: {ex.Message}", ex);
            }
        }

        private static void CloseMainApplicationInstances()
        {
            Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(MainAppName));

            foreach (Process process in processes)
            {
                try
                {
                    if (process.Id != Process.GetCurrentProcess().Id)
                    {
                        process.Kill();
                        process.WaitForExit(5000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not terminate process {process.ProcessName} (ID: {process.Id}): {ex.Message}");
                }
            }
        }

        private static void ExtractAndReplaceFiles()
        {
            string tempDownloadPath = Path.Combine(Path.GetTempPath(), TempDownloadZip);
            string tempExtractPath = Path.Combine(Path.GetTempPath(), TempExtractFolder);
            string appInstallPath = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                if (Directory.Exists(tempExtractPath))
                {
                    Directory.Delete(tempExtractPath, true);
                }
                Directory.CreateDirectory(tempExtractPath);

                ZipFile.ExtractToDirectory(tempDownloadPath, tempExtractPath, true);

                string[] files = Directory.GetFiles(tempExtractPath, "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    string relativePath = file.Substring(tempExtractPath.Length + 1);
                    string destinationFile = Path.Combine(appInstallPath, relativePath);

                    string destinationDirectory = Path.GetDirectoryName(destinationFile);
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }

                    File.Copy(file, destinationFile, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"File operation error during update: {ex.Message}", ex);
            }
            finally
            {
                if (Directory.Exists(tempExtractPath)) Directory.Delete(tempExtractPath, true);
                if (File.Exists(tempDownloadPath)) File.Delete(tempDownloadPath);
            }
        }

        private static void LaunchMainApplication()
        {
            string mainAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, MainAppName);
            if (File.Exists(mainAppPath))
            {
                Process.Start(mainAppPath);
            }
            else
            {
                // Replace MessageBox.Show with the Win32 MessageBox call
                MessageBox(IntPtr.Zero, $"Error: Main application '{MainAppName}' not found at '{mainAppPath}'.", "Launch Error", MB_OK | MB_ICONERROR);
            }
        }
    }
}