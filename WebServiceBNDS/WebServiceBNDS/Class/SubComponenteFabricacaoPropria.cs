using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceBNDS
{
    public class SubComponenteFabricacaoPropria
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
        private string seqComponente;
        public string SeqComponente { get { return seqComponente; } set { seqComponente = value; } }
        private double porcentagemSigPlaniPPB;
        public double PorcentagemSigPlaniPPB { get { return porcentagemSigPlaniPPB; } set { porcentagemSigPlaniPPB = value; } }
        private double distribuicaoPPB;
        public double DistribuicaoPPB { get { return distribuicaoPPB; } set { distribuicaoPPB = value; } }


        public string InserirDados(SubComponenteFabricacaoPropria subComponenteFabricacaoPropria)
        {
            string mensagemErro = "";
            try
            {
                string sql = "";
                sql += " INSERT INTO SUBCOMPFABRICACAOPROPRIA ";
                sql += "  ( XML_ID , COMPONENTE_ID,  CODIGONCM,  CODIGOCFI,  VALORUNITARIO,  ALIQUOTAICM,  BASECALCULOICM,  ALIQUOTAIPI,  NOMEFABRICANTE,  CNPJFABRICANTE,  NOMEFORNECEDOR,  CNPJFORNECEDOR, ";
                sql += "    NUMERODOCUMENTONFOUDI,  CODIGOTIPODOCUMENTO,  CHAVENF,  CODITEMNFE,  BASECALCULOPIS,  ALIQUOTAPIS,  BASECALCULOCOFINS,  ALIQUOTACOFINS,  CODIGOCSTXCSOSN,  CUSTOFOBUNITARIO, ";
                sql += "    CUSTOCIFUNITARIODOLAR,  IMPOSTOIMPORTACAOUNITARIO,  PISUNITARIO,  COFINSUNITARIO,  PAISORIGEM,  PAGINADI,  SEQCOMPONENTE,  PORCENTAGEMSIGPLANIPPB,  DISTRIBUICAOPPB  ) ";
                sql += "VALUES  (";
                sql += " " + subComponenteFabricacaoPropria.XMLID + ",";
                sql += " " + subComponenteFabricacaoPropria.ComponenteID + ",";
                sql += " '" + subComponenteFabricacaoPropria.CodigoNcm + "',";
                sql += " '" + subComponenteFabricacaoPropria.CodigoCFI + "',";
                sql += " " + subComponenteFabricacaoPropria.ValorUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.AliquotaICM.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.BaseCalculoICM.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.AliquotaIPI.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + subComponenteFabricacaoPropria.NomeFabricante + "',";
                sql += " '" + subComponenteFabricacaoPropria.CNPJFabricante + "',";
                sql += " '" + subComponenteFabricacaoPropria.NomeFornecedor + "',";
                sql += " '" + subComponenteFabricacaoPropria.CNPJFornecedor + "',";
                sql += " '" + subComponenteFabricacaoPropria.NumeroDocumentoNFouDI + "',";
                sql += " '" + subComponenteFabricacaoPropria.CodigoTipoDocumento + "',";
                sql += " '" + subComponenteFabricacaoPropria.ChaveNF + "',";
                sql += " '" + subComponenteFabricacaoPropria.CodItemNFe + "',";
                sql += " " + subComponenteFabricacaoPropria.BaseCalculoPIS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.AliquotaPIS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.BaseCalculoCOFINS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + subComponenteFabricacaoPropria.AliquotaCOFINS + "',";
                sql += " '" + subComponenteFabricacaoPropria.CodigoCSTxCSOSN + "',";
                sql += " " + subComponenteFabricacaoPropria.CustoFOBUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.CustoCIFUnitarioDOLAR.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.ImpostoImportacaoUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.PisUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.CofinsUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + subComponenteFabricacaoPropria.PaisOrigem + "',";
                sql += " '" + subComponenteFabricacaoPropria.PaginaDI + "',";
                sql += " '" + subComponenteFabricacaoPropria.SeqComponente + "',";
                sql += " " + subComponenteFabricacaoPropria.PorcentagemSigPlaniPPB.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + subComponenteFabricacaoPropria.DistribuicaoPPB.ToString().Replace(".", "").Replace(",", ".");
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