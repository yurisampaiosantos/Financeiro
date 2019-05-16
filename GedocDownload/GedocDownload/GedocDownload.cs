using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GedocDownload
{
    public partial class GedocDownload : Form
    {
        public GedocDownload()
        {
            InitializeComponent();
            try
            {
                Download download = new Download();
                download.VerificarConexao();
            }
            catch
            {
                MessageBox.Show("Sem acesso ao banco de dados");
            }
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            cblDownload.Items.Clear();
            if (tbDiretorio.Text != "")
            {
                if (rbChave.Checked || rbBarcode.Checked)
                {
                    Download download = new Download();
                    string diretorio = "";
                    progressBar1.Maximum = rtbChaves.Lines.Count();
                    for (int i = 0; i < rtbChaves.Lines.Count(); i++)
                    {
                        if (rtbChaves.Lines[i].Replace("\t", "") != "")
                        {
                            if (rbBarcode.Checked)
                            {
                                diretorio = download.DownloadPDF(rtbChaves.Lines[i].Replace("\t", ""));
                                if (diretorio != "")
                                {
                                    //  fazer o download
                                    try
                                    {
                                        System.IO.File.Copy(diretorio, tbDiretorio.Text + "\\" + rtbChaves.Lines[i].Replace("\t", "") + ".pdf");
                                        cblDownload.Items.Add(rtbChaves.Lines[i].Replace("\t", ""), true);
                                    }
                                    catch
                                    {
                                        cblDownload.Items.Add(rtbChaves.Lines[i].Replace("\t", ""), false);
                                    }
                                }
                                else
                                {
                                    cblDownload.Items.Add(rtbChaves.Lines[i].Replace("\t", ""), false);
                                }
                            }
                            if (rbChave.Checked)
                            {
                                diretorio = download.DownloadXML(rtbChaves.Lines[i].Replace("\t", ""));
                                if (diretorio != "")
                                {
                                    //  fazer o download
                                    try
                                    {
                                        System.IO.File.Copy(diretorio, tbDiretorio.Text + "\\" + rtbChaves.Lines[i].Replace("\t", "") + ".xml");
                                        cblDownload.Items.Add(rtbChaves.Lines[i].Replace("\t", ""), true);
                                    }
                                    catch 
                                    {
                                        cblDownload.Items.Add(rtbChaves.Lines[i].Replace("\t", ""), false);
                                    }
                                }
                                else
                                {
                                    cblDownload.Items.Add(rtbChaves.Lines[i].Replace("\t", ""), false);
                                }
                            }
                        }
                        progressBar1.Value = i + 1;
                    }
                    MessageBox.Show("Download com sucesso");
                }
                else
                {
                    MessageBox.Show("É necessario selecionar um tipo de consulta");
                }
            }
            else
            {
                MessageBox.Show("É necessario selecionar um diretorio");
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDiretorio.Text = folderBrowserDialog1.SelectedPath;
            }  
        }

        private void btLog_Click(object sender, EventArgs e)
        {
            string arquivo = folderBrowserDialog1.SelectedPath + @"\LogErro.txt";
            StreamWriter salvar = new StreamWriter(arquivo);
            progressBar1.Maximum = cblDownload.Items.Count;
            for (int i = 0; i < cblDownload.Items.Count; i++)
            {
                if (cblDownload.GetItemChecked(i))
                {
                    salvar.WriteLine("ENCONTRATO - " + cblDownload.Items[i].ToString());
                }
                else
                {
                    salvar.WriteLine("NÃO ENCONTRATO - " + cblDownload.Items[i].ToString());
                }
                progressBar1.Value = i + 1;
            }
            salvar.Close();
            MessageBox.Show("Exportado com Sucesso");
        }
    }
}
