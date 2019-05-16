namespace Sample
{
    partial class Form6
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
            this.lbBarcodes = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbBarcodes
            // 
            this.lbBarcodes.FormattingEnabled = true;
            this.lbBarcodes.Location = new System.Drawing.Point(23, 12);
            this.lbBarcodes.Name = "lbBarcodes";
            this.lbBarcodes.Size = new System.Drawing.Size(308, 381);
            this.lbBarcodes.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Sair";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(23, 404);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(36, 13);
            this.lbTotal.TabIndex = 2;
            this.lbTotal.Text = "Total";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 429);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbBarcodes);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Barcodes Enviados pro GEDOC";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbBarcodes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbTotal;
    }
}