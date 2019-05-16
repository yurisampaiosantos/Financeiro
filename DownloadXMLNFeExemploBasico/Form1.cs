using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeathByCaptcha;
using System.Threading;
using System.IO;
using Microsoft.Win32;

namespace DownloadXMLNFeExemploBasico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = nfe.Lines.Count();
            progressBar1.Value = 0;
            NFE();            
        }
        private void NFE()
        {
            ExcluirRegistro();

            string menssagem = "";
            UDownloadXMLNFeDLL.SetCertificadoDigital(EditCertificado.Text);
            Captcha captcha;
            
            foreach (string chaveAcesso in nfe.Lines)
            {
                progressBar1.Value++;
                if (progressBar1.Value % 50 == 0)
                { ExcluirRegistro(); }

                if (chaveAcesso.Substring(20, 2) != "57")
                {
                    if (UDownloadXMLNFeDLL.Captcha("Captcha.gif"))
                        Img1.ImageLocation = "Captcha.gif";
                    else
                        MessageBox.Show(UDownloadXMLNFeDLL.Msg());
                    try
                    {
                        captcha = Catcha();
                        try
                        {
                            EditCaptcha.Text = captcha.Text;
                        }
                        catch
                        {
                            EditCaptcha.Text = "";
                            Erro(chaveAcesso, "Em Branco");
                          //  Client client = (Client)new HttpClient("enseada", "Enseada2015");
                          //  client.Report(captcha);
                        }

                        if (EditCaptcha.Text != "")
                        {
                            if (UDownloadXMLNFeDLL.BaixarXMLNFeComCert(chaveAcesso, EditCaptcha.Text, chaveAcesso + ".xml"))
                            {
                                Web1.Navigate(Environment.CurrentDirectory + "\\" + chaveAcesso + ".xml");
                                Sucesso(chaveAcesso);
                            }
                            else
                            {
                                menssagem = UDownloadXMLNFeDLL.Msg();
                                if (menssagem.IndexOf("Código da Imagem") != -1)
                                {
                                    Erro(chaveAcesso, "Código da Imagem");
                                    Client client = (Client)new HttpClient("enseada", "Enseada2015");
                                    client.Report(captcha);
                                }
                                else
                                {
                                    if (menssagem.IndexOf("Chave de acesso") != -1)
                                    {
                                        Erro(chaveAcesso, "Chave de acesso");
                                    }
                                    else
                                        if (menssagem.IndexOf("diferente de 55") != -1)
                                        {
                                            CTE(chaveAcesso);
                                        }
                                        else
                                            if (menssagem.IndexOf("fernando-mm@hotmail.com") != -1 || menssagem.IndexOf("Certificado Digital") != -1)
                                            {
                                                Erro(chaveAcesso, menssagem);
                                                break;
                                            }
                                            else
                                            {
                                                Erro(chaveAcesso, menssagem);
                                            }
                                }
                            }
                        }

                        Thread.Sleep(5000);
                    }
                    catch (System.Exception ex)
                    {
                        Erro(chaveAcesso, ex.Message);
                    }
                }
                else
                {
                    CTE(chaveAcesso);
                }
            }
        }

        private void CTE(string chaveAcesso)
        {
            string menssagem = "";
            UDownloadXMLCTeDLL.SetCertificadoDigital(EditCertificado.Text);
            Captcha captcha;
         //   foreach (string chaveAcesso in txtcte.Lines)
         //   {

                if (UDownloadXMLCTeDLL.Captcha("Captcha.gif"))
                    Img1.ImageLocation = "Captcha.gif";
                else
                    MessageBox.Show(UDownloadXMLCTeDLL.Msg());

                try
                {
                    captcha = Catcha();                    
                        try
                        {
                            EditCaptcha.Text = captcha.Text;
                        }
                        catch
                        {
                            EditCaptcha.Text = "";
                            Erro(chaveAcesso, "Em Branco");
                            Client client = (Client)new HttpClient("enseada", "Enseada2015");
                            client.Report(captcha);
                        }

                        if (EditCaptcha.Text != "")
                        {

                            if (UDownloadXMLCTeDLL.BaixarXMLCTeComCert(chaveAcesso, EditCaptcha.Text, chaveAcesso + ".xml"))
                            {
                                Web1.Navigate(Environment.CurrentDirectory + "\\" + chaveAcesso + ".xml");
                                Sucesso(chaveAcesso);
                            }
                            else
                            {
                                menssagem = UDownloadXMLCTeDLL.Msg();
                                if (menssagem.IndexOf("Código da Imagem") != -1)
                                {
                                    Erro(chaveAcesso, "Código da Imagem");
                                    Client client = (Client)new HttpClient("enseada", "Enseada2015");
                                    client.Report(captcha);
                                }
                                else
                                {
                                    if (menssagem.IndexOf("Chave de acesso") != -1)
                                    {
                                        Erro(chaveAcesso, "Chave de acesso");
                                    }
                                    else
                                    {
                                        Erro(chaveAcesso, menssagem);
                                    }
                                }
                            }
                        }
                    Thread.Sleep(5000);
                }
                catch (System.Exception ex)
                {
                    Erro(chaveAcesso, ex.Message);
                }
           // }
        }
        private Captcha Catcha()
        {
            Client client = (Client)new HttpClient("enseada", "Enseada2015");
            Captcha retorno = null;
            try
            {
                double balance = client.GetBalance();

                /* Put your CAPTCHA file name, or file object, or arbitrary stream,
                   or an array of bytes, and optional solving timeout (in seconds) here: */
                Captcha captcha = client.Decode(@"C:\Users\yuri.sampaio\Documents\Visual Studio 2013\NFE\Código Fonte do Exemplo de Uso C#.NET Básico\bin\Debug\Captcha.gif", 15);
                retorno = captcha;
            }
            catch (AccessDeniedException ee)
            {
                /* Access to DBC API denied, check your credentials and/or balance */
            }
            return retorno;
        }

        private void Erro(string chaveAcesso, string erro)
        {
            StreamWriter vWriter = new StreamWriter(@"c:\TEMP\XMLErro.txt", true);
            vWriter.WriteLine(chaveAcesso + " | " + erro);
            vWriter.Flush();
            vWriter.Close();
        }
        private void Sucesso(string chaveAcesso)
        {
            StreamWriter vWriter = new StreamWriter(@"c:\TEMP\XMLSucesso.txt", true);
            vWriter.WriteLine(chaveAcesso);
            vWriter.Flush();
            vWriter.Close();
        }
        private void btLimpar_Click(object sender, EventArgs e)
        {
            nfe.Clear();
        }
        private void ExcluirRegistro()
        {
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE", true);
            if (myKey != null)
            {
                try
                {
                    myKey.DeleteSubKeyTree("DownloadXMLNFeDLL");
                }
                catch { }
            }
        }
        
    }
}
