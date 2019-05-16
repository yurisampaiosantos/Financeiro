using System;
using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Schema;

namespace WebServiceBNDS
{
    public class Importacao
    {
        static string MensagemErro;
        public void Importar(double anexoId , string diretorioXML)
        {
            MensagemErro = "";
            Conexao anexo = new Conexao();
            string diretorioPlanilha = ExtrairAnexo(anexoId, diretorioXML);
            if (diretorioPlanilha != "")
            {

                double tipo;
                tipo = anexo.VerificaTipo(anexoId);

                ExcelPackage ep = new ExcelPackage(new FileInfo(diretorioPlanilha));
                ExcelWorksheet wsCredenciamento = ep.Workbook.Worksheets["Credenciamento"];
                ExcelWorksheet wsProduto = ep.Workbook.Worksheets["Produto"];
                ExcelWorksheet wsComponente = ep.Workbook.Worksheets["Componente"];
                ExcelWorksheet wsSubComponente = ep.Workbook.Worksheets["SubComponente"];
                ExcelWorksheet wsMaoDeObra = ep.Workbook.Worksheets["MaoDeObra"];
                ExcelWorksheet wsServico = ep.Workbook.Worksheets["Servico"];

                if (wsCredenciamento.Dimension.End.Row > 1)
                {
                    InserirCredenciamento(wsCredenciamento, anexoId);
                }
                else
                {
                    MensagemErro = MensagemErro + "ABA Credenciamento não possui Registro" + "\n";
                }

                if (wsProduto.Dimension.End.Row > 1)
                {
                    InserirProduto(wsProduto, anexoId);
                }
                else
                {
                    MensagemErro = MensagemErro + "ABA Produto não possui Registro" + "\n";
                }
                // se tipo for 0 = Nao PPB se 1 = PPB
                if (tipo == 1)
                {
                    if (wsComponente.Dimension.End.Row > 1)
                    {
                        InserirComponente(wsComponente, anexoId);
                    }
                    else
                    {
                        MensagemErro = MensagemErro + "ABA Componente não possui Registro" + "\n";
                    }
                    if (wsSubComponente.Dimension.End.Row > 1)
                    {
                        InserirSubComponente(wsSubComponente, anexoId);
                    }
                }
                else
                {
                    if (wsComponente.Dimension.End.Row > 1)
                    {
                        InserirNaoComponente(wsComponente, anexoId);
                    }
                    else
                    {
                        MensagemErro = MensagemErro + "ABA Componente não possui Registro" + "\n";
                    }
                    if (wsSubComponente.Dimension.End.Row > 1)
                    {
                        InserirNaoSubComponente(wsSubComponente, anexoId);
                    }
                }

                if (wsMaoDeObra.Dimension.End.Row > 1)
                {
                    InserirMaodeObra(wsMaoDeObra, anexoId);
                }
                else
                {
                    MensagemErro = MensagemErro + "ABA Mão de Obra não possui Registro" + "\n";
                }

                if (wsServico.Dimension.End.Row > 1)
                {
                    InserirServico(wsServico, anexoId);
                }
                else
                {
                    MensagemErro = MensagemErro + "ABA Servico não possui Registro" + "\n";
                }
            }

            //erro na importacao XLS
            if (MensagemErro != "")
            {
                anexo.MensagemErro(anexoId, MensagemErro, 4);
            }
            else
            {
                // erro de validacao
                anexo.AtualizaSubComponente(anexoId);
                string MensagemErroValidacao = ValidarXML(anexoId, diretorioXML);
                if (MensagemErroValidacao != "")
                {
                    anexo.MensagemErro(anexoId, MensagemErroValidacao, 5);
                }
                else
                {
                    anexo.MensagemErro(anexoId, MensagemErroValidacao, 3);
                    anexo.GerarXML(anexoId);
                }
            }
        }
        private void InserirCredenciamento(ExcelWorksheet oSheet, double anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                if (oSheet.Cells[i, 1].Value != null)
                {
                    Credenciamento credenciamento = new Credenciamento();

                    credenciamento.XMLID = anexoId;
                    try
                    {
                        if (oSheet.Cells[i, 1].Value != null)
                            credenciamento.Responsavel = oSheet.Cells[i, 1].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Credenciamento na coluna " + oSheet.Cells[1, 1].Value.ToString() + " o valor " + oSheet.Cells[i, 1].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 2].Value != null)
                            credenciamento.Cargo = oSheet.Cells[i, 2].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Credenciamento na coluna " + oSheet.Cells[1, 2].Value.ToString() + " o valor " + oSheet.Cells[i, 2].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 3].Value != null)
                            credenciamento.Endereco = oSheet.Cells[i, 3].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Credenciamento na coluna " + oSheet.Cells[1, 3].Value.ToString() + " o valor " + oSheet.Cells[i, 3].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 4].Value != null)
                            credenciamento.Telefone = oSheet.Cells[i, 4].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Credenciamento na coluna " + oSheet.Cells[1, 4].Value.ToString() + " o valor " + oSheet.Cells[i, 4].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 5].Value != null)
                            credenciamento.Email = oSheet.Cells[i, 5].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Credenciamento na coluna " + oSheet.Cells[1, 5].Value.ToString() + " o valor " + oSheet.Cells[i, 5].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 6].Value != null)
                            credenciamento.Versao = oSheet.Cells[i, 6].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Credenciamento na coluna " + oSheet.Cells[1, 6].Value.ToString() + " o valor " + oSheet.Cells[i, 6].Value.ToString() + " apresentou erro " + "\n"; }


                    MensagemErro = MensagemErro + credenciamento.InserirDados(credenciamento);
                }
                else
                {
                    break;
                }
            }
        }
        private void InserirProduto(ExcelWorksheet oSheet, double anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                if (oSheet.Cells[i, 1].Value != null)
                {

                    Produto produto = new Produto();

                    //Codigo Chave
                    produto.XMLID = anexoId;
                    try
                    {
                        if (oSheet.Cells[i, 1].Value != null)
                            produto.NomeFabricante = oSheet.Cells[i, 1].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 1].Value.ToString() + " o valor " + oSheet.Cells[i, 1].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 2].Value != null)
                            produto.CNPJFabricante = oSheet.Cells[i, 2].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 2].Value.ToString() + " o valor " + oSheet.Cells[i, 2].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 3].Value != null)
                            produto.CodigoNcm = oSheet.Cells[i, 3].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 3].Value.ToString() + " o valor " + oSheet.Cells[i, 3].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 4].Value != null)
                            produto.NomeProduto = oSheet.Cells[i, 4].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 4].Value.ToString() + " o valor " + oSheet.Cells[i, 4].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 5].Value != null)
                            produto.Modelo = oSheet.Cells[i, 5].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 5].Value.ToString() + " o valor " + oSheet.Cells[i, 5].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 6].Value != null)
                            produto.TipoProduto = oSheet.Cells[i, 6].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 6].Value.ToString() + " o valor " + oSheet.Cells[i, 6].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 7].Value != null)
                            produto.TipoProducaoPPB = oSheet.Cells[i, 7].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 7].Value.ToString() + " o valor " + oSheet.Cells[i, 7].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 8].Value != null)
                            produto.PrecoAquisicaoTerceirizadaPPB = Convert.ToDouble(oSheet.Cells[i, 8].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 8].Value.ToString() + " o valor " + oSheet.Cells[i, 8].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 9].Value != null)
                            produto.PrecoVendaComImpostos = Convert.ToDouble(oSheet.Cells[i, 9].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 9].Value.ToString() + " o valor " + oSheet.Cells[i, 9].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 10].Value != null)
                            produto.BaseCalculo = Convert.ToDouble(oSheet.Cells[i, 10].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 10].Value.ToString() + " o valor " + oSheet.Cells[i, 10].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 11].Value != null)
                            produto.PercentualIPI = Convert.ToDouble(oSheet.Cells[i, 11].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 11].Value.ToString() + " o valor " + oSheet.Cells[i, 11].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 12].Value != null)
                            produto.PercentualICMS = Convert.ToDouble(oSheet.Cells[i, 12].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 12].Value.ToString() + " o valor " + oSheet.Cells[i, 12].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 13].Value != null)
                            produto.PercentualPIS = Convert.ToDouble(oSheet.Cells[i, 13].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 13].Value.ToString() + " o valor " + oSheet.Cells[i, 13].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 14].Value != null)
                            produto.PercentualCOFINS = Convert.ToDouble(oSheet.Cells[i, 14].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 14].Value.ToString() + " o valor " + oSheet.Cells[i, 14].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 15].Value != null)
                            produto.BaseCalculoPIS = Convert.ToDouble(oSheet.Cells[i, 15].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 15].Value.ToString() + " o valor " + oSheet.Cells[i, 15].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 16].Value != null)
                            produto.BaseCalculoCOFINS = Convert.ToDouble(oSheet.Cells[i, 16].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 16].Value.ToString() + " o valor " + oSheet.Cells[i, 16].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 17].Value != null)
                            produto.PesoLiquido = Convert.ToDouble(oSheet.Cells[i, 17].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 17].Value.ToString() + " o valor " + oSheet.Cells[i, 17].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 18].Value != null)
                            produto.TaxaCambio = Convert.ToDouble(oSheet.Cells[i, 18].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 18].Value.ToString() + " o valor " + oSheet.Cells[i, 18].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 19].Value != null)
                            produto.CodigoMoeda = Convert.ToDouble(oSheet.Cells[i, 19].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 19].Value.ToString() + " o valor " + oSheet.Cells[i, 19].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 20].Value != null)
                            produto.CodigoFINAMEFCC = oSheet.Cells[i, 20].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 20].Value.ToString() + " o valor " + oSheet.Cells[i, 20].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 21].Value != null)
                            produto.RazaoSocialClienteFinalFCC = oSheet.Cells[i, 21].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 21].Value.ToString() + " o valor " + oSheet.Cells[i, 21].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 22].Value != null)
                            produto.CNPJClienteFinalFCC = oSheet.Cells[i, 22].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Produto na coluna " + oSheet.Cells[1, 22].Value.ToString() + " o valor " + oSheet.Cells[i, 22].Value.ToString() + " apresentou erro " + "\n"; }


                    MensagemErro = MensagemErro + produto.InserirDados(produto);
                }
                else
                {
                    break;
                }
            }
        }
        private void InserirComponente(ExcelWorksheet oSheet, double anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                if (oSheet.Cells[i, 1].Value != null)
                {
                    Componente componente = new Componente();

                    //Codigo Chave
                    componente.XMLID = anexoId;

                    try
                    {
                        if (oSheet.Cells[i, 1].Value != null)
                            componente.Nome = oSheet.Cells[i, 1].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 1].Value.ToString() + " o valor " + oSheet.Cells[i, 1].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 2].Value != null)
                            componente.CodigoNcm = oSheet.Cells[i, 2].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 2].Value.ToString() + " o valor " + oSheet.Cells[i, 2].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 3].Value != null)
                            componente.EspecificacaoComplementar = oSheet.Cells[i, 3].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 3].Value.ToString() + " o valor " + oSheet.Cells[i, 3].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 4].Value != null)
                            componente.Origem = oSheet.Cells[i, 4].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 4].Value.ToString() + " o valor " + oSheet.Cells[i, 4].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 5].Value != null)
                            componente.Quantidade = Convert.ToDouble(oSheet.Cells[i, 5].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 5].Value.ToString() + " o valor " + oSheet.Cells[i, 5].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 6].Value != null)
                            componente.UnidadeMedida = oSheet.Cells[i, 6].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 6].Value.ToString() + " o valor " + oSheet.Cells[i, 6].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 7].Value != null)
                            componente.NomeFabricante = oSheet.Cells[i, 7].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 7].Value.ToString() + " o valor " + oSheet.Cells[i, 7].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 8].Value != null)
                            componente.CNPJFabricante = oSheet.Cells[i, 8].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 8].Value.ToString() + " o valor " + oSheet.Cells[i, 8].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 9].Value != null)
                            componente.NomeFornecedor = oSheet.Cells[i, 9].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 9].Value.ToString() + " o valor " + oSheet.Cells[i, 9].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 10].Value != null)
                            componente.CNPJFornecedor = oSheet.Cells[i, 10].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 10].Value.ToString() + " o valor " + oSheet.Cells[i, 10].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 11].Value != null)
                            componente.OrigemItensFinanciaveis = oSheet.Cells[i, 11].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 11].Value.ToString() + " o valor " + oSheet.Cells[i, 11].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 12].Value != null)
                            componente.SeqComponente = oSheet.Cells[i, 12].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 12].Value.ToString() + " o valor " + oSheet.Cells[i, 12].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 13].Value != null)
                            componente.PorcentagemSigPlaniPPB = Convert.ToDouble(oSheet.Cells[i, 13].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 13].Value.ToString() + " o valor " + oSheet.Cells[i, 13].Value.ToString() + " apresentou erro " + "\n"; }
                    try
                    {
                        if (oSheet.Cells[i, 14].Value != null)
                            componente.DistribuicaoPPB = Convert.ToDouble(oSheet.Cells[i, 14].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 14].Value.ToString() + " o valor " + oSheet.Cells[i, 14].Value.ToString() + " apresentou erro " + "\n"; }

                    MensagemErro = MensagemErro + componente.InserirDados(componente);
                }
                else
                {
                    break;
                }
            }
        }
        private void InserirNaoComponente(ExcelWorksheet oSheet, double anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                if (oSheet.Cells[i, 1].Value != null)
                {
                    NaoComponente naocomponente = new NaoComponente();

                    //Codigo Chave
                    naocomponente.XMLID = anexoId;

                    try
                    {
                        if (oSheet.Cells[i, 1].Value != null)
                            naocomponente.Nome = oSheet.Cells[i, 1].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 1].Value.ToString() + " o valor " + oSheet.Cells[i, 1].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 2].Value != null)
                            naocomponente.EspecificacaoComplementar = oSheet.Cells[i, 2].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 2].Value.ToString() + " o valor " + oSheet.Cells[i, 2].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 3].Value != null)
                            naocomponente.Origem = oSheet.Cells[i, 3].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 3].Value.ToString() + " o valor " + oSheet.Cells[i, 3].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 4].Value != null)
                            naocomponente.Quantidade = Convert.ToDouble(oSheet.Cells[i, 4].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 4].Value.ToString() + " o valor " + oSheet.Cells[i, 4].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 5].Value != null)
                            naocomponente.Acessorio = oSheet.Cells[i, 5].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 5].Value.ToString() + " o valor " + oSheet.Cells[i, 5].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 6].Value != null)
                            naocomponente.UnidadeMedida = oSheet.Cells[i, 6].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 6].Value.ToString() + " o valor " + oSheet.Cells[i, 6].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 7].Value != null)
                            naocomponente.PesoUnitario = Convert.ToDouble(oSheet.Cells[i, 7].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 7].Value.ToString() + " o valor " + oSheet.Cells[i, 7].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 8].Value != null)
                            naocomponente.OrigemItensFinanciaveis = oSheet.Cells[i, 8].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 8].Value.ToString() + " o valor " + oSheet.Cells[i, 8].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 9].Value != null)
                            naocomponente.CodigoNcm = oSheet.Cells[i, 9].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 9].Value.ToString() + " o valor " + oSheet.Cells[i, 9].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 10].Value != null)
                            naocomponente.CodigoCFI = oSheet.Cells[i, 10].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 10].Value.ToString() + " o valor " + oSheet.Cells[i, 10].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 11].Value != null)
                            naocomponente.ValorUnitario = Convert.ToDouble(oSheet.Cells[i, 11].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 11].Value.ToString() + " o valor " + oSheet.Cells[i, 11].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 12].Value != null)
                            naocomponente.AliquotaICM = Convert.ToDouble(oSheet.Cells[i, 12].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 12].Value.ToString() + " o valor " + oSheet.Cells[i, 12].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 13].Value != null)
                            naocomponente.BaseCalculoICM = Convert.ToDouble(oSheet.Cells[i, 13].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 13].Value.ToString() + " o valor " + oSheet.Cells[i, 13].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 14].Value != null)
                            naocomponente.AliquotaIPI = Convert.ToDouble(oSheet.Cells[i, 14].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 14].Value.ToString() + " o valor " + oSheet.Cells[i, 14].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 15].Value != null)
                            naocomponente.NomeFabricante = oSheet.Cells[i, 15].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 15].Value.ToString() + " o valor " + oSheet.Cells[i, 15].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 16].Value != null)
                            naocomponente.CNPJFabricante = oSheet.Cells[i, 16].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 16].Value.ToString() + " o valor " + oSheet.Cells[i, 16].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 17].Value != null)
                            naocomponente.NomeFornecedor = oSheet.Cells[i, 17].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 17].Value.ToString() + " o valor " + oSheet.Cells[i, 17].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 18].Value != null)
                            naocomponente.CNPJFornecedor = oSheet.Cells[i, 18].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 18].Value.ToString() + " o valor " + oSheet.Cells[i, 18].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 19].Value != null)
                            naocomponente.NumeroDocumentoNFouDI = oSheet.Cells[i, 19].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 19].Value.ToString() + " o valor " + oSheet.Cells[i, 19].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 20].Value != null && oSheet.Cells[i, 20].Value != "")
                            naocomponente.CodigoTipoDocumento = Convert.ToDouble(oSheet.Cells[i, 20].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 20].Value.ToString() + " o valor " + oSheet.Cells[i, 20].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 21].Value != null)
                            naocomponente.ChaveNF = oSheet.Cells[i, 21].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 21].Value.ToString() + " o valor " + oSheet.Cells[i, 21].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 22].Value != null)
                            naocomponente.CodItemNFe = oSheet.Cells[i, 22].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 22].Value.ToString() + " o valor " + oSheet.Cells[i, 23].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 23].Value != null)
                            naocomponente.BaseCalculoPIS = Convert.ToDouble(oSheet.Cells[i, 23].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 23].Value.ToString() + " o valor " + oSheet.Cells[i, 23].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 24].Value != null)
                            naocomponente.AliquotaPIS = Convert.ToDouble(oSheet.Cells[i, 24].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 24].Value.ToString() + " o valor " + oSheet.Cells[i, 24].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 25].Value != null)
                            naocomponente.BaseCalculoCOFINS = Convert.ToDouble(oSheet.Cells[i, 25].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 25].Value.ToString() + " o valor " + oSheet.Cells[i, 25].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 26].Value != null)
                            naocomponente.AliquotaCOFINS = Convert.ToDouble(oSheet.Cells[i, 26].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 26].Value.ToString() + " o valor " + oSheet.Cells[i, 26].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 27].Value != null)
                            naocomponente.CodigoCSTxCSOSN = oSheet.Cells[i, 27].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 27].Value.ToString() + " o valor " + oSheet.Cells[i, 27].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 28].Value != null)
                            naocomponente.CustoFOBUnitario = Convert.ToDouble(oSheet.Cells[i, 28].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 28].Value.ToString() + " o valor " + oSheet.Cells[i, 28].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 29].Value != null && oSheet.Cells[i, 29].Value != "")
                            naocomponente.CustoCIFUnitarioDOLAR = Convert.ToDouble(oSheet.Cells[i, 29].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 29].Value.ToString() + " o valor " + oSheet.Cells[i, 29].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 30].Value != null)
                            naocomponente.ImpostoImportacaoUnitario = Convert.ToDouble(oSheet.Cells[i, 30].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 30].Value.ToString() + " o valor " + oSheet.Cells[i, 30].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 31].Value != null)
                            naocomponente.PisUnitario = Convert.ToDouble(oSheet.Cells[i, 31].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 31].Value.ToString() + " o valor " + oSheet.Cells[i, 31].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 32].Value != null)
                            naocomponente.CofinsUnitario = Convert.ToDouble(oSheet.Cells[i, 32].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 32].Value.ToString() + " o valor " + oSheet.Cells[i, 32].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 33].Value != null)
                            naocomponente.PaisOrigem = oSheet.Cells[i, 33].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 33].Value.ToString() + " o valor " + oSheet.Cells[i, 33].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 34].Value != null)
                            naocomponente.DireitosAntiDumpingUnitario = Convert.ToDouble(oSheet.Cells[i, 34].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 34].Value.ToString() + " o valor " + oSheet.Cells[i, 34].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 35].Value != null)
                            naocomponente.PaginaDI = oSheet.Cells[i, 35].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 35].Value.ToString() + " o valor " + oSheet.Cells[i, 35].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 36].Value != null)
                            naocomponente.SeqComponente = oSheet.Cells[i, 36].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Componente na coluna " + oSheet.Cells[1, 36].Value.ToString() + " o valor " + oSheet.Cells[i, 36].Value.ToString() + " apresentou erro " + "\n"; }


                    MensagemErro = MensagemErro + naocomponente.InserirDados(naocomponente);
                }
                else
                {
                    break;
                }
            }
        }
        private void InserirSubComponente(ExcelWorksheet oSheet, double anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                if (oSheet.Cells[i, 1].Value != null)
                {
                    SubComponenteFabricacaoPropria subComponenteFabricacaoPropria = new SubComponenteFabricacaoPropria();

                    //Codigo Chave
                    subComponenteFabricacaoPropria.XMLID = anexoId;
                    try
                    {
                        if (oSheet.Cells[i, 1].Value != null)
                            subComponenteFabricacaoPropria.CodigoNcm = oSheet.Cells[i, 1].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 1].Value.ToString() + " o valor " + oSheet.Cells[i, 1].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 2].Value != null)
                            subComponenteFabricacaoPropria.CodigoCFI = oSheet.Cells[i, 2].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 2].Value.ToString() + " o valor " + oSheet.Cells[i, 2].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 3].Value != null)
                            subComponenteFabricacaoPropria.ValorUnitario = Convert.ToDouble(oSheet.Cells[i, 3].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 3].Value.ToString() + " o valor " + oSheet.Cells[i, 3].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 4].Value != null)
                            subComponenteFabricacaoPropria.AliquotaICM = Convert.ToDouble(oSheet.Cells[i, 4].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 4].Value.ToString() + " o valor " + oSheet.Cells[i, 4].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 5].Value != null)
                            subComponenteFabricacaoPropria.BaseCalculoICM = Convert.ToDouble(oSheet.Cells[i, 5].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 5].Value.ToString() + " o valor " + oSheet.Cells[i, 5].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 6].Value != null)
                            subComponenteFabricacaoPropria.AliquotaIPI = Convert.ToDouble(oSheet.Cells[i, 6].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 6].Value.ToString() + " o valor " + oSheet.Cells[i, 6].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 7].Value != null)
                            subComponenteFabricacaoPropria.NomeFabricante = oSheet.Cells[i, 7].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 7].Value.ToString() + " o valor " + oSheet.Cells[i, 7].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 8].Value != null)
                            subComponenteFabricacaoPropria.CNPJFabricante = oSheet.Cells[i, 8].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 8].Value.ToString() + " o valor " + oSheet.Cells[i, 8].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 9].Value != null)
                            subComponenteFabricacaoPropria.NomeFornecedor = oSheet.Cells[i, 9].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 9].Value.ToString() + " o valor " + oSheet.Cells[i, 9].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 10].Value != null)
                            subComponenteFabricacaoPropria.CNPJFornecedor = oSheet.Cells[i, 10].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 10].Value.ToString() + " o valor " + oSheet.Cells[i, 10].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 11].Value != null)
                            subComponenteFabricacaoPropria.NumeroDocumentoNFouDI = oSheet.Cells[i, 11].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 11].Value.ToString() + " o valor " + oSheet.Cells[i, 11].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 12].Value != null && oSheet.Cells[i, 12].Value != "")
                            subComponenteFabricacaoPropria.CodigoTipoDocumento = oSheet.Cells[i, 12].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 12].Value.ToString() + " o valor " + oSheet.Cells[i, 12].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 13].Value != null)
                            subComponenteFabricacaoPropria.ChaveNF = oSheet.Cells[i, 13].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 13].Value.ToString() + " o valor " + oSheet.Cells[i, 13].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 14].Value != null)
                            subComponenteFabricacaoPropria.CodItemNFe = oSheet.Cells[i, 14].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 14].Value.ToString() + " o valor " + oSheet.Cells[i, 14].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 15].Value != null)
                            subComponenteFabricacaoPropria.BaseCalculoPIS = Convert.ToDouble(oSheet.Cells[i, 15].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 15].Value.ToString() + " o valor " + oSheet.Cells[i, 15].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 16].Value != null)
                            subComponenteFabricacaoPropria.AliquotaPIS = Convert.ToDouble(oSheet.Cells[i, 16].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 16].Value.ToString() + " o valor " + oSheet.Cells[i, 16].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 17].Value != null)
                            subComponenteFabricacaoPropria.BaseCalculoCOFINS = Convert.ToDouble(oSheet.Cells[i, 17].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 17].Value.ToString() + " o valor " + oSheet.Cells[i, 17].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 18].Value != null)
                            subComponenteFabricacaoPropria.AliquotaCOFINS = Convert.ToDouble(oSheet.Cells[i, 18].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 18].Value.ToString() + " o valor " + oSheet.Cells[i, 18].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 19].Value != null)
                            subComponenteFabricacaoPropria.CodigoCSTxCSOSN = oSheet.Cells[i, 19].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 19].Value.ToString() + " o valor " + oSheet.Cells[i, 19].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 20].Value != null)
                            subComponenteFabricacaoPropria.CustoFOBUnitario = Convert.ToDouble(oSheet.Cells[i, 20].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 20].Value.ToString() + " o valor " + oSheet.Cells[i, 20].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 21].Value != null && oSheet.Cells[i, 21].Value != "")
                            subComponenteFabricacaoPropria.CustoCIFUnitarioDOLAR = Convert.ToDouble(oSheet.Cells[i, 21].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 21].Value.ToString() + " o valor " + oSheet.Cells[i, 21].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 22].Value != null)
                            subComponenteFabricacaoPropria.ImpostoImportacaoUnitario = Convert.ToDouble(oSheet.Cells[i, 22].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 2].Value.ToString() + " o valor " + oSheet.Cells[i, 2].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 23].Value != null)
                            subComponenteFabricacaoPropria.PisUnitario = Convert.ToDouble(oSheet.Cells[i, 23].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 23].Value.ToString() + " o valor " + oSheet.Cells[i, 23].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 24].Value != null)
                            subComponenteFabricacaoPropria.CofinsUnitario = Convert.ToDouble(oSheet.Cells[i, 24].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 24].Value.ToString() + " o valor " + oSheet.Cells[i, 24].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 25].Value != null)
                            subComponenteFabricacaoPropria.PaisOrigem = oSheet.Cells[i, 25].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 25].Value.ToString() + " o valor " + oSheet.Cells[i, 25].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 26].Value != null)
                            subComponenteFabricacaoPropria.PaginaDI = oSheet.Cells[i, 26].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 26].Value.ToString() + " o valor " + oSheet.Cells[i, 26].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 27].Value != null)
                            subComponenteFabricacaoPropria.SeqComponente = oSheet.Cells[i, 27].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 27].Value.ToString() + " o valor " + oSheet.Cells[i, 27].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 28].Value != null)
                            subComponenteFabricacaoPropria.PorcentagemSigPlaniPPB = Convert.ToDouble(oSheet.Cells[i, 28].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 28].Value.ToString() + " o valor " + oSheet.Cells[i, 28].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 29].Value != null && oSheet.Cells[i, 29].Value != "")
                            subComponenteFabricacaoPropria.DistribuicaoPPB = Convert.ToDouble(oSheet.Cells[i, 29].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 29].Value.ToString() + " o valor " + oSheet.Cells[i, 29].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 30].Value != null)
                            subComponenteFabricacaoPropria.ComponenteID = Convert.ToDouble(oSheet.Cells[i, 30].Value.ToString());
                    }
                    catch
                    {
                        MensagemErro = MensagemErro + "ABA Sub Componente na coluna " + oSheet.Cells[1, 30].Value.ToString() + " o valor " + oSheet.Cells[i, 30].Value.ToString() + " apresentou erro " + "\n";
                    }

                    MensagemErro = MensagemErro + subComponenteFabricacaoPropria.InserirDados(subComponenteFabricacaoPropria);
                }
                else
                {
                    break;
                }
            }
        }
        private void InserirNaoSubComponente(ExcelWorksheet oSheet, double anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                if (oSheet.Cells[i, 1].Value != null)
                {
                    NaoSubComponenteFabricacaoPropria naoSubComponenteFabricacaoPropria = new NaoSubComponenteFabricacaoPropria();

                    //Codigo Chave
                    naoSubComponenteFabricacaoPropria.XMLID = anexoId;

                    try
                    {
                        if (oSheet.Cells[i, 1].Value != null)
                            naoSubComponenteFabricacaoPropria.Nome = oSheet.Cells[i, 1].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 1].Value.ToString() + " o valor " + oSheet.Cells[i, 1].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 2].Value != null)
                            naoSubComponenteFabricacaoPropria.EspecificacaoComplementar = oSheet.Cells[i, 2].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 2].Value.ToString() + " o valor " + oSheet.Cells[i, 2].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 3].Value != null)
                            naoSubComponenteFabricacaoPropria.Origem = oSheet.Cells[i, 3].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 3].Value.ToString() + " o valor " + oSheet.Cells[i, 3].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 4].Value != null)
                            naoSubComponenteFabricacaoPropria.Quantidade = Convert.ToDouble(oSheet.Cells[i, 4].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 4].Value.ToString() + " o valor " + oSheet.Cells[i, 4].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 5].Value != null)
                            naoSubComponenteFabricacaoPropria.Acessorio = oSheet.Cells[i, 5].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 5].Value.ToString() + " o valor " + oSheet.Cells[i, 5].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 6].Value != null)
                            naoSubComponenteFabricacaoPropria.UnidadeMedida = oSheet.Cells[i, 6].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 6].Value.ToString() + " o valor " + oSheet.Cells[i, 6].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 7].Value != null)
                            naoSubComponenteFabricacaoPropria.PesoUnitario = Convert.ToDouble(oSheet.Cells[i, 7].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 7].Value.ToString() + " o valor " + oSheet.Cells[i, 7].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 8].Value != null)
                            naoSubComponenteFabricacaoPropria.OrigemItensFinanciaveis = oSheet.Cells[i, 8].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 8].Value.ToString() + " o valor " + oSheet.Cells[i, 8].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 9].Value != null)
                            naoSubComponenteFabricacaoPropria.CodigoNcm = oSheet.Cells[i, 9].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 9].Value.ToString() + " o valor " + oSheet.Cells[i, 9].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 10].Value != null)
                            naoSubComponenteFabricacaoPropria.CodigoCFI = oSheet.Cells[i, 10].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 10].Value.ToString() + " o valor " + oSheet.Cells[i, 10].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 11].Value != null)
                            naoSubComponenteFabricacaoPropria.ValorUnitario = Convert.ToDouble(oSheet.Cells[i, 11].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 11].Value.ToString() + " o valor " + oSheet.Cells[i, 11].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 12].Value != null)
                            naoSubComponenteFabricacaoPropria.AliquotaICM = Convert.ToDouble(oSheet.Cells[i, 12].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 12].Value.ToString() + " o valor " + oSheet.Cells[i, 12].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 13].Value != null)
                            naoSubComponenteFabricacaoPropria.BaseCalculoICM = Convert.ToDouble(oSheet.Cells[i, 13].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 13].Value.ToString() + " o valor " + oSheet.Cells[i, 13].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 14].Value != null)
                            naoSubComponenteFabricacaoPropria.AliquotaIPI = Convert.ToDouble(oSheet.Cells[i, 14].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 14].Value.ToString() + " o valor " + oSheet.Cells[i, 14].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 15].Value != null)
                            naoSubComponenteFabricacaoPropria.NomeFabricante = oSheet.Cells[i, 15].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 15].Value.ToString() + " o valor " + oSheet.Cells[i, 15].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 16].Value != null)
                            naoSubComponenteFabricacaoPropria.CNPJFabricante = oSheet.Cells[i, 16].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 16].Value.ToString() + " o valor " + oSheet.Cells[i, 16].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 17].Value != null)
                            naoSubComponenteFabricacaoPropria.NomeFornecedor = oSheet.Cells[i, 17].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 17].Value.ToString() + " o valor " + oSheet.Cells[i, 17].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 18].Value != null)
                            naoSubComponenteFabricacaoPropria.CNPJFornecedor = oSheet.Cells[i, 18].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 18].Value.ToString() + " o valor " + oSheet.Cells[i, 18].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 19].Value != null)
                            naoSubComponenteFabricacaoPropria.NumeroDocumentoNFouDI = oSheet.Cells[i, 19].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 19].Value.ToString() + " o valor " + oSheet.Cells[i, 19].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 20].Value != null && oSheet.Cells[i, 20].Value != "")
                            naoSubComponenteFabricacaoPropria.CodigoTipoDocumento = oSheet.Cells[i, 20].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 20].Value.ToString() + " o valor " + oSheet.Cells[i, 20].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 21].Value != null)
                            naoSubComponenteFabricacaoPropria.ChaveNF = oSheet.Cells[i, 21].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 21].Value.ToString() + " o valor " + oSheet.Cells[i, 21].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 22].Value != null)
                            naoSubComponenteFabricacaoPropria.CodItemNFe = oSheet.Cells[i, 22].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 22].Value.ToString() + " o valor " + oSheet.Cells[i, 22].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 23].Value != null)
                            naoSubComponenteFabricacaoPropria.BaseCalculoPIS = Convert.ToDouble(oSheet.Cells[i, 23].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 23].Value.ToString() + " o valor " + oSheet.Cells[i, 23].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 24].Value != null)
                            naoSubComponenteFabricacaoPropria.AliquotaPIS = Convert.ToDouble(oSheet.Cells[i, 24].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 24].Value.ToString() + " o valor " + oSheet.Cells[i, 24].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 25].Value != null)
                            naoSubComponenteFabricacaoPropria.BaseCalculoCOFINS = Convert.ToDouble(oSheet.Cells[i, 25].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 25].Value.ToString() + " o valor " + oSheet.Cells[i, 25].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 26].Value != null)
                            naoSubComponenteFabricacaoPropria.AliquotaCOFINS = Convert.ToDouble(oSheet.Cells[i, 26].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 26].Value.ToString() + " o valor " + oSheet.Cells[i, 26].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 27].Value != null)
                            naoSubComponenteFabricacaoPropria.CodigoCSTxCSOSN = oSheet.Cells[i, 27].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 27].Value.ToString() + " o valor " + oSheet.Cells[i, 27].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 28].Value != null)
                            naoSubComponenteFabricacaoPropria.CustoFOBUnitario = Convert.ToDouble(oSheet.Cells[i, 28].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 28].Value.ToString() + " o valor " + oSheet.Cells[i, 28].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 29].Value != null && oSheet.Cells[i, 29].Value != "")
                            naoSubComponenteFabricacaoPropria.CustoCIFUnitarioDOLAR = Convert.ToDouble(oSheet.Cells[i, 29].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 29].Value.ToString() + " o valor " + oSheet.Cells[i, 29].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 30].Value != null)
                            naoSubComponenteFabricacaoPropria.ImpostoImportacaoUnitario = Convert.ToDouble(oSheet.Cells[i, 30].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 30].Value.ToString() + " o valor " + oSheet.Cells[i, 30].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 31].Value != null)
                            naoSubComponenteFabricacaoPropria.PisUnitario = Convert.ToDouble(oSheet.Cells[i, 31].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 31].Value.ToString() + " o valor " + oSheet.Cells[i, 31].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 32].Value != null)
                            naoSubComponenteFabricacaoPropria.CofinsUnitario = Convert.ToDouble(oSheet.Cells[i, 32].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 32].Value.ToString() + " o valor " + oSheet.Cells[i, 32].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 33].Value != null)
                            naoSubComponenteFabricacaoPropria.PaisOrigem = oSheet.Cells[i, 33].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 33].Value.ToString() + " o valor " + oSheet.Cells[i, 33].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 34].Value != null)
                            naoSubComponenteFabricacaoPropria.DireitosAntiDumpingUnitario = Convert.ToDouble(oSheet.Cells[i, 34].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 34].Value.ToString() + " o valor " + oSheet.Cells[i, 34].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 35].Value != null)
                            naoSubComponenteFabricacaoPropria.PaginaDI = oSheet.Cells[i, 35].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 35].Value.ToString() + " o valor " + oSheet.Cells[i, 35].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 36].Value != null)
                            naoSubComponenteFabricacaoPropria.SeqSubComponente = oSheet.Cells[i, 36].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 36].Value.ToString() + " o valor " + oSheet.Cells[i, 36].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 37].Value != null)
                            naoSubComponenteFabricacaoPropria.ComponenteID = Convert.ToDouble(oSheet.Cells[i, 37].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA SUB Componente na coluna " + oSheet.Cells[1, 37].Value.ToString() + " o valor " + oSheet.Cells[i, 37].Value.ToString() + " apresentou erro " + "\n"; }


                    MensagemErro = MensagemErro + naoSubComponenteFabricacaoPropria.InserirDados(naoSubComponenteFabricacaoPropria);
                }
                else
                {
                    break;
                }
            }
        }
        private void InserirMaodeObra(ExcelWorksheet oSheet, double anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                if (oSheet.Cells[i, 1].Value != null)
                {
                    MaodeObra maodeObra = new MaodeObra();

                    //Codigo Chave
                    maodeObra.XMLID = anexoId;

                    try
                    {
                        if (oSheet.Cells[i, 1].Value != null && oSheet.Cells[i, 1].Value != "")
                            maodeObra.Funcao = oSheet.Cells[i, 1].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 1].Value.ToString() + " o valor " + oSheet.Cells[i, 1].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 2].Value != null && oSheet.Cells[i, 2].Value != "")
                            maodeObra.NomeCBO = oSheet.Cells[i, 2].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 2].Value.ToString() + " o valor " + oSheet.Cells[i, 2].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 3].Value != null && oSheet.Cells[i, 3].Value != "")
                            maodeObra.CodigoCBO = oSheet.Cells[i, 3].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 3].Value.ToString() + " o valor " + oSheet.Cells[i, 3].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 4].Value != null && oSheet.Cells[i, 4].Value != "")
                            maodeObra.Origem = oSheet.Cells[i, 4].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 4].Value.ToString() + " o valor " + oSheet.Cells[i, 4].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 5].Value != null && oSheet.Cells[i, 5].Value != "")
                            maodeObra.ValorRemuneracaoMensal = Convert.ToDouble(oSheet.Cells[i, 5].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 5].Value.ToString() + " o valor " + oSheet.Cells[i, 5].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 6].Value != null && oSheet.Cells[i, 6].Value != "")
                            maodeObra.ValorRemuneracaoAnualUS = Convert.ToDouble(oSheet.Cells[i, 6].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 6].Value.ToString() + " o valor " + oSheet.Cells[i, 6].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 7].Value != null && oSheet.Cells[i, 7].Value != "")
                            maodeObra.ValorEncargos = Convert.ToDouble(oSheet.Cells[i, 7].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 7].Value.ToString() + " o valor " + oSheet.Cells[i, 7].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 8].Value != null && oSheet.Cells[i, 8].Value != "")
                            maodeObra.JornadaTrabalho = Convert.ToDouble(oSheet.Cells[i, 8].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 8].Value.ToString() + " o valor " + oSheet.Cells[i, 8].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 9].Value != null && oSheet.Cells[i, 9].Value != "")
                            maodeObra.ProdutividadeTrabalho = Convert.ToDouble(oSheet.Cells[i, 9].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 9].Value.ToString() + " o valor " + oSheet.Cells[i, 9].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 10].Value != null && oSheet.Cells[i, 10].Value != "")
                            maodeObra.SeqMaoObra = oSheet.Cells[i, 10].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 10].Value.ToString() + " o valor " + oSheet.Cells[i, 10].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 11].Value != null && oSheet.Cells[i, 11].Value != "")
                            maodeObra.PaisOrigem = oSheet.Cells[i, 11].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 11].Value.ToString() + " o valor " + oSheet.Cells[i, 11].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 12].Value != null && oSheet.Cells[i, 12].Value !="")
                            maodeObra.TempoUsualPermanenciaPais = Convert.ToDouble(oSheet.Cells[i, 12].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Mao de obra na coluna " + oSheet.Cells[1, 12].Value.ToString() + " o valor " + oSheet.Cells[i, 12].Value.ToString() + " apresentou erro " + "\n"; }


                    MensagemErro = MensagemErro + maodeObra.InserirDados(maodeObra);
                }
                else
                {
                    break;
                }
            }
        }
        private void InserirServico(ExcelWorksheet oSheet, double anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                if (oSheet.Cells[i, 1].Value != null)
                {
                    Servico servico = new Servico();

                    //Codigo Chave
                    servico.XMLID = anexoId;
                    try
                    {
                        if (oSheet.Cells[i, 1].Value != null && oSheet.Cells[i, 1].Value != "")
                            servico.Codigo = oSheet.Cells[i, 1].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 1].Value.ToString() + " o valor " + oSheet.Cells[i, 1].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 2].Value != null && oSheet.Cells[i, 2].Value != "")
                            servico.EspecificacaoComplementar = oSheet.Cells[i, 2].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 2].Value.ToString() + " o valor " + oSheet.Cells[i, 2].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 3].Value != null && oSheet.Cells[i, 3].Value != "")
                            servico.Origem = oSheet.Cells[i, 3].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 3].Value.ToString() + " o valor " + oSheet.Cells[i, 3].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 4].Value != null && oSheet.Cells[i, 4].Value != "")
                            servico.TotalMoedaNacional = Convert.ToDouble(oSheet.Cells[i, 4].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 4].Value.ToString() + " o valor " + oSheet.Cells[i, 4].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 5].Value != null && oSheet.Cells[i, 5].Value != "")
                            servico.Aliquota_ISS = Convert.ToDouble(oSheet.Cells[i, 5].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 5].Value.ToString() + " o valor " + oSheet.Cells[i, 5].Value.ToString() + " apresentou erro " + "\n"; }


                    try
                    {
                        if (oSheet.Cells[i, 6].Value != null && oSheet.Cells[i, 6].Value != "")
                            servico.BaseCalculo_ISS = Convert.ToDouble(oSheet.Cells[i, 6].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 6].Value.ToString() + " o valor " + oSheet.Cells[i, 6].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 7].Value != null && oSheet.Cells[i, 7].Value != "")
                            servico.TaxaRateio = Convert.ToDouble(oSheet.Cells[i, 7].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 7].Value.ToString() + " o valor " + oSheet.Cells[i, 7].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 8].Value != null && oSheet.Cells[i, 8].Value != "")
                            servico.NomePrestadora = oSheet.Cells[i, 8].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 8].Value.ToString() + " o valor " + oSheet.Cells[i, 8].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 9].Value != null && oSheet.Cells[i, 9].Value != "")
                            servico.CNPJPrestadora = oSheet.Cells[i, 9].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 9].Value.ToString() + " o valor " + oSheet.Cells[i, 9].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 10].Value != null && oSheet.Cells[i, 10].Value != "")
                            servico.ServicoContratado = oSheet.Cells[i, 10].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 10].Value.ToString() + " o valor " + oSheet.Cells[i, 10].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 11].Value != null && oSheet.Cells[i, 11].Value != "")
                            servico.SeqServico = oSheet.Cells[i, 11].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 11].Value.ToString() + " o valor " + oSheet.Cells[i, 11].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 12].Value != null && oSheet.Cells[i, 12].Value != "")
                            servico.TotalUS = Convert.ToDouble(oSheet.Cells[i, 12].Value.ToString());
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 12].Value.ToString() + " o valor " + oSheet.Cells[i, 12].Value.ToString() + " apresentou erro " + "\n"; }

                    try
                    {
                        if (oSheet.Cells[i, 13].Value != null && oSheet.Cells[i, 13].Value != "")
                            servico.PaisOrigem = oSheet.Cells[i, 13].Value.ToString();
                    }
                    catch
                    { MensagemErro = MensagemErro + "ABA Servico na coluna " + oSheet.Cells[1, 13].Value.ToString() + " o valor " + oSheet.Cells[i, 13].Value.ToString() + " apresentou erro " + "\n"; }

                    MensagemErro = MensagemErro + servico.InserirDados(servico);
                }
                else
                {
                    break;
                }
            }
        }
        private string ExtrairAnexo(double anexoId, string diretorioXML)
        {
            Conexao anexo = new Conexao();
            anexo.SelecionarAnexo(anexoId);
            string diretorio = "";
            if (anexo.Anexo != null)
            {
                try
                {
                    DirectoryInfo infoDir = new DirectoryInfo(diretorioXML + "\\Anexos");
                    if (!infoDir.Exists)
                    {
                        infoDir.Create();
                    }
                    try
                    {
                        diretorio = infoDir + "\\" + anexoId + System.IO.Path.GetExtension(anexo.NomeArquivo);
                        FileInfo verificaArquivo = new FileInfo(diretorio);
                        if (verificaArquivo.Exists)
                        {
                            verificaArquivo.Delete();
                        }
                        using (FileStream fs = new FileStream
                        (diretorio, FileMode.CreateNew, FileAccess.Write))
                        {
                            fs.Write(anexo.Anexo, 0, anexo.Anexo.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return diretorio;
        }
        public string ValidarXML(double anexoId , string diretorioXML)
        {
            Conexao anexo = new Conexao();
            string erro = "";

            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, diretorioXML + @"\Class\Validacao.xsd");
                settings.ValidationType = ValidationType.Schema;
                XmlDocument xmlDocument = new XmlDocument();
                string xml = "";
                xml = anexo.RetornarXML(anexoId);
                xml = xml.Replace("<SubComponenteFabricacaoPropria></SubComponenteFabricacaoPropria>", "");
                xmlDocument.LoadXml(xml);

                XmlReader xr = XmlReader.Create(new StringReader(xmlDocument.InnerXml), settings);

                try
                {
                    while (xr.Read())
                    {
                        string s = xr.Name;
                        //  Response.Write(s + "<br/>");
                    }
                }
                catch (Exception ex)
                {
                    erro = xr.Name + " : " + ex.Message;
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
                
        }
    }
}