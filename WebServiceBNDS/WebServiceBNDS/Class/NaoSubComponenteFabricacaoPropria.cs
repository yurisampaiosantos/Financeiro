using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceBNDS
{
    public class NaoSubComponenteFabricacaoPropria
    {
        private double xMLID;

        public double XMLID
        {
            get { return xMLID; }
            set { xMLID = value; }
        }

        private double componenteID;

        public double ComponenteID
        {
            get { return componenteID; }
            set { componenteID = value; }
        }

        private string codigoNcm;
        public string CodigoNcm { get { return codigoNcm; } set { codigoNcm = value; } }
        private string codigoCFI;
        public string CodigoCFI { get { return codigoCFI; } set { codigoCFI = value; } }
        private double valorUnitario;
        public double ValorUnitario { get { return valorUnitario; } set { valorUnitario = value; } }
        private double aliquotaICM;
        public double AliquotaICM { get { return aliquotaICM; } set { aliquotaICM = value; } }
        private double baseCalculoICM;
        public double BaseCalculoICM { get { return baseCalculoICM; } set { baseCalculoICM = value; } }
        private double aliquotaIPI;
        public double AliquotaIPI { get { return aliquotaIPI; } set { aliquotaIPI = value; } }
        private string nomeFabricante;
        public string NomeFabricante { get { return nomeFabricante; } set { nomeFabricante = value; } }
        private string cNPJFabricante;
        public string CNPJFabricante { get { return cNPJFabricante; } set { cNPJFabricante = value; } }
        private string nomeFornecedor;
        public string NomeFornecedor { get { return nomeFornecedor; } set { nomeFornecedor = value; } }
        private string cNPJFornecedor;
        public string CNPJFornecedor { get { return cNPJFornecedor; } set { cNPJFornecedor = value; } }
        private string numeroDocumentoNFouDI;
        public string NumeroDocumentoNFouDI { get { return numeroDocumentoNFouDI; } set { numeroDocumentoNFouDI = value; } }
        private string codigoTipoDocumento;
        public string CodigoTipoDocumento { get { return codigoTipoDocumento; } set { codigoTipoDocumento = value; } }

        private string chaveNF;
        public string ChaveNF { get { return chaveNF; } set { chaveNF = value; } }
        private string codItemNFe;
        public string CodItemNFe { get { return codItemNFe; } set { codItemNFe = value; } }
        private double baseCalculoPIS;
        public double BaseCalculoPIS { get { return baseCalculoPIS; } set { baseCalculoPIS = value; } }
        private double aliquotaPIS;
        public double AliquotaPIS { get { return aliquotaPIS; } set { aliquotaPIS = value; } }
        private double baseCalculoCOFINS;
        public double BaseCalculoCOFINS { get { return baseCalculoCOFINS; } set { baseCalculoCOFINS = value; } }
        private double aliquotaCOFINS;
        public double AliquotaCOFINS { get { return aliquotaCOFINS; } set { aliquotaCOFINS = value; } }
        private string codigoCSTxCSOSN;
        public string CodigoCSTxCSOSN { get { return codigoCSTxCSOSN; } set { codigoCSTxCSOSN = value; } }
        private double custoFOBUnitario;
        public double CustoFOBUnitario { get { return custoFOBUnitario; } set { custoFOBUnitario = value; } }
        private double custoCIFUnitarioDOLAR;
        public double CustoCIFUnitarioDOLAR { get { return custoCIFUnitarioDOLAR; } set { custoCIFUnitarioDOLAR = value; } }
        private double impostoImportacaoUnitario;
        public double ImpostoImportacaoUnitario { get { return impostoImportacaoUnitario; } set { impostoImportacaoUnitario = value; } }
        private double pisUnitario;
        public double PisUnitario { get { return pisUnitario; } set { pisUnitario = value; } }
        private double cofinsUnitario;
        public double CofinsUnitario { get { return cofinsUnitario; } set { cofinsUnitario = value; } }
        private string paisOrigem;
        public string PaisOrigem { get { return paisOrigem; } set { paisOrigem = value; } }

        private string paginaDI;
        public string PaginaDI { get { return paginaDI; } set { paginaDI = value; } }
        /* NÃO*/
        private string nome;
        public string Nome { get { return nome; } set { nome = value; } }
        private string especificacaoComplementar;
        public string EspecificacaoComplementar { get { return especificacaoComplementar; } set { especificacaoComplementar = value; } }
        private string origem;
        public string Origem { get { return origem; } set { origem = value; } }
        private double quantidade;
        public double Quantidade { get { return quantidade; } set { quantidade = value; } }
        private string acessorio;
        public string Acessorio { get { return acessorio; } set { acessorio = value; } }
        private string unidadeMedida;
        public string UnidadeMedida { get { return unidadeMedida; } set { unidadeMedida = value; } }
        private double pesoUnitario;
        public double PesoUnitario { get { return pesoUnitario; } set { pesoUnitario = value; } }
        private string origemItensFinanciaveis;
        public string OrigemItensFinanciaveis { get { return origemItensFinanciaveis; } set { origemItensFinanciaveis = value; } }
        private double direitosAntiDumpingUnitario;
        public double DireitosAntiDumpingUnitario { get { return direitosAntiDumpingUnitario; } set { direitosAntiDumpingUnitario = value; } }
        private string seqSubComponente;
        public string SeqSubComponente { get { return seqSubComponente; } set { seqSubComponente = value; } }



        public string InserirDados(NaoSubComponenteFabricacaoPropria naoSubComponenteFabricacaoPropria)
        {
            string mensagemErro = "";
            try
            {
                string sql = "";
                sql += " INSERT INTO SUBCOMPFABRICACAOPROPRIA ";
                sql += "  ( XML_ID , COMPONENTE_ID,  CODIGONCM,  CODIGOCFI,  VALORUNITARIO,  ALIQUOTAICM,  BASECALCULOICM,  ALIQUOTAIPI,  NOMEFABRICANTE,  CNPJFABRICANTE,  NOMEFORNECEDOR,  CNPJFORNECEDOR, ";
                sql += "    NUMERODOCUMENTONFOUDI,  CODIGOTIPODOCUMENTO,  CHAVENF,  CODITEMNFE,  BASECALCULOPIS,  ALIQUOTAPIS,  BASECALCULOCOFINS,  ALIQUOTACOFINS,  CODIGOCSTXCSOSN,  CUSTOFOBUNITARIO, ";
                sql += "    CUSTOCIFUNITARIODOLAR,  IMPOSTOIMPORTACAOUNITARIO,  PISUNITARIO,  COFINSUNITARIO,  PAISORIGEM,  PAGINADI,  ";
                sql += "    NOME,ESPECIFICACAOCOMPLEMENTAR,ORIGEM,QUANTIDADE,ACESSORIO,UNIDADEMEDIDA,PESOUNITARIO,ORIGEMITENSFINANCIAVEIS,DIREITOSANTIDUMPINGUNITARIO,SEQSUBCOMPONENTE,SEQCOMPONENTE) ";
                sql += "VALUES  (";
                sql += " " + naoSubComponenteFabricacaoPropria.XMLID + ",";
                sql += " '" + naoSubComponenteFabricacaoPropria.ComponenteID + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.CodigoNcm + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.CodigoCFI + "',";
                sql += " " + naoSubComponenteFabricacaoPropria.ValorUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.AliquotaICM.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.BaseCalculoICM.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.AliquotaIPI.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoSubComponenteFabricacaoPropria.NomeFabricante + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.CNPJFabricante + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.NomeFornecedor + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.CNPJFornecedor + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.NumeroDocumentoNFouDI + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.CodigoTipoDocumento + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.ChaveNF + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.CodItemNFe + "',";
                sql += " " + naoSubComponenteFabricacaoPropria.BaseCalculoPIS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.AliquotaPIS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.BaseCalculoCOFINS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.AliquotaCOFINS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoSubComponenteFabricacaoPropria.CodigoCSTxCSOSN + "',";
                sql += " " + naoSubComponenteFabricacaoPropria.CustoFOBUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.CustoCIFUnitarioDOLAR.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.ImpostoImportacaoUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.PisUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoSubComponenteFabricacaoPropria.CofinsUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoSubComponenteFabricacaoPropria.PaisOrigem + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.PaginaDI + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.Nome + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.EspecificacaoComplementar + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.Origem + "',";
                sql += " " + naoSubComponenteFabricacaoPropria.Quantidade.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoSubComponenteFabricacaoPropria.Acessorio + "',";
                sql += " '" + naoSubComponenteFabricacaoPropria.UnidadeMedida + "',";
                sql += " " + naoSubComponenteFabricacaoPropria.PesoUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoSubComponenteFabricacaoPropria.OrigemItensFinanciaveis + "',";
                sql += " " + naoSubComponenteFabricacaoPropria.DireitosAntiDumpingUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoSubComponenteFabricacaoPropria.seqSubComponente + "' , ";
                sql += " " + naoSubComponenteFabricacaoPropria.ComponenteID + "";
                sql += "        )";

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
            catch (OleDbException ex)
            {
                mensagemErro = mensagemErro + "Sub Componente = Code: " + ex.ErrorCode + "\n" +
                                              "Message: " + ex.Message + "\n";
            }
            return mensagemErro;
        }
    }
}