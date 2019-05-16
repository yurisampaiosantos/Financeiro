using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ValidarDiretorioXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LerXML xml = new LerXML();
            List<XML> listaXML = new List<XML>();
            listaXML = xml.SelecionaXML();
            foreach (XML selecionado in listaXML)
            {
                try
                {
                    FileInfo arquivo = new FileInfo(selecionado.Diretorio.Replace(@"\\",@"\").Replace("E:\\Arquivos\\GEDOC\\Legados\\", @"\\WDCIIS03\Legados\"));
                    if (arquivo.Exists)
                    {
                        StreamWriter vWriter = new StreamWriter(@"c:\temp\XMLPassou.txt", true);
                        vWriter.WriteLine(selecionado.Diretorio);
                        vWriter.Flush();
                        vWriter.Close();
                    }
                    else
                    {
                        xml.UpdateXML(selecionado.ID);
                    }
                }
                catch
                {
                    xml.UpdateXML(selecionado.ID);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LerXML xml = new LerXML();
            List<XML> listaXML = new List<XML>();
            listaXML = xml.SelecionaXMLSAP();
            foreach (XML selecionado in listaXML)
            {
                try
                {
                    FileInfo arquivo = new FileInfo(selecionado.Diretorio.Replace(@"\\", @"\").Replace("E:\\Arquivos\\GEDOC\\Legados\\", @"\\WDCIIS03\Legados\"));
                    if (arquivo.Exists)
                    {
                        StreamWriter vWriter = new StreamWriter(@"c:\temp\XMLPassou.txt", true);
                        vWriter.WriteLine(selecionado.Diretorio);
                        vWriter.Flush();
                        vWriter.Close();
                    }
                    else
                    {
                            xml.UpdateXMLSAP(selecionado.ID);
                    }
                }
                catch
                {
                      xml.UpdateXMLSAP(selecionado.ID);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LerXML xml = new LerXML();
            List<XML> listaXML = new List<XML>();
            listaXML = xml.SelecionaBarcode();
            foreach (XML selecionado in listaXML)
            {
                try
                {
                    FileInfo arquivo = new FileInfo(selecionado.Diretorio.Replace(@"\\", @"\"));
                    if (arquivo.Exists)
                    {
                        StreamWriter vWriter = new StreamWriter(@"c:\temp\XMLPassou.txt", true);
                        vWriter.WriteLine(selecionado.Diretorio);
                        vWriter.Flush();
                        vWriter.Close();
                    }
                    else
                    {
                        StreamWriter vWriter = new StreamWriter(@"c:\temp\XMLNaoPassou.txt", true);
                        vWriter.WriteLine(selecionado.Diretorio);
                        vWriter.Flush();
                        vWriter.Close();
                        xml.ExcluirBarcode(selecionado.ID);
                    }
                }
                catch
                {
                    StreamWriter vWriter = new StreamWriter(@"c:\temp\XMLerro.txt", true);
                    vWriter.WriteLine(selecionado.Diretorio);
                    vWriter.Flush();
                    vWriter.Close();                     
                }
            }
        }
    }
}
