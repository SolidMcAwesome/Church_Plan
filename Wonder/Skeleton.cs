using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Wonder
{
    public partial class Skeleton : Form
    {
        public Skeleton()
        {
            InitializeComponent();
        }        

        public Projection projection;
        private bool live;

        Bible BB;
        public string[] Selection = { "", "", "", "" };

        Song SL;
        public Dictionary<string, List<string>> SongLibrary;
        public Dictionary<string, List<string>> PlaylistCatelog;

        private void Skeleton_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("hi");

            //projection
            projection = new Projection();
            live = true;

            //bible
            BB = new Bible();

            Selection[0] = cbxV.Text + ".xml"; // Version
            Selection[1] = cbxBB.Text; // Book
            Selection[2] = cbxBC.Text; // Chapter
            Selection[3] = cbxBV.Text; // Verse

            rtbPreview.Text = "";
            lbVersesPreview.Items.Clear();
            updateSearch();

            // songs
            SL = new Song();
            SongLibrary = SL.SongLibrary;
            PlaylistCatelog = SL.Playlists;
            Songs();
        }
        List<string> Bibles()
        {
            List<string> versions = BB.getBibleVersions();
            return versions;
        }
        List<string> BibleBooks()
        {
            Selection[0] = cbxV.Text + ".xml"; // Version

            List<string> books = BB.getBibleBooks(Selection[0]);
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
            List<string> Versions = Bibles();
            List<string> Bible = BibleBooks();
            List<string> Books = BibleChapters();
            List<string> Chapters = BibleChapterReading();

            // Get bible versions
            cbxV.Items.Clear();
            foreach (var version in Versions)
            {
                cbxV.Items.Add(version);
            }

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
            if (!cbxBV.Focused) { cbxBV.SelectedIndex = 0; }
            //if (!cbxBV.Items.Contains(cbxBV.SelectedItem.ToString())) { cbxBV.SelectedItem = "1"; }
            
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
            //if (input.Contains(";") { input = input.Replace(";", "\n"); }
            string reading = Selection[1] + " " + Selection[2] + ":" + Selection[3] + "\n\n" + input + "\n";

            rtbPreview.Text = reading;
            rtbPreview.SelectAll();
            rtbPreview.SelectionAlignment = HorizontalAlignment.Center;
            AdjustFontSize();

            projection.updateText(reading);

        }
        private void updatePreviewS(string input)
        {
            rtbPreview.Text = input;
            rtbPreview.SelectAll();
            rtbPreview.SelectionAlignment = HorizontalAlignment.Center;
            AdjustFontSize();
        }
        private void updateLBVerses(List<string> input)
        {
            lbVersesPreview.Items.Clear();
            int vNumber = 1;
            foreach(string v in input) 
            {
                string verse = "\n" + vNumber.ToString() + ": " + v + "\n";
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
                rtb.Font = new System.Drawing.Font(rtb.Font.FontFamily, fontSize);
                SizeF textSize = rtb.GetPreferredSize(new Size(rtb.Width, int.MaxValue));

                int safetyC = 0;
                while ((textSize.Height < rtb.Height) && (safetyC < 10) && (fontSize < originalSize))
                {
                    fontSize += 5f;
                    rtb.Font = new System.Drawing.Font(rtb.Font.FontFamily, fontSize);
                    textSize = rtb.GetPreferredSize(new Size(rtb.Width, int.MaxValue));
                    safetyC++;
                }
                safetyC = 0;
                while (textSize.Height > rtb.Height && (safetyC < 10))
                {
                    fontSize -= 5f;
                    if (fontSize < 1) break;
                    rtb.Font = new System.Drawing.Font(rtb.Font.FontFamily, fontSize);
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
            if (Application.OpenForms.OfType<Projection>().FirstOrDefault() == null)
            {
                projection.Show();
                projection.WindowState = FormWindowState.Maximized;
                btnProject.FlatStyle = FlatStyle.Flat;
                btnProject.BackColor = System.Drawing.Color.DarkSlateBlue;
            }
            else if (projection.Visible)
            {
                projection.Visible = false;
                btnProject.FlatStyle = FlatStyle.Popup;
                btnProject.BackColor = System.Drawing.Color.Teal;
            }
            else
            {
                projection.Visible = true;
                btnProject.FlatStyle = FlatStyle.Flat;
                btnProject.BackColor = System.Drawing.Color.DarkSlateBlue;
            }
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
            updateLBVerses(BibleChapterReading());
        }

        private void cbxBB_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSearchChapter();
        }

        private void checkEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateSearch();
                updateLBVerses(BibleChapterReading());
                updatePreview(BibleReading());

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Skeleton_FormClosing(object sender, FormClosingEventArgs e)
        {
            projection.Close();
        }

        private void btnCensor_Click(object sender, EventArgs e)
        {
            if (!projection.CensorVisibility())
            {
                projection.Censor();
                btnCensor.FlatStyle = FlatStyle.Flat;
                btnCensor.BackColor = System.Drawing.Color.DarkSlateBlue;
            }
            else
            {
                projection.Censor();
                btnCensor.FlatStyle = FlatStyle.Popup;
                btnCensor.BackColor = System.Drawing.Color.Teal;
            }
        }

        private void btnTitleScreen_Click(object sender, EventArgs e)
        {
            
            if (!projection.TitleVisibility())
            {
                projection.Title();
                btnTitleScreen.FlatStyle = FlatStyle.Flat;
                btnTitleScreen.BackColor = System.Drawing.Color.DarkSlateBlue;
            }
            else
            {
                projection.Title();
                btnTitleScreen.FlatStyle = FlatStyle.Popup;
                btnTitleScreen.BackColor = System.Drawing.Color.Teal;
            }
        }

        private void lbxLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSong(lbxLibrary.SelectedItem.ToString());
        }
        private void ResetLyricsText()
        {
            btnL1.Text = "";
            btnL2.Text = "";
            btnL3.Text = "";
            btnL4.Text = "";
            btnL5.Text = "";
            btnL6.Text = "";
            btnL7.Text = "";
            btnL8.Text = "";
            btnL9.Text = "";
            btnL10.Text = "";
        }


        private void updateSongDisplay(string display)
        {
            if (live)
            {
                updatePreviewS(display);
                projection.updateText(display);
            }
            else
            {
                if (display == rtbPreview.Text)
                {
                    projection.updateText(display);
                }
                else
                {
                    updatePreviewS(display);
                }
            }
        }
        private void btnL1_Click(object sender, EventArgs e)
        {
            string display = btnL1.Text;
            updateSongDisplay(display);
        }
        private void btnL2_Click(object sender, EventArgs e)
        {
            string display = btnL2.Text;
            updateSongDisplay(display);
        }
        private void btnL3_Click(object sender, EventArgs e)
        {
            string display = btnL3.Text;
            updateSongDisplay(display);
        }
        private void btnL4_Click(object sender, EventArgs e)
        {
            string display = btnL4.Text;
            updateSongDisplay(display);
        }
        private void btnL5_Click(object sender, EventArgs e)
        {
            string display = btnL5.Text;
            updateSongDisplay(display);
        }
        private void btnL6_Click(object sender, EventArgs e)
        {
            string display = btnL6.Text;
            updateSongDisplay(display);
        }
        private void btnL7_Click(object sender, EventArgs e)
        {
            string display = btnL7.Text;
            updateSongDisplay(display);
        }
        private void btnL8_Click(object sender, EventArgs e)
        {
            string display = btnL8.Text;
            updateSongDisplay(display);
        }
        private void btnL9_Click(object sender, EventArgs e)
        {
            string display = btnL9.Text;
            updateSongDisplay(display);
        }
        private void btnL10_Click(object sender, EventArgs e)
        {
            string display = btnL10.Text;
            updateSongDisplay(display);
        }

        /// change tab
        private void tbcWonder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tbcWonder.SelectedTab.Text)
            {
                case "Bible":
                    pnlPreview.Visible = true;
                    btnLive.Visible = false;
                    liveChange(true);
                    break;
                case "Songs":
                    pnlPreview.Visible = true;
                    btnLive.Visible = true;
                    liveChange(false);
                    break;
                case "Library":
                    pnlPreview.Visible = false;
                    break;
            }
        }
        private void Songs()
        {
            //populate display
            lbxLibrary.Items.Clear();
            ResetLyricsText();
            foreach (var songkey in SongLibrary.Keys)
            {
                lbxLibrary.Items.Add(songkey);
            }

            Playlists();
        }
        private void Playlists()
        {
            cbxPlaylists.Items.Clear();
            lbxPlaylistSongs.Items.Clear();

            foreach (var playlist in PlaylistCatelog)
            {
                cbxPlaylists.Items.Add(playlist.Key.ToString());
            }
            cbxPlaylists.SelectedIndex = 0;
        }
        private void liveChange(bool state)
        {
            live = state;
            if (live)
            {
                btnLive.FlatStyle = FlatStyle.Popup;
                btnLive.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                btnLive.FlatStyle = FlatStyle.Flat;
                btnLive.BackColor = System.Drawing.Color.Teal;
            }
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            if (live)
            {
                liveChange(false);
            }
            else
            {
                liveChange(true);
            }
        }

        private void cbxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxPlaylistSongs.Items.Clear();
            foreach(var song in PlaylistCatelog[cbxPlaylists.Text])
            {
                lbxPlaylistSongs.Items.Add(song);
            }
        }

        private void lbxPlaylistSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxPlaylistSongs.SelectedIndex != -1)
            {
                SelectedSong(lbxPlaylistSongs.SelectedItem.ToString());
            }
        }
        private void SelectedSong(string song)
        {
            int btnNum = 1;
            ResetLyricsText();
            foreach (string lyric in SongLibrary[song])
            {
                switch (btnNum)
                {
                    case 1:
                        btnL1.Text = lyric;
                        break;
                    case 2:
                        btnL2.Text = lyric;
                        break;
                    case 3:
                        btnL3.Text = lyric;
                        break;
                    case 4:
                        btnL4.Text = lyric;
                        break;
                    case 5:
                        btnL5.Text = lyric;
                        break;
                    case 6:
                        btnL6.Text = lyric;
                        break;
                    case 7:
                        btnL7.Text = lyric;
                        break;
                    case 8:
                        btnL8.Text = lyric;
                        break;
                    case 9:
                        btnL9.Text = lyric;
                        break;
                    case 10:
                        btnL10.Text = lyric;
                        break;
                }
                btnNum++;
            }
        }
    }
}
