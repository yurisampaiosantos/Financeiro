using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DeathByCaptcha;
using System.Threading;

namespace DownloadXMLCTeExemploBasico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                
        private void ButCaptcha_Click(object sender, EventArgs e)
        {
            if (UDownloadXMLCTeDLL.Captcha("Captcha.gif"))
                Img1.ImageLocation = "Captcha.gif";
            else
                MessageBox.Show(UDownloadXMLCTeDLL.Msg());
        }

        private void ButLerCaptcha_Click(object sender, EventArgs e)
        {
            if (UDownloadXMLCTeDLL.CaptchaLer(EditLicencaLeitorCaptcha.Text, "Captcha.gif"))
                EditCaptcha.Text = UDownloadXMLCTeDLL.CaptchaLerTexto();
            else
                MessageBox.Show(UDownloadXMLCTeDLL.Msg());
        }

        private void ButBuscarCertificado_Click(object sender, EventArgs e)
        {
            EditCertificado.Text = UDownloadXMLCTeDLL.GetCertificadoDigital();

            if (EditCertificado.Text.Trim() != "")
                UDownloadXMLCTeDLL.SetCertificadoDigital(EditCertificado.Text);
        }

        private void ButBaixar2_Click(object sender, EventArgs e)
        {           

            if (EditCertificado.Text.Trim() != "")
                UDownloadXMLCTeDLL.SetCertificadoDigital(EditCertificado.Text);
            Captcha captcha;

            string menssagem = "";

            foreach (string chaveAcesso in nfe.Lines)
            {
                if (UDownloadXMLCTeDLL.Captcha("Captcha.gif"))
                    Img1.ImageLocation = "Captcha.gif";
                else
                    MessageBox.Show(UDownloadXMLCTeDLL.Msg());


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

                if (EditCertificado.Text == "")
                {
                    if (UDownloadXMLCTeDLL.BaixarXMLCTeSemCert(EditChave.Text, EditCaptcha.Text, EditChave.Text + ".xml"))
                    {
                        Web1.Navigate(Environment.CurrentDirectory + "\\" + EditChave.Text + ".xml");
                        Sucesso(chaveAcesso);
                    }
                    else
                    {
                        menssagem = UDownloadXMLCTeDLL.Msg();
                        if (menssagem.IndexOf("Código da Imagem") != -1)
                        {
                            Erro(chaveAcesso, "Código da Imagem");
                            // Client client = (Client)new HttpClient("enseada", "Enseada2015");
                            // client.Report(captcha);
                        }
                        else
                        {
                            if (menssagem.IndexOf("Chave de acesso") != -1)
                            {
                                Erro(chaveAcesso, "Chave de acesso");
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
                else
                {
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
                               // if (menssagem.IndexOf("Chave de acesso") != -1)
                              //  {
                              //      Erro(chaveAcesso, "Chave de acesso");
                              //  }
                              //  else
                                    if (menssagem.IndexOf("fernando-mm@hotmail.com") != -1 )
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
                }
                Thread.Sleep(5000);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Caso você tenha uma licença de basta descomentar a linha abaixo
            //UDownloadXMLCTeDLL.DLLLicenca("COLOQUE SUA LICENÇA AQUI");
        }
        private void Erro(string chaveAcesso, string erro)
        {
            StreamWriter vWriter = new StreamWriter(@"c:\TEMP\XMLErro.txt", true);
            vWriter.WriteLine(chaveAcesso + "|" + erro);
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
        private Captcha Catcha()
        {
            Client client = (Client)new HttpClient("enseada", "Enseada2015");
            Captcha retorno = null;
            try
            {
                double balance = client.GetBalance();

                /* Put your CAPTCHA file name, or file object, or arbitrary stream,
                   or an array of bytes, and optional solving timeout (in seconds) here: */
                Captcha captcha = client.Decode(@"C:\temp\CTE\Código Fonte do Exemplo de Uso C#.NET Básico\bin\Debug\Captcha.gif", 15);
                retorno = captcha;
            }
            catch (AccessDeniedException ee)
            {
                /* Access to DBC API denied, check your credentials and/or balance */
            }
            return retorno;
        }
    }
}
