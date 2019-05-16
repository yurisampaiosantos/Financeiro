namespace DownloadXMLNFeExemploBasico
{
    partial class Form1
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
            this.Web1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Img1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EditCaptcha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nfe = new System.Windows.Forms.TextBox();
            this.EditCertificado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btLimpar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img1)).BeginInit();
            this.SuspendLayout();
            // 
            // Web1
            // 
            this.Web1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Web1.Location = new System.Drawing.Point(26, 163);
            this.Web1.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web1.Name = "Web1";
            this.Web1.Size = new System.Drawing.Size(20, 330);
            this.Web1.TabIndex = 26;
            this.Web1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Img1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 114);
            this.panel1.TabIndex = 18;
            // 
            // Img1
            // 
            this.Img1.Location = new System.Drawing.Point(1, 1);
            this.Img1.Name = "Img1";
            this.Img1.Size = new System.Drawing.Size(250, 112);
            this.Img1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img1.TabIndex = 0;
            this.Img1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Certificado Digital ";
            this.label4.Visible = false;
            // 
            // EditCaptcha
            // 
            this.EditCaptcha.Location = new System.Drawing.Point(185, 525);
            this.EditCaptcha.Name = "EditCaptcha";
            this.EditCaptcha.Size = new System.Drawing.Size(78, 20);
            this.EditCaptcha.TabIndex = 24;
            this.EditCaptcha.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Captcha";
            this.label3.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Baixar XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nfe
            // 
            this.nfe.Location = new System.Drawing.Point(13, 163);
            this.nfe.MaxLength = 999999999;
            this.nfe.Multiline = true;
            this.nfe.Name = "nfe";
            this.nfe.Size = new System.Drawing.Size(357, 330);
            this.nfe.TabIndex = 35;
            // 
            // EditCertificado
            // 
            this.EditCertificado.Location = new System.Drawing.Point(58, 525);
            this.EditCertificado.Name = "EditCertificado";
            this.EditCertificado.Size = new System.Drawing.Size(205, 20);
            this.EditCertificado.TabIndex = 28;
            this.EditCertificado.Text = "6FFCC3889944772EAA7D02E6F0A50588";
            this.EditCertificado.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Chaves";
            // 
            // btLimpar
            // 
            this.btLimpar.Location = new System.Drawing.Point(274, 12);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(96, 24);
            this.btLimpar.TabIndex = 39;
            this.btLimpar.Text = "Limpar";
            this.btLimpar.UseVisualStyleBackColor = true;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 508);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(354, 47);
            this.progressBar1.TabIndex = 41;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 566);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btLimpar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nfe);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Web1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EditCertificado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EditCaptcha);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download de XML";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Img1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser Web1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Img1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EditCaptcha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nfe;
        private System.Windows.Forms.TextBox EditCertificado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLimpar;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

