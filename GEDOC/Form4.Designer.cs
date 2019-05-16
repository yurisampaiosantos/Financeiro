namespace Sample
{
    partial class fmLanguages
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
            this.bkOK = new System.Windows.Forms.Button();
            this.cbLanguages = new System.Windows.Forms.CheckedListBox();
            this.bkCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bkOK
            // 
            this.bkOK.Location = new System.Drawing.Point(12, 454);
            this.bkOK.Name = "bkOK";
            this.bkOK.Size = new System.Drawing.Size(75, 23);
            this.bkOK.TabIndex = 0;
            this.bkOK.Text = "OK";
            this.bkOK.UseVisualStyleBackColor = true;
            this.bkOK.Click += new System.EventHandler(this.bkOK_Click);
            // 
            // cbLanguages
            // 
            this.cbLanguages.CheckOnClick = true;
            this.cbLanguages.FormattingEnabled = true;
            this.cbLanguages.Items.AddRange(new object[] {
            "Bulgarian",
            "Catalan",
            "Croatian",
            "Czech",
            "Danish",
            "Dutch",
            "English",
            "Estonian",
            "Finnish",
            "French",
            "German",
            "Hungarian",
            "Indonesian",
            "Italian",
            "Latvian",
            "Lithuanian",
            "Norwegian",
            "Polish",
            "Portuguese",
            "Romanian",
            "Russian",
            "Slovak",
            "Slovenian",
            "Spanish",
            "Swedish",
            "Turkish"});
            this.cbLanguages.Location = new System.Drawing.Point(15, 12);
            this.cbLanguages.Name = "cbLanguages";
            this.cbLanguages.Size = new System.Drawing.Size(153, 424);
            this.cbLanguages.Sorted = true;
            this.cbLanguages.TabIndex = 1;
            // 
            // bkCancel
            // 
            this.bkCancel.Location = new System.Drawing.Point(93, 454);
            this.bkCancel.Name = "bkCancel";
            this.bkCancel.Size = new System.Drawing.Size(75, 23);
            this.bkCancel.TabIndex = 2;
            this.bkCancel.Text = "Cancel";
            this.bkCancel.UseVisualStyleBackColor = true;
            this.bkCancel.Click += new System.EventHandler(this.bkCancel_Click);
            // 
            // fmLanguages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 489);
            this.Controls.Add(this.bkCancel);
            this.Controls.Add(this.cbLanguages);
            this.Controls.Add(this.bkOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmLanguages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Languages";
            this.Load += new System.EventHandler(this.fmLanguages_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bkOK;
        private System.Windows.Forms.CheckedListBox cbLanguages;
        private System.Windows.Forms.Button bkCancel;
    }
}