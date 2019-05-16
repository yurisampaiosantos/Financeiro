using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceBNDS
{
    public class Conexao
    {
        public static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EBNDS;Password=fINdev18";

        private byte[] _anexo;

        public byte[] Anexo
        {
            get { return _anexo; }
            set { _anexo = value; }
        }

        private string _nomeArquivo;

        public string NomeArquivo
        {
            get { return _nomeArquivo; }
            set { _nomeArquivo = value; }
        }
        public void SelecionarAnexo(double anexoId)
        {
            string sql = "";
            sql += " SELECT BLOB_CONTENT , FILENAME";
            sql += " FROM  XML";
            sql += " WHERE ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(Conexao.StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                    {
                        if (dataReader.Read())
                        {
                            NomeArquivo = (string)dataReader["FILENAME"];
                            if (dataReader["BLOB_CONTENT"] != DBNull.Value)
                            {
                                Anexo = (Byte[])dataReader["BLOB_CONTENT"];
                            }
                        }
                    }
                }
                conn.Close();
            }
        }
        public double VerificaTipo(double anexoId)
        {
            double tipo = 0;
            string sql = "";
            sql += " SELECT TIPO ";
            sql += " FROM  XML";
            sql += " WHERE ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(Conexao.StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                    {
                        if (dataReader.Read())
                        {
                            if (dataReader["TIPO"] != DBNull.Value)
                            {
                                tipo = Convert.ToInt64(dataReader["TIPO"]);
                            }
                        }
                    }
                }
                conn.Close();
            }
            return tipo;
        }
        public void MensagemErro(double anexoId , string mensagemErro , double status)
        {
            string mesagem = "";

            if (mensagemErro.Length >= 3500)
            {
                mesagem=mensagemErro.Replace("'","\"").Substring(0,3500);
            }
            else
            {
                mesagem = mensagemErro.Replace("'", "\"");
            }

                string sql = "";
                sql += " UPDATE  XML SET STATUS = "+status+" , MENSAGEM_ERRO = '" + mesagem + "'";
                sql += " WHERE ID = " + anexoId;

                using (OleDbConnection conn = new OleDbConnection(Conexao.StringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
        }
        public void GerarXML(double anexoId)
        {

            string sql = "";
            sql += "BEGIN PRC_ANEXAR_XML("+anexoId+"); END;";

            using (OleDbConnection conn = new OleDbConnection(Conexao.StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public void AtualizaSubComponente(double anexoId)
        {
            string sql = "";
            sql += " UPDATE SUBCOMPFABRICACAOPROPRIA SET COMPONENTE_ID = (  SELECT ID  FROM COMPONENTE";
            sql += "                                                         WHERE COMPONENTE.XML_ID = SUBCOMPFABRICACAOPROPRIA.XML_ID";
            sql += "                                                         AND SUBCOMPFABRICACAOPROPRIA.COMPONENTE_ID = COMPONENTE.SEQCOMPONENTE";
            sql += "                                                         AND ROWNUM = 1";
            sql += "                                                      )";
            sql += " WHERE  XML_ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(Conexao.StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public string RetornarXML(double anexoId)
        {
            string resultado = "";
            string sql = "";

            sql += " SELECT  ";
            sql += " '<?xml version=\"1.0\" encoding=\"UTF-8\"?>'||  ";
            sql += "         XMLAgg(XMLELEMENT(\"Credenciamento_Produtos_CFI\",";
            sql += "               XMLELEMENT(\"row\",XMLATTRIBUTES(";
            sql += "                             CREDENCIAMENTO_PRODUTOS_CFI.Responsavel as \"Responsavel\",";
            sql += "                             CREDENCIAMENTO_PRODUTOS_CFI.Cargo as \"Cargo\",";
            sql += "                             CREDENCIAMENTO_PRODUTOS_CFI.Endereco as \"Endereco\",";
            sql += "                             CREDENCIAMENTO_PRODUTOS_CFI.Telefone as \"Telefone\",";
            sql += "                             CREDENCIAMENTO_PRODUTOS_CFI.Email as \"Email\",";
            sql += "                             CREDENCIAMENTO_PRODUTOS_CFI.Versao as \"Versao\" ";
            sql += "                             ),";
            sql += "                             ";
       //     sql += "                             --------produtos --------";
            sql += "                             (SELECT XMLAgg(XMLELEMENT(\"Produtos\",   ";
            sql += "                                 XMLELEMENT(\"row\",XMLATTRIBUTES(";
            sql += "                                               PRODUTOS.NomeFabricante as \"NomeFabricante\",";
            sql += "                                               PRODUTOS.CNPJFabricante as \"CNPJFabricante\",";
            sql += "                                               PRODUTOS.CodigoNcm as \"CodigoNcm\",";
            sql += "                                               PRODUTOS.NomeProduto as \"NomeProduto\",";
            sql += "                                               PRODUTOS.Modelo as \"Modelo\",";
            sql += "                                               PRODUTOS.TipoProduto as \"TipoProduto\",";
            sql += "                                               PRODUTOS.TipoProducaoPPB as \"TipoProducaoPPB\",";
            sql += "                                               PRODUTOS.PrecoAquisicaoTerceirizadaPPB as \"PrecoAquisicaoTerceirizadaPPB\",";
            sql += "                                               PRODUTOS.PrecoVendaComImpostos as \"PrecoVendaComImpostos\",";
            sql += "                                               PRODUTOS.BaseCalculo as \"BaseCalculo\",";
            sql += "                                               PRODUTOS.PercentualIPI as \"PercentualIPI\",";
            sql += "                                               PRODUTOS.PercentualICMS as \"PercentualICMS\",";
            sql += "                                               PRODUTOS.PercentualPIS as \"PercentualPIS\",";
            sql += "                                               PRODUTOS.PercentualCOFINS as \"PercentualCOFINS\",";
            sql += "                                               PRODUTOS.BaseCalculoPIS as \"BaseCalculoPIS\",";
            sql += "                                               PRODUTOS.BaseCalculoCOFINS as \"BaseCalculoCOFINS\",";
            sql += "                                               PRODUTOS.PesoLiquido as \"PesoLiquido\",";
            sql += "                                               PRODUTOS.TaxaCambio as \"TaxaCambio\",";
            sql += "                                               PRODUTOS.CodigoMoeda as \"CodigoMoeda\",";
            sql += "                                               PRODUTOS.CodigoFINAMEFCC as \"CodigoFINAMEFCC\",";
            sql += "                                               PRODUTOS.RazaoSocialClienteFinalFCC as \"RazaoSocialClienteFinalFCC\",";
            sql += "                                               PRODUTOS.CNPJClienteFinalFCC as \"CNPJClienteFinalFCC\"";
            sql += "                                               ),                       ";
        //    sql += "                                                               ----------componentes-----------------";
       //     sql += "                                                               (SELECT XMLAgg(XMLELEMENT(\"componente\", ";
            sql += "                                                                XMLELEMENT(\"Componentes\", ";  
            sql += "                                                               (SELECT ";
            sql += "                                                                   XMLAgg(XMLELEMENT(\"row\",XMLATTRIBUTES(";
            sql += "                                                                                 COMPONENTE.Nome as \"Nome\",";
            sql += "                                                                                 COMPONENTE.CodigoNcm as \"CodigoNcm\",";
            sql += "                                                                                 COMPONENTE.EspecificacaoComplementar as \"EspecificacaoComplementar\",";
            sql += "                                                                                 COMPONENTE.Origem as \"Origem\",";
            sql += "                                                                                 COMPONENTE.Quantidade as \"Quantidade\",";
            sql += "                                                                                 COMPONENTE.UnidadeMedida as \"UnidadeMedida\",";
            sql += "                                                                                 COMPONENTE.NomeFabricante as \"NomeFabricante\",";
            sql += "                                                                                 COMPONENTE.CNPJFabricante as \"CNPJFabricante\",";
            sql += "                                                                                 COMPONENTE.NomeFornecedor as \"NomeFornecedor\",";
            sql += "                                                                                 COMPONENTE.CNPJFornecedor as \"CNPJFornecedor\",";
            sql += "                                                                                 COMPONENTE.OrigemItensFinanciaveis as \"OrigemItensFinanciaveis\",";
            sql += "                                                                                 COMPONENTE.SeqComponente as \"Seq-Componente\",";
            sql += "                                                                                 COMPONENTE.PorcentagemSigPlaniPPB as \"PorcentagemSigPlaniPPB\",";
            sql += "                                                                                 COMPONENTE.DistribuicaoPPB as \"DistribuicaoPPB\",";
            sql += "                                                                                 COMPONENTE.Acessorio as \"Acessorio\",";
            sql += "                                                                                 COMPONENTE.PesoUnitario as \"PesoUnitario\",";
            sql += "                                                                                 COMPONENTE.CodigoCFI as \"CodigoCFI\",";
            sql += "                                                                                 COMPONENTE.ValorUnitario as \"ValorUnitario\",";
            sql += "                                                                                 COMPONENTE.AliquotaICM as \"AliquotaICM\",";
            sql += "                                                                                 COMPONENTE.BaseCalculoICM as \"BaseCalculoICM\",";
            sql += "                                                                                 COMPONENTE.AliquotaIPI as \"AliquotaIPI\",";
            //sql += "                                                                                 COMPONENTE.NomeFornecedor as \"NomeFornecedor\",";
            sql += "                                                                                 COMPONENTE.NumeroDocumentoNFouDI as \"NumeroDocumentoNFouDI\",";
            sql += "                                                                                 COMPONENTE.CodigoTipoDocumento as \"CodigoTipoDocumento\",";
            sql += "                                                                                 COMPONENTE.ChaveNF as \"ChaveNF\",";
            sql += "                                                                                 COMPONENTE.CodItemNFe as \"CodItemNFe\",";
            sql += "                                                                                 COMPONENTE.BaseCalculoPIS as \"BaseCalculoPIS\",";
            sql += "                                                                                 COMPONENTE.AliquotaPIS as \"AliquotaPIS\",";
            sql += "                                                                                 COMPONENTE.BaseCalculoCOFINS as \"BaseCalculoCOFINS\",";
            sql += "                                                                                 COMPONENTE.AliquotaCOFINS as \"AliquotaCOFINS\",";
            sql += "                                                                                 COMPONENTE.CodigoCSTxCSOSN as \"CodigoCSTxCSOSN\",";
            sql += "                                                                                 COMPONENTE.CustoFOBUnitario as \"CustoFOBUnitario\",";
            sql += "                                                                                 COMPONENTE.CustoCIFUnitarioDOLAR as \"CustoCIFUnitarioDOLAR\",";
            sql += "                                                                                 COMPONENTE.ImpostoImportacaoUnitario as \"ImpostoImportacaoUnitario\",";
            sql += "                                                                                 COMPONENTE.PisUnitario as \"PisUnitario\",";
            sql += "                                                                                 COMPONENTE.CofinsUnitario as \"CofinsUnitario\",";
            sql += "                                                                                 COMPONENTE.PaisOrigem as \"PaisOrigem\",";
            sql += "                                                                                 COMPONENTE.DireitosAntiDumpingUnitario as \"DireitosAntiDumpingUnitario\",";
            sql += "                                                                                 COMPONENTE.PaginaDI as \"PaginaDI\"";
            sql += "                                                                                 ),";
            sql += "                                                                                 ";
           // sql += "                                                                                     ------------sub compenentes-------------";
            //sql += "                                                                                     (SELECT XMLAgg(XMLELEMENT(\"SubComponenteFabricacaoPropria\",   ";
            sql += "                                                                                     XMLELEMENT(\"SubComponenteFabricacaoPropria\",   ";
            sql += "                                                                                     (SELECT   ";
            sql += "                                                                                         XMLAgg(XMLELEMENT(\"rowSubcomponenteFabricacaoPropria\",XMLATTRIBUTES(";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CodigoNcm as \"CodigoNcm\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CodigoCFI as \"CodigoCFI\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.ValorUnitario as \"ValorUnitario\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.AliquotaICM as \"AliquotaICM\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.BaseCalculoICM as \"BaseCalculoICM\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.AliquotaIPI as \"AliquotaIPI\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.NomeFabricante as \"NomeFabricante\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CNPJFabricante as \"CNPJFabricante\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.NomeFornecedor as \"NomeFornecedor\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CNPJFornecedor as \"CNPJFornecedor\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.NumeroDocumentoNFouDI as \"NumeroDocumentoNFouDI\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CodigoTipoDocumento as \"CodigoTipoDocumento\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.ChaveNF as \"ChaveNF\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CodItemNFe as \"CodItemNFe\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.BaseCalculoPIS as \"BaseCalculoPIS\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.AliquotaPIS as \"AliquotaPIS\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.BaseCalculoCOFINS as \"BaseCalculoCOFINS\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.AliquotaCOFINS as \"AliquotaCOFINS\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CodigoCSTxCSOSN as \"CodigoCSTxCSOSN\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CustoFOBUnitario as \"CustoFOBUnitario\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CustoCIFUnitarioDOLAR as \"CustoCIFUnitarioDOLAR\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.ImpostoImportacaoUnitario as \"ImpostoImportacaoUnitario\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.PisUnitario as \"PisUnitario\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.CofinsUnitario as \"CofinsUnitario\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.PaisOrigem as \"PaisOrigem\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.PaginaDI as \"PaginaDI\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.SeqComponente as \"Seq-Componente\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.PorcentagemSigPlaniPPB as \"PorcentagemSigPlaniPPB\",";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.DistribuicaoPPB as \"DistribuicaoPPB\", ";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.DireitosAntiDumpingUnitario as \"DireitosAntiDumpingUnitario\", ";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.NOME as \"Nome\", ";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.ESPECIFICACAOCOMPLEMENTAR as \"EspecificacaoComplementar\", ";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.ORIGEM as \"Origem\", ";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.QUANTIDADE as \"Quantidade\", ";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.ACESSORIO as \"Acessorio\", ";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.UNIDADEMEDIDA as \"UnidadeMedida\", ";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.PESOUNITARIO as \"PesoUnitario\", ";
            sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.ORIGEMITENSFINANCIAVEIS as \"OrigemItensFinanciaveis\" ";
          //  sql += "                                                                                                       SUBCOMPFABRICACAOPROPRIA.SEQSUBCOMPONENTE as \"Seq-SubComponente\" ";
            sql += "                                                                                                       )";
            sql += "                                                                                                      )";
//            sql += "                                                                                                   )";
            sql += "                                                                                             )SUBCOMPONENTE";
            sql += "                                                                             FROM SUBCOMPFABRICACAOPROPRIA";
            sql += "                                                                             WHERE SUBCOMPFABRICACAOPROPRIA.COMPONENTE_ID = COMPONENTE.ID ";
            sql += "                                                                             AND SUBCOMPFABRICACAOPROPRIA.XML_ID = COMPONENTE.XML_ID) ";
            sql += "                                                                       )))";
            sql += "                                                                   FROM COMPONENTE    ";
            sql += "                                                                   WHERE COMPONENTE.XML_ID = CREDENCIAMENTO_PRODUTOS_CFI.XML_ID)    ";
            sql += "                                                                   ), ";
         //   sql += "                                                                   -------------Mao de obra ---------------------";
            sql += "                                                                   XMLELEMENT(\"MaoDeObra\",   ";
            sql += "                                                                   (SELECT XMLAgg(XMLELEMENT(\"row\",XMLATTRIBUTES(";
            sql += "                                                                                     MAODEOBRA.Funcao as \"Funcao\",";
            sql += "                                                                                     MAODEOBRA.NomeCBO as \"NomeCBO\",";
            sql += "                                                                                     MAODEOBRA.CodigoCBO as \"CodigoCBO\",";
            sql += "                                                                                     MAODEOBRA.Origem as \"Origem\",";
            sql += "                                                                                     MAODEOBRA.ValorRemuneracaoMensal as \"ValorRemuneracaoMensal\",";
            sql += "                                                                                     MAODEOBRA.ValorRemuneracaoAnualUS as \"ValorRemuneracaoAnualUS\",";
            sql += "                                                                                     MAODEOBRA.ValorEncargos as \"ValorEncargos\",";
            sql += "                                                                                     MAODEOBRA.JornadaTrabalho as \"JornadaTrabalho\",";
            sql += "                                                                                     MAODEOBRA.ProdutividadeTrabalho as \"ProdutividadeTrabalho\",";
            sql += "                                                                                     MAODEOBRA.SeqMaoObra as \"Seq-MaoObra\",";
            sql += "                                                                                     MAODEOBRA.PaisOrigem as \"PaisOrigem\",";
            sql += "                                                                                     MAODEOBRA.TempoUsualPermanenciaPais as \"TempoUsualPermanenciaPais\"";
            sql += "                                                                                     )";
            sql += "                                                                             )";
//            sql += "                                                                           )";
            sql += "                                                                         )MAODEOBRA";
            sql += "                                                                   FROM MAODEOBRA ";
            sql += "                                                                   WHERE MAODEOBRA.XML_ID = CREDENCIAMENTO_PRODUTOS_CFI.XML_ID)   ";
            sql += "                                                                   ),";
          //  sql += "                                                                   ------------------servico--------------------";
            sql += "                                                                   XMLELEMENT(\"Servicos\",   ";
            sql += "                                                                   (SELECT XMLAgg(XMLELEMENT(\"row\",XMLATTRIBUTES(";
            sql += "                                                                                     SERVICO.Codigo as \"Codigo\",";
            sql += "                                                                                     SERVICO.EspecificacaoComplementar as \"EspecificacaoComplementar\",";
            sql += "                                                                                     SERVICO.Origem as \"Origem\",";
            sql += "                                                                                     SERVICO.TotalMoedaNacional as \"TotalMoedaNacional\",";
            sql += "                                                                                     SERVICO.Aliquota_ISS as \"Aliquota_ISS\",";
            sql += "                                                                                    SERVICO.BaseCalculo_ISS as \"BaseCalculo_ISS\",";
            sql += "                                                                                     SERVICO.TaxaRateio as \"TaxaRateio\",";
            sql += "                                                                                     SERVICO.NomePrestadora as \"NomePrestadora\",";
            sql += "                                                                                    SERVICO.CNPJPrestadora as \"CNPJPrestadora\",";
            sql += "                                                                                     SERVICO.ServicoContratado as \"ServicoContratado\",";
            sql += "                                                                                     SERVICO.SeqServico as \"Seq-Servico\",";
            sql += "                                                                                     SERVICO.TotalUS as \"TotalUS\",";
            sql += "                                                                                     SERVICO.PaisOrigem as \"PaisOrigem\"";
            sql += "                                                                                     )";
            sql += "                                                                             )";
//            sql += "                                                                            ) ";
            sql += "                                                                         )SERVICO";
            sql += "                                                                 FROM SERVICO ";
            sql += "                                                                 WHERE SERVICO.XML_ID = CREDENCIAMENTO_PRODUTOS_CFI.XML_ID)   ";
            sql += "                                                             )";
            sql += "                                                          )";
            sql += "                                                     )";
            sql += "                             )";
            sql += "                        FROM PRODUTOS";
            sql += "                        WHERE PRODUTOS.XML_ID = CREDENCIAMENTO_PRODUTOS_CFI.XML_ID ";
            sql += "                       )      ";
            sql += "                     )";
            sql += "                 )";
            sql += "             ).getClobVal() AS RESULT_XML";
            sql += "    FROM CREDENCIAMENTO_PRODUTOS_CFI ";
            sql += " WHERE XML_ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(Conexao.StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                    {
                        if (dataReader.Read())
                        {                            
                            if (dataReader["RESULT_XML"] != DBNull.Value)
                            {
                                resultado = (String)dataReader["RESULT_XML"];
                            }
                        }
                    }
                }
                conn.Close();
            }
            return resultado;
        }
    }
}