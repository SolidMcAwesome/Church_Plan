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
            this.VerseTextLine1 = new System.Windows.Forms.Label();
            this.btnUpdateVerse = new System.Windows.Forms.Button();
            this.cbxV = new System.Windows.Forms.ComboBox();
            this.cbxBB = new System.Windows.Forms.ComboBox();
            this.cbxBC = new System.Windows.Forms.ComboBox();
            this.cbxBV = new System.Windows.Forms.ComboBox();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.btnProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VerseTextLine1
            // 
            this.VerseTextLine1.AutoSize = true;
            this.VerseTextLine1.Location = new System.Drawing.Point(562, 57);
            this.VerseTextLine1.Name = "VerseTextLine1";
            this.VerseTextLine1.Size = new System.Drawing.Size(24, 13);
            this.VerseTextLine1.TabIndex = 0;
            this.VerseTextLine1.Text = "exe";
            // 
            // btnUpdateVerse
            // 
            this.btnUpdateVerse.BackColor = System.Drawing.Color.Teal;
            this.btnUpdateVerse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateVerse.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnUpdateVerse.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUpdateVerse.Location = new System.Drawing.Point(150, 207);
            this.btnUpdateVerse.Name = "btnUpdateVerse";
            this.btnUpdateVerse.Size = new System.Drawing.Size(182, 52);
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
            this.cbxV.Location = new System.Drawing.Point(38, 70);
            this.cbxV.Name = "cbxV";
            this.cbxV.Size = new System.Drawing.Size(362, 46);
            this.cbxV.TabIndex = 3;
            this.cbxV.Text = "KJV";
            // 
            // cbxBB
            // 
            this.cbxBB.BackColor = System.Drawing.Color.Teal;
            this.cbxBB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBB.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxBB.FormattingEnabled = true;
            this.cbxBB.Location = new System.Drawing.Point(38, 136);
            this.cbxBB.Name = "cbxBB";
            this.cbxBB.Size = new System.Drawing.Size(179, 46);
            this.cbxBB.TabIndex = 4;
            this.cbxBB.Text = "Genesis";
            // 
            // cbxBC
            // 
            this.cbxBC.BackColor = System.Drawing.Color.Teal;
            this.cbxBC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.cbxBC.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxBC.FormattingEnabled = true;
            this.cbxBC.Location = new System.Drawing.Point(340, 136);
            this.cbxBC.Name = "cbxBC";
            this.cbxBC.Size = new System.Drawing.Size(60, 46);
            this.cbxBC.TabIndex = 5;
            this.cbxBC.Text = "1";
            // 
            // cbxBV
            // 
            this.cbxBV.BackColor = System.Drawing.Color.Teal;
            this.cbxBV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxBV.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBV.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxBV.FormattingEnabled = true;
            this.cbxBV.Location = new System.Drawing.Point(236, 136);
            this.cbxBV.Name = "cbxBV";
            this.cbxBV.Size = new System.Drawing.Size(71, 46);
            this.cbxBV.TabIndex = 6;
            this.cbxBV.Text = "1";
            // 
            // rtbPreview
            // 
            this.rtbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPreview.BackColor = System.Drawing.Color.Teal;
            this.rtbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbPreview.Font = new System.Drawing.Font("Arial Narrow", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPreview.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbPreview.Location = new System.Drawing.Point(533, 92);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.ReadOnly = true;
            this.rtbPreview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbPreview.Size = new System.Drawing.Size(868, 630);
            this.rtbPreview.TabIndex = 7;
            this.rtbPreview.Text = "hi";
            // 
            // btnProject
            // 
            this.btnProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProject.BackColor = System.Drawing.Color.Teal;
            this.btnProject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnProject.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProject.Location = new System.Drawing.Point(150, 670);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(182, 52);
            this.btnProject.TabIndex = 8;
            this.btnProject.Text = "Project";
            this.btnProject.UseVisualStyleBackColor = false;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // Skeleton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1502, 818);
            this.Controls.Add(this.btnProject);
            this.Controls.Add(this.rtbPreview);
            this.Controls.Add(this.cbxBV);
            this.Controls.Add(this.cbxBC);
            this.Controls.Add(this.cbxBB);
            this.Controls.Add(this.cbxV);
            this.Controls.Add(this.btnUpdateVerse);
            this.Controls.Add(this.VerseTextLine1);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Skeleton";
            this.Text = "Skeleton";
            this.Load += new System.EventHandler(this.Skeleton_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VerseTextLine1;
        private System.Windows.Forms.Button btnUpdateVerse;
        private System.Windows.Forms.ComboBox cbxV;
        private System.Windows.Forms.ComboBox cbxBB;
        private System.Windows.Forms.ComboBox cbxBC;
        private System.Windows.Forms.ComboBox cbxBV;
        private System.Windows.Forms.RichTextBox rtbPreview;
        private System.Windows.Forms.Button btnProject;
    }
}

