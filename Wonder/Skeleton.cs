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
        public Projection projection;
        Bible BB;
        public string[] Selection = { "", "", "", "" };

        private void Skeleton_Load(object sender, EventArgs e)
        {
            projection = new Projection();
            BB = new Bible();

            Selection[0] = cbxV.Text + ".xml"; // Version
            Selection[1] = cbxBB.Text; // Book
            Selection[2] = cbxBC.Text; // Chapter
            Selection[3] = cbxBV.Text; // Verse

            rtbPreview.Text = "";
            lbVersesPreview.Items.Clear();
            updateSearch();
        }
        List<string> BibleBooks()
        {
            Selection[0] = cbxV.Text + ".xml"; // Version

            List<string> books = BB.getBibleBooks(Selection);
            return books;
        }
        List<string> BibleChapters()
        {
            Selection[0] = cbxV.Text + ".xml"; // Version
            Selection[1] = cbxBB.Text; // Book

            List<string> chapters = BB.getChapterNumbers(Selection);
            return chapters;
        }
        List<string> BibleChapterReading()
        {
            Selection[0] = cbxV.Text + ".xml"; // Version
            Selection[1] = cbxBB.Text; // Book
            Selection[2] = cbxBC.Text; // Chapter

            List<string> chapterReading = BB.getChapterReading(Selection);
            return chapterReading;
        }
        private void updateSearch()
        {
            List<string> Bible = BibleBooks();
            List<string> Books = BibleChapters();
            List<string> Chapters = BibleChapterReading();

            // Get book names
            cbxBB.Items.Clear();
            foreach (var book in Bible)
            {
                cbxBB.Items.Add(book.ToString());
            }

            // Get chapter numbers
            cbxBC.Items.Clear();
            int chapterNumber = 1;
            foreach (var chapter in Books)
            {
                cbxBC.Items.Add(chapterNumber.ToString());
                chapterNumber++;
            }

            // Get verse numbers
            cbxBV.Items.Clear();
            int verseNumber = 1;
            foreach(var v in Chapters)
            {
                cbxBV.Items.Add(verseNumber.ToString());
                verseNumber++;
            }
        }
        private void updateSearchVerse()
        {
            List<string> Chapters = BibleChapterReading();

            // Get verse numbers
            cbxBV.Items.Clear();
            int verseNumber = 1;
            foreach (var v in Chapters)
            {
                cbxBV.Items.Add(verseNumber.ToString());
                verseNumber++;
            }
            cbxBV.SelectedIndex = 0;
        }
        private void updateSearchChapter()
        {
            List<string> Books = BibleChapters();

            // Get chapter numbers
            cbxBC.Items.Clear();
            int chapterNumber = 1;
            foreach (var chapter in Books)
            {
                cbxBC.Items.Add(chapterNumber.ToString());
                chapterNumber++;
            }
            cbxBC.SelectedIndex = 0;
        }

        string BibleReading()
        {
            Selection[0] = cbxV.Text + ".xml"; // Version
            Selection[1] = cbxBB.Text; // Book
            Selection[2] = cbxBC.Text; // Chapter
            Selection[3] = cbxBV.Text; // Verse

            string reading =  BB.getReading(Selection);
            return reading;
        }
        
        
        
        
        
        
        private void updatePreview(string input)
        {
            input = input.Replace(";", "\n");
            string reading = Selection[1] + " " + Selection[2] + ":" + Selection[3] + "\n\n" + input;
            rtbPreview.Text = reading;
            rtbPreview.SelectAll();
            rtbPreview.SelectionAlignment = HorizontalAlignment.Center;
            AdjustFontSize();

            projection.updateText(reading);
        }
        private void updateLBVerses(List<string> input)
        {
            lbVersesPreview.Items.Clear();
            int vNumber = 1;
            foreach(string v in input) 
            {
                string verse = vNumber.ToString() + ": " + v;
                lbVersesPreview.Items.Add(verse);
                vNumber++;
            }
        }
        private void AdjustFontSize()
        {
            RichTextBox rtb = this.rtbPreview;
            float originalSize = rtb.Font.Size;
            float fontSize = 50;

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

        private void btnUpdateVerse_Click(object sender, EventArgs e)
        {
            updatePreview(BibleReading());
            updateLBVerses(BibleChapterReading());
            updateSearch();
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            projection.Show();
            projection.WindowState = FormWindowState.Maximized;
        }

        private void lbVersesPreview_SelectedIndexChanged(object sender, EventArgs e)
        {
            int vv = lbVersesPreview.SelectedIndex + 1;
            cbxBV.Text = vv.ToString();
            updatePreview(BibleReading());
        }

        private void cbxBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSearchVerse();
        }

        private void cbxBB_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSearchChapter();
        }

        private void checkEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updatePreview(BibleReading());
                updateLBVerses(BibleChapterReading());
                updateSearch();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
