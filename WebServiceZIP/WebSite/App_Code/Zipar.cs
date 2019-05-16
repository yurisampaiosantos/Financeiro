using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Text;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;

/// <summary>
/// Summary description for Zipar
/// </summary>
public class Zipar
{
	public Zipar()
	{

	}
    public string ZiparArquivos(string login,string diretorio, string codigos)
    {
        string diretorioArquivo = nameArchive(diretorio);
        if (Compress(diretorioArquivo, codigos))
        {
            Documentos documentos = new Documentos();
            documentos.EnviarEmail(login, diretorioArquivo.Replace(@"C:\inetpub\WebServiceZIP\ArquivosZIP\", @"http://wdciis03.intranet.local/WebServiceZIP/ArquivosZIP/").Replace(@"\", @"/"));
            return diretorioArquivo.Replace(@"C:\inetpub\wwwroot\WebServiceZIP\ArquivosZIP\", "http://drydock/WebServiceZip/ArquivosZIP/");
        }
        else
            return "";
    }
    public string ZiparArquivosXML(string login, string diretorio, string codigos)
    {
        string diretorioArquivo = nameArchive(diretorio);
        if (CompressXML(diretorioArquivo, codigos))
        {
            Documentos documentos = new Documentos();
            documentos.EnviarEmail(login, diretorioArquivo.Replace(@"C:\inetpub\WebServiceZIP\ArquivosZIP\", @"http://wdciis03.intranet.local/WebServiceZIP/ArquivosZIP/").Replace(@"\", @"/"));
            return diretorioArquivo.Replace(@"C:\inetpub\wwwroot\WebServiceZIP\ArquivosZIP\", "http://drydock/WebServiceZip/ArquivosZIP/");
        }
        else
            return "";
    }
    public string ZiparArquivosXMLSAP(string login, string diretorio, string codigos)
    {
        string diretorioArquivo = nameArchive(diretorio);
        if (CompressXMLSAP(diretorioArquivo, codigos))
        {
            Documentos documentos = new Documentos();
            documentos.EnviarEmail(login, diretorioArquivo.Replace(@"C:\inetpub\WebServiceZIP\ArquivosZIP\", @"http://wdciis03.intranet.local/WebServiceZIP/ArquivosZIP/").Replace(@"\", @"/"));
            return diretorioArquivo.Replace(@"C:\inetpub\wwwroot\WebServiceZIP\ArquivosZIP\", "http://drydock/WebServiceZip/ArquivosZIP/");
        }
        else
            return "";
    }
    private bool Compress(string diretorioArquivo,string codigos)
    {
        bool zipou = false;
        Documentos documentos = new Documentos();
        List<Documentos> listDocumentos = new List<Documentos>();
        listDocumentos = documentos.List(codigos);
        if (listDocumentos.Count != 0)
        {
            ZipOutputStream zipOutPut = new ZipOutputStream(File.Create(diretorioArquivo));
            try
            {
                //Compactação level 9
                zipOutPut.SetLevel(9);
                zipOutPut.Finish();
                zipOutPut.Close();
                //Inicia a criação do ZIP
                ZipFile zip = new ZipFile(diretorioArquivo);
                try
                {
                    if (listDocumentos.Count != 0)
                    {
                        zip.NameTransform = new ZipNameTransform(listDocumentos[0].Diretorio.Substring(0, listDocumentos[0].Diretorio.LastIndexOf(@"\")));
                    }

                    for (int x = 0; x < listDocumentos.Count; x++)
                    {
                        try
                        {
                            zip.BeginUpdate();
                            //Adicionando arquivos previamente criados ao zipFile
                            FileInfo nomeZIP = new FileInfo(listDocumentos[x].Diretorio);                           
                            zip.Add(nomeZIP.FullName,nomeZIP.Name);
                            zip.CommitUpdate();
                            zipou = true;
                        }
                        catch { }
                    }

                    zip.Close();
                }
                catch (Exception ex)
                {
                    zip.Close();
                }
            }
            catch (Exception ex)
            {
                zipOutPut.Close();
            }
        }
        else
        {
            ZipOutputStream zipOutPut = new ZipOutputStream(File.Create(diretorioArquivo));
            try
            {
                //Compactação level 9
                zipOutPut.SetLevel(9);
                zipOutPut.Finish();
                zipOutPut.Close(); 
                zipou = true;
            }
            catch (Exception ex)
            {               
            }
        }
        return zipou;
    }
    private bool CompressXML(string diretorioArquivo, string codigos)
    {
        bool zipou = false;
        Documentos documentos = new Documentos();
        List<Documentos> listDocumentos = new List<Documentos>();
        listDocumentos = documentos.ListXML(codigos);
        if (listDocumentos.Count != 0)
        {
            ZipOutputStream zipOutPut = new ZipOutputStream(File.Create(diretorioArquivo));
            try
            {
                //Compactação level 9
                zipOutPut.SetLevel(9);
                zipOutPut.Finish();
                zipOutPut.Close();
                //Inicia a criação do ZIP
                ZipFile zip = new ZipFile(diretorioArquivo);
                try
                {
                    if (listDocumentos.Count != 0)
                    {
                        zip.NameTransform = new ZipNameTransform(listDocumentos[0].Diretorio.Substring(0, listDocumentos[0].Diretorio.LastIndexOf(@"\")));
                    }

                    for (int x = 0; x < listDocumentos.Count; x++)
                    {
                        try
                        {
                            zip.BeginUpdate();
                            //Adicionando arquivos previamente criados ao zipFile
                            FileInfo nomeZIP = new FileInfo(listDocumentos[x].Diretorio);
                            zip.Add(nomeZIP.FullName, nomeZIP.Name);
                            zip.CommitUpdate();
                            zipou = true;
                        }
                        catch { }
                    }

                    zip.Close();
                }
                catch (Exception ex)
                {
                    zip.Close();
                }
            }
            catch (Exception ex)
            {
                zipOutPut.Close();
            }
        }
        else
        {
            ZipOutputStream zipOutPut = new ZipOutputStream(File.Create(diretorioArquivo));
            try
            {
                //Compactação level 9
                zipOutPut.SetLevel(9);
                zipOutPut.Finish();
                zipOutPut.Close();
                zipou = true;
            }
            catch (Exception ex)
            {
            }
        }
        return zipou;
    }
    private bool CompressXMLSAP(string diretorioArquivo, string codigos)
    {
        bool zipou = false;
        Documentos documentos = new Documentos();
        List<Documentos> listDocumentos = new List<Documentos>();
        listDocumentos = documentos.ListXMLSAP(codigos);
        if (listDocumentos.Count != 0)
        {
            ZipOutputStream zipOutPut = new ZipOutputStream(File.Create(diretorioArquivo));
            try
            {
                //Compactação level 9
                zipOutPut.SetLevel(9);
                zipOutPut.Finish();
                zipOutPut.Close();
                //Inicia a criação do ZIP
                ZipFile zip = new ZipFile(diretorioArquivo);
                try
                {
                    if (listDocumentos.Count != 0)
                    {
                        zip.NameTransform = new ZipNameTransform(listDocumentos[0].Diretorio.Substring(0, listDocumentos[0].Diretorio.LastIndexOf(@"\")));
                    }

                    for (int x = 0; x < listDocumentos.Count; x++)
                    {
                        try
                        {
                            zip.BeginUpdate();
                            //Adicionando arquivos previamente criados ao zipFile
                            FileInfo nomeZIP = new FileInfo(listDocumentos[x].Diretorio);
                            zip.Add(nomeZIP.FullName, nomeZIP.Name);
                            zip.CommitUpdate();
                            zipou = true;
                        }
                        catch { }
                    }

                    zip.Close();
                }
                catch (Exception ex)
                {
                    zip.Close();
                }
            }
            catch (Exception ex)
            {
                zipOutPut.Close();
            }
        }
        else
        {
            ZipOutputStream zipOutPut = new ZipOutputStream(File.Create(diretorioArquivo));
            try
            {
                //Compactação level 9
                zipOutPut.SetLevel(9);
                zipOutPut.Finish();
                zipOutPut.Close();
                zipou = true;
            }
            catch (Exception ex)
            {
            }
        }
        return zipou;
    }
    private string nameArchive(string diretorio)
    {
        DirectoryInfo infoDir = new DirectoryInfo(diretorio + "\\ArquivosZIP");
        if (!infoDir.Exists)
        {
            infoDir.Create();
        }
        foreach (var item in infoDir.GetFiles())
        {
            FileInfo f = new FileInfo(item.Name);
            item.Attributes = FileAttributes.Normal;    //tira o atributo somente leitura 

            if (f.LastWriteTime == DateTime.Now.AddDays(-3))
            {
                continue;
            }
            else
            {
                item.Delete();
            }

        }       
        return infoDir.FullName + "\\" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".zip";
    }


}