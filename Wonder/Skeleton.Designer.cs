namespace Wonder
{
    partial class Skeleton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Skeleton));
            this.btnUpdateVerse = new System.Windows.Forms.Button();
            this.cbxV = new System.Windows.Forms.ComboBox();
            this.cbxBB = new System.Windows.Forms.ComboBox();
            this.cbxBC = new System.Windows.Forms.ComboBox();
            this.cbxBV = new System.Windows.Forms.ComboBox();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.btnProject = new System.Windows.Forms.Button();
            this.lbVersesPreview = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnUpdateVerse
            // 
            this.btnUpdateVerse.BackColor = System.Drawing.Color.Teal;
            this.btnUpdateVerse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateVerse.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnUpdateVerse.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUpdateVerse.Location = new System.Drawing.Point(687, 23);
            this.btnUpdateVerse.Name = "btnUpdateVerse";
            this.btnUpdateVerse.Size = new System.Drawing.Size(182, 46);
            this.btnUpdateVerse.TabIndex = 2;
            this.btnUpdateVerse.Text = "Update";
            this.btnUpdateVerse.UseVisualStyleBackColor = false;
            this.btnUpdateVerse.Click += new System.EventHandler(this.btnUpdateVerse_Click);
            // 
            // cbxV
            // 
            this.cbxV.BackColor = System.Drawing.Color.Teal;
            this.cbxV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxV.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxV.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxV.FormattingEnabled = true;
            this.cbxV.Location = new System.Drawing.Point(35, 24);
            this.cbxV.Name = "cbxV";
            this.cbxV.Size = new System.Drawing.Size(136, 46);
            this.cbxV.TabIndex = 3;
            this.cbxV.Text = "KJV";
            this.cbxV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkEnter);
            // 
            // cbxBB
            // 
            this.cbxBB.BackColor = System.Drawing.Color.Teal;
            this.cbxBB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBB.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxBB.FormattingEnabled = true;
            this.cbxBB.Location = new System.Drawing.Point(194, 24);
            this.cbxBB.Name = "cbxBB";
            this.cbxBB.Size = new System.Drawing.Size(295, 46);
            this.cbxBB.TabIndex = 4;
            this.cbxBB.Text = "Genesis";
            this.cbxBB.SelectedIndexChanged += new System.EventHandler(this.cbxBB_SelectedIndexChanged);
            this.cbxBB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkEnter);
            // 
            // cbxBC
            // 
            this.cbxBC.BackColor = System.Drawing.Color.Teal;
            this.cbxBC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.cbxBC.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxBC.FormattingEnabled = true;
            this.cbxBC.Location = new System.Drawing.Point(495, 24);
            this.cbxBC.Name = "cbxBC";
            this.cbxBC.Size = new System.Drawing.Size(82, 46);
            this.cbxBC.TabIndex = 5;
            this.cbxBC.Text = "1";
            this.cbxBC.SelectedIndexChanged += new System.EventHandler(this.cbxBC_SelectedIndexChanged);
            this.cbxBC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkEnter);
            // 
            // cbxBV
            // 
            this.cbxBV.BackColor = System.Drawing.Color.Teal;
            this.cbxBV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxBV.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBV.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxBV.FormattingEnabled = true;
            this.cbxBV.Location = new System.Drawing.Point(583, 24);
            this.cbxBV.Name = "cbxBV";
            this.cbxBV.Size = new System.Drawing.Size(78, 46);
            this.cbxBV.TabIndex = 6;
            this.cbxBV.Text = "1";
            this.cbxBV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkEnter);
            // 
            // rtbPreview
            // 
            this.rtbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbPreview.BackColor = System.Drawing.Color.Teal;
            this.rtbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbPreview.Font = new System.Drawing.Font("Arial Narrow", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPreview.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbPreview.Location = new System.Drawing.Point(35, 89);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.ReadOnly = true;
            this.rtbPreview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbPreview.Size = new System.Drawing.Size(715, 727);
            this.rtbPreview.TabIndex = 7;
            this.rtbPreview.Text = "Preview";
            // 
            // btnProject
            // 
            this.btnProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProject.BackColor = System.Drawing.Color.Teal;
            this.btnProject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnProject.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProject.Location = new System.Drawing.Point(265, 839);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(182, 64);
            this.btnProject.TabIndex = 8;
            this.btnProject.Text = "Project";
            this.btnProject.UseVisualStyleBackColor = false;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // lbVersesPreview
            // 
            this.lbVersesPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVersesPreview.BackColor = System.Drawing.Color.Teal;
            this.lbVersesPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbVersesPreview.ForeColor = System.Drawing.SystemColors.Window;
            this.lbVersesPreview.FormattingEnabled = true;
            this.lbVersesPreview.HorizontalScrollbar = true;
            this.lbVersesPreview.ItemHeight = 25;
            this.lbVersesPreview.Items.AddRange(new object[] {
            "Verse 1",
            "Verse 2",
            "Verse 3"});
            this.lbVersesPreview.Location = new System.Drawing.Point(789, 89);
            this.lbVersesPreview.Name = "lbVersesPreview";
            this.lbVersesPreview.Size = new System.Drawing.Size(646, 729);
            this.lbVersesPreview.TabIndex = 9;
            this.lbVersesPreview.SelectedIndexChanged += new System.EventHandler(this.lbVersesPreview_SelectedIndexChanged);
            // 
            // Skeleton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1502, 915);
            this.Controls.Add(this.lbVersesPreview);
            this.Controls.Add(this.btnProject);
            this.Controls.Add(this.rtbPreview);
            this.Controls.Add(this.cbxBV);
            this.Controls.Add(this.cbxBC);
            this.Controls.Add(this.cbxBB);
            this.Controls.Add(this.cbxV);
            this.Controls.Add(this.btnUpdateVerse);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Skeleton";
            this.Text = "Skeleton";
            this.Load += new System.EventHandler(this.Skeleton_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUpdateVerse;
        private System.Windows.Forms.ComboBox cbxV;
        private System.Windows.Forms.ComboBox cbxBB;
        private System.Windows.Forms.ComboBox cbxBC;
        private System.Windows.Forms.ComboBox cbxBV;
        private System.Windows.Forms.RichTextBox rtbPreview;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.ListBox lbVersesPreview;
    }
}

