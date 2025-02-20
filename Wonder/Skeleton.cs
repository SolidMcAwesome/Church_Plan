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
    public partial class Skeleton : Form
    {
        public Skeleton()
        {
            InitializeComponent();
            
        }
        public Projection projection = new Projection();
        public string[] Selection = { "", "", "", "" };

        private void Skeleton_Load(object sender, EventArgs e)
        {
            Selection[0] = cbxV.Text + ".xml"; // Version
            Selection[1] = cbxBB.Text; // Book
            Selection[2] = cbxBC.Text; // Chapter
            Selection[3] = cbxBV.Text; // Verse

            VerseTextLine1.Text = "";
            rtbPreview.Text = "";
        }
        string BibleReading()
        {
            Bible BB = new Bible();
            Selection[0] = cbxV.Text + ".xml"; // Version
            Selection[1] = cbxBB.Text; // Book
            Selection[2] = cbxBC.Text; // Chapter
            Selection[3] = cbxBV.Text; // Verse

            string reading = BB.getReading(Selection);
            return reading;
        }

        private void btnUpdateVerse_Click(object sender, EventArgs e)
        {
            //VerseTextLine1.Text = BibleReading();
            rtbPreview.Text = BibleReading();
            rtbPreview.SelectAll();
            rtbPreview.SelectionAlignment = HorizontalAlignment.Center;
            projection.updateText(BibleReading());
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            projection.Show();
            projection.WindowState = FormWindowState.Maximized;
        }
    }
}
