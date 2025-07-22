namespace Wonder
{
    partial class Projection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Projection));
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pbxCensor = new System.Windows.Forms.PictureBox();
            this.pbxTitle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.BackColor = System.Drawing.Color.Teal;
            this.rtbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F);
            this.rtbOutput.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbOutput.Location = new System.Drawing.Point(106, 112);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.rtbOutput.Size = new System.Drawing.Size(1271, 682);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "Test";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Teal;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnExit.Location = new System.Drawing.Point(1360, 28);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 42);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbxCensor
            // 
            this.pbxCensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxCensor.BackColor = System.Drawing.SystemColors.MenuText;
            this.pbxCensor.Location = new System.Drawing.Point(-3, -2);
            this.pbxCensor.Name = "pbxCensor";
            this.pbxCensor.Size = new System.Drawing.Size(1480, 887);
            this.pbxCensor.TabIndex = 2;
            this.pbxCensor.TabStop = false;
            this.pbxCensor.Visible = false;
            // 
            // pbxTitle
            // 
            this.pbxTitle.BackColor = System.Drawing.SystemColors.MenuText;
            this.pbxTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxTitle.Image = global::Wonder.Properties.Resources.WeddingFam;
            this.pbxTitle.Location = new System.Drawing.Point(0, 0);
            this.pbxTitle.Name = "pbxTitle";
            this.pbxTitle.Size = new System.Drawing.Size(1471, 880);
            this.pbxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxTitle.TabIndex = 3;
            this.pbxTitle.TabStop = false;
            this.pbxTitle.Visible = false;
            // 
            // Projection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1471, 880);
            this.ControlBox = false;
            this.Controls.Add(this.pbxTitle);
            this.Controls.Add(this.pbxCensor);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rtbOutput);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Projection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Projection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbxCensor;
        private System.Windows.Forms.PictureBox pbxTitle;
    }
}