using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System. Collections;
using System.Web.UI.WebControls;
using System.Data;

namespace DAL
{
    public class ArquivoDAL
    {
        private decimal TratamentoArquivo(string diretorio)
        {
            StreamReader objReader = new StreamReader(diretorio);
			string sLine = "";
			ArrayList arrText = new ArrayList ();
            string[] strDados;
            ObjetoItauCardDAL objetoItauCardDAL = new ObjetoItauCardDAL();
            objReader.ReadLine();
            decimal seqId = objetoItauCardDAL.Sequencia();
            while (sLine != null)
            {               
				sLine = objReader.ReadLine();
                arrText.Add(sLine);
                if (sLine != null)
                {                   
                    MOD.ObjetoItauCard objetoItauCard = new MOD.ObjetoItauCard();
                    strDados = sLine.ToString().Split(';');
                    objetoItauCard.SeqId = seqId;
                    objetoItauCard.NumeroCartao = strDados[0].ToString();
                    objetoItauCard.VctoFatura = strDados[1].ToString();
                    objetoItauCard.Status = strDados[2].ToString();
                    objetoItauCard.Autorizacao = strDados[3].ToString();
                    objetoItauCard.Solicitante = strDados[4].ToString();
                    objetoItauCard.Dataemissao = strDados[5].ToString();
                    objetoItauCard.DataVoo = strDados[6].ToString();
                    objetoItauCard.UEUnidEmpr = strDados[7].ToString();
                    objetoItauCard.UAUnidAcomp = strDados[8].ToString();
                    objetoItauCard.Passageiro = strDados[9].ToString();
                    objetoItauCard.NumBilhete = strDados[10].ToString();
                    objetoItauCard.Localizador = strDados[11].ToString();
                    objetoItauCard.TipoEmissao = strDados[12].ToString();
                    objetoItauCard.CiaAerea = strDados[13].ToString();
                    objetoItauCard.ClasseServico = strDados[14].ToString();
                    objetoItauCard.Trechos = strDados[15].ToString();
                    objetoItauCard.TarifaCheia = strDados[16].ToString();
                    objetoItauCard.TariaAcordo = strDados[17].ToString();
                    objetoItauCard.PercEconCheiaAcordo = strDados[18].ToString();
                    objetoItauCard.TarifaVendida = strDados[19].ToString();
                    objetoItauCard.PercEconCheiaVendida = strDados[20].ToString();
                    objetoItauCard.TarifaPromocional = strDados[21].ToString();
                    objetoItauCard.PercEconomiaEfetiva = strDados[22].ToString();
                    objetoItauCard.TarifaLiquida = strDados[23].ToString();
                    objetoItauCard.TaxaEmbarque = strDados[24].ToString();
                    objetoItauCard.Total = strDados[25].ToString();

                    objetoItauCardDAL.Inserir(objetoItauCard);
                }             
			}
            objReader.Close();
            objReader.Dispose();
            FileInfo infoArquivo = new FileInfo(diretorio);
            infoArquivo.Delete();
            return seqId;
		}
        public decimal SalvarAnexo(FileUpload fuAnexo, string diretorioLocal)
        {
            decimal tamanho = (fuAnexo.PostedFile.ContentLength / 1024);
            decimal seqId = 0;
            if (tamanho <= 2097151)
            {
                if (fuAnexo.HasFile)
                {
                    try
                    {
                        DirectoryInfo infoDir = new DirectoryInfo(diretorioLocal + "\\Anexos\\");
                        if (!infoDir.Exists)
                        {
                            infoDir.Create();
                        }
                        FileInfo infoArquivo = new FileInfo(infoDir + "\\" + fuAnexo.FileName);
                        try
                        {
                            if (!infoArquivo.Exists)
                            {
                                fuAnexo.SaveAs(infoDir + "\\" + fuAnexo.FileName);                                
                            }
                            else
                            {
                                infoArquivo.Delete();
                                fuAnexo.SaveAs(infoDir + "\\" + fuAnexo.FileName);
                            }
                            seqId = TratamentoArquivo(infoDir + "\\" + fuAnexo.FileName);
                        }
                        catch (Exception ex)
                        {
                           
                        }
                    }
                    catch (Exception ex)
                    {
                     
                    }
                }
                else
                {
                    
                }
            }
            else
            {
                
            }
            return seqId;
        }
	}
}
