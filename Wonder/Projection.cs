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
            AdjustFontSize();
        }
        private void AdjustFontSize()
        {
            RichTextBox rtb = this.rtbOutput;
            float originalSize = rtb.Font.Size;
            float fontSize = 100;

            if (rtb.Text.Length > 0)
            {
                rtb.Font = new Font(rtb.Font.FontFamily, fontSize);
                SizeF textSize = rtb.GetPreferredSize(new Size(rtb.Width, int.MaxValue));

                int safetyC = 0;
                while ((textSize.Height < rtb.Height) && (safetyC < 10) && (fontSize < originalSize))
                {
                    fontSize += 5f;
                    rtb.Font = new Font(rtb.Font.FontFamily, fontSize);
                    textSize = rtb.GetPreferredSize(new Size(rtb.Width, int.MaxValue));
                    safetyC++;
                }
                safetyC = 0;
                while (textSize.Height > rtb.Height && (safetyC < 10))
                {
                    fontSize -= 5f;
                    if (fontSize < 1) break;
                    rtb.Font = new Font(rtb.Font.FontFamily, fontSize);
                    textSize = rtb.GetPreferredSize(new Size(rtb.Width, int.MaxValue));
                    safetyC++;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
