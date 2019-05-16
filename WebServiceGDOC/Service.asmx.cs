using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace WebServiceGDOC
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void InserirBarcode(string barcode , string criadoPor , Int32 paginas)
        {
            Process processo = new Process();
            //verifica se o barcode é 55 ou 44
            if (barcode.Substring(1, 2) == "44")
            {
                processo.InserirContratoBarcode(barcode, criadoPor, paginas);
            }
            else//regra 55 padrão
            { 
                processo.InserirBarcode(barcode, criadoPor, paginas);
            }
            string diretorio = "E:\\Arquivos\\GEDOC\\NF_ENT\\ENSEADA\\" + DateTime.Now.Date.ToString("yyyy") + "\\" + DateTime.Now.Date.ToString("yyyy-MM") + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\\" + barcode + ".pdf";
            string diretorioAtual = "\\\\wdciis03\\gedoc$" + "\\" + barcode + ".pdf";

            FileInfo infoArquivo = new FileInfo(diretorio);

            DirectoryInfo infoDir = new DirectoryInfo(infoArquivo.DirectoryName);
            if (!infoDir.Exists)
            {
                infoDir.Create();
            }

            if (infoArquivo.Exists)
            {
                infoArquivo.Delete();
            }

            System.IO.File.Move(diretorioAtual, diretorio);
        }

        //referente ao contratoD:\OneDrive - Enseada Industria Naval S.A\Projetos Visual Studio\Desenvolvimento\FINANCE\WebServiceGDOC\App_Data\
        [WebMethod]
        public void AnexarDocumentoImportacao(decimal anexoId)
        {
            AnexoDocumentoImportacao anexoDocumentoImportacao = new AnexoDocumentoImportacao();
            anexoDocumentoImportacao.SelecionarAnexoDocumentoImportacao(anexoId);
            string diretorio = "";
            if (anexoDocumentoImportacao.Id != 0)
            {
                try
                {
                    DirectoryInfo infoDir = new DirectoryInfo("E:\\Arquivos\\GEDOC\\NF_ENT\\ENSEADA\\DOC_IMPORT\\" + DateTime.Now.Date.ToString("yyyy") + "\\" + DateTime.Now.Date.ToString("yyyy-MM") + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\\" + anexoDocumentoImportacao.DocumentoImportacaoId);
                    if (!infoDir.Exists)
                    {
                        infoDir.Create();
                    }
                    FileInfo infoArquivo = new FileInfo(infoDir + "\\" + anexoDocumentoImportacao.NomeArquivo);
                    try
                    {
                        diretorio = infoDir + "\\" + DateTime.Now.Date.ToString("ddMMyyyy") + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + System.IO.Path.GetExtension(anexoDocumentoImportacao.NomeArquivo);
                        using (FileStream fs = new FileStream
                        (diretorio, FileMode.CreateNew, FileAccess.Write))
                        {
                            fs.Write(anexoDocumentoImportacao.Anexo, 0, anexoDocumentoImportacao.Anexo.Length);
                        }
                        anexoDocumentoImportacao.AtualizarAnexoDocumentoImportacao(anexoId, diretorio);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        [WebMethod]
        public void ExcluirAnexoDocumentoImportacao(decimal anexoId)
        {
            AnexoDocumentoImportacao anexoDocumentoImportacao = new AnexoDocumentoImportacao();
            anexoDocumentoImportacao.SelecionarAnexoDocumentoImportacao(anexoId);
            try
            {
                if (anexoDocumentoImportacao.Diretorio != null && anexoDocumentoImportacao.Diretorio != "")
                {
                    FileInfo infoArquivo = new FileInfo(anexoDocumentoImportacao.Diretorio);
                    infoArquivo.Delete();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}