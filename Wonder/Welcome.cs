using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wonder
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            string version = "Version: " + Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = version;
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            this.Hide();
            Skeleton main = new Skeleton();
            main.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Updater = "Launcher.exe";

            try
            {
                DialogResult confirm = MessageBox.Show(
                    "The application will now close to check for and install updates. Do you want to continue?",
                    "Update Application",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information
                );

                if (confirm == DialogResult.OK)
                {
                    // Get the path to the external launcher executable
                    string launcherPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Updater);

                    if (File.Exists(launcherPath))
                    {
                        Process.Start(launcherPath); // Launch the external updater
                        Application.Exit(); // Close the current main application process
                    }
                    else
                    {
                        MessageBox.Show(
                            $"The update launcher ('{Updater}') was not found. Cannot check for updates.",
                            "Update Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while trying to launch the updater: {ex.Message}",
                    "Update Launch Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
