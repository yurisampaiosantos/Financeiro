namespace GedocDownload
{
    partial class GedocDownload
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cblDownload = new System.Windows.Forms.CheckedListBox();
            this.rtbChaves = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btSelecaoDiretorio = new System.Windows.Forms.Button();
            this.tbDiretorio = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.rbChave = new System.Windows.Forms.RadioButton();
            this.rbBarcode = new System.Windows.Forms.RadioButton();
            this.btDownload = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btLog = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btLog);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cblDownload);
            this.panel1.Controls.Add(this.rtbChaves);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 457);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(410, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Resultado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Barcodde / NFe";
            // 
            // cblDownload
            // 
            this.cblDownload.Enabled = false;
            this.cblDownload.FormattingEnabled = true;
            this.cblDownload.Location = new System.Drawing.Point(413, 39);
            this.cblDownload.Name = "cblDownload";
            this.cblDownload.Size = new System.Drawing.Size(300, 349);
            this.cblDownload.TabIndex = 1;
            // 
            // rtbChaves
            // 
            this.rtbChaves.Location = new System.Drawing.Point(12, 39);
            this.rtbChaves.Name = "rtbChaves";
            this.rtbChaves.Size = new System.Drawing.Size(347, 353);
            this.rtbChaves.TabIndex = 0;
            this.rtbChaves.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btSelecaoDiretorio);
            this.panel2.Controls.Add(this.tbDiretorio);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.btDownload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 111);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Diretorio";
            // 
            // btSelecaoDiretorio
            // 
            this.btSelecaoDiretorio.Location = new System.Drawing.Point(397, 27);
            this.btSelecaoDiretorio.Name = "btSelecaoDiretorio";
            this.btSelecaoDiretorio.Size = new System.Drawing.Size(66, 23);
            this.btSelecaoDiretorio.TabIndex = 4;
            this.btSelecaoDiretorio.Text = "Selecionar Diretorio";
            this.btSelecaoDiretorio.UseVisualStyleBackColor = true;
            this.btSelecaoDiretorio.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbDiretorio
            // 
            this.tbDiretorio.Enabled = false;
            this.tbDiretorio.Location = new System.Drawing.Point(12, 29);
            this.tbDiretorio.Name = "tbDiretorio";
            this.tbDiretorio.Size = new System.Drawing.Size(380, 20);
            this.tbDiretorio.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.rbChave);
            this.panel4.Controls.Add(this.rbBarcode);
            this.panel4.Location = new System.Drawing.Point(12, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(282, 45);
            this.panel4.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo da consulta";
            // 
            // rbChave
            // 
            this.rbChave.AutoSize = true;
            this.rbChave.Location = new System.Drawing.Point(127, 21);
            this.rbChave.Name = "rbChave";
            this.rbChave.Size = new System.Drawing.Size(127, 17);
            this.rbChave.TabIndex = 1;
            this.rbChave.TabStop = true;
            this.rbChave.Text = "XML - Numero Chave";
            this.rbChave.UseVisualStyleBackColor = true;
            // 
            // rbBarcode
            // 
            this.rbBarcode.AutoSize = true;
            this.rbBarcode.Location = new System.Drawing.Point(15, 22);
            this.rbBarcode.Name = "rbBarcode";
            this.rbBarcode.Size = new System.Drawing.Size(95, 17);
            this.rbBarcode.TabIndex = 0;
            this.rbBarcode.TabStop = true;
            this.rbBarcode.Text = "PDF - Barcode";
            this.rbBarcode.UseVisualStyleBackColor = true;
            // 
            // btDownload
            // 
            this.btDownload.Location = new System.Drawing.Point(576, 61);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(136, 43);
            this.btDownload.TabIndex = 1;
            this.btDownload.Text = "Download";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // btLog
            // 
            this.btLog.Location = new System.Drawing.Point(481, 393);
            this.btLog.Name = "btLog";
            this.btLog.Size = new System.Drawing.Size(183, 28);
            this.btLog.TabIndex = 4;
            this.btLog.Text = "Salvar LOG";
            this.btLog.UseVisualStyleBackColor = true;
            this.btLog.Click += new System.EventHandler(this.btLog_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 427);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(725, 30);
            this.progressBar1.TabIndex = 6;
            // 
            // GedocDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 568);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "GedocDownload";
            this.Text = "GEDOC - Download PDF / XML";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbChaves;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox cblDownload;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbChave;
        private System.Windows.Forms.RadioButton rbBarcode;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btSelecaoDiretorio;
        private System.Windows.Forms.TextBox tbDiretorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btLog;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

