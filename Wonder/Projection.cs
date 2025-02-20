using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wonder
{
    public partial class Projection : Form
    {
        public Projection()
        {
            InitializeComponent();
        }

        private void Projection_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[1].WorkingArea.Location;
            rtbOutput.Text = "";
        }

        public void updateText(string input)
        {
            rtbOutput.Text = input;
            rtbOutput.SelectAll();
            rtbOutput.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
