using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceBNDS
{
    public class NaoComponente
    {
        private double xMLID;

        public double XMLID
        {
            get { return xMLID; }
            set { xMLID = value; }
        }
        private string nome;
        public string Nome { get { return nome; } set { nome = value; } }
        private string codigoNcm;
        public string CodigoNcm { get { return codigoNcm; } set { codigoNcm = value; } }
        private string especificacaoComplementar;
        public string EspecificacaoComplementar { get { return especificacaoComplementar; } set { especificacaoComplementar = value; } }
        private string origem;
        public string Origem { get { return origem; } set { origem = value; } }
        private double quantidade;
        public double Quantidade { get { return quantidade; } set { quantidade = value; } }
        private string unidadeMedida;
        public string UnidadeMedida { get { return unidadeMedida; } set { unidadeMedida = value; } }
        private string nomeFabricante;
        public string NomeFabricante { get { return nomeFabricante; } set { nomeFabricante = value; } }
        private string cNPJFabricante;
        public string CNPJFabricante { get { return cNPJFabricante; } set { cNPJFabricante = value; } }
        private string nomeFornecedor;
        public string NomeFornecedor { get { return nomeFornecedor; } set { nomeFornecedor = value; } }
        private string cNPJFornecedor;
        public string CNPJFornecedor { get { return cNPJFornecedor; } set { cNPJFornecedor = value; } }
        private string origemItensFinanciaveis;
        public string OrigemItensFinanciaveis { get { return origemItensFinanciaveis; } set { origemItensFinanciaveis = value; } }
        private string seqComponente;
        public string SeqComponente { get { return seqComponente; } set { seqComponente = value; } }
        /* NÃO*/
        private string acessorio;
        public string Acessorio { get { return acessorio; } set { acessorio = value; } }
        private double pesounitario;
        public double PesoUnitario { get { return pesounitario; } set { pesounitario = value; } }
        private string codigocfi;
        public string CodigoCFI { get { return codigocfi; } set { codigocfi = value; } }
        private double valorunitario;
        public double ValorUnitario { get { return valorunitario; } set { valorunitario = value; } }
        private double aliquotaicm;
        public double AliquotaICM { get { return aliquotaicm; } set { aliquotaicm = value; } }
        private double basecalculoicm;
        public double BaseCalculoICM { get { return basecalculoicm; } set { basecalculoicm = value; } }
        private double aliquotaipi;
        public double AliquotaIPI { get { return aliquotaipi; } set { aliquotaipi = value; } }
        private string numerodocumentonfoudi;
        public string NumeroDocumentoNFouDI { get { return numerodocumentonfoudi; } set { numerodocumentonfoudi = value; } }
        private double codigotipodocumento;
        public double CodigoTipoDocumento { get { return codigotipodocumento; } set { codigotipodocumento = value; } }
        private string chavenf;
        public string ChaveNF { get { return chavenf; } set { chavenf = value; } }
        private string coditemnfe;
        public string CodItemNFe { get { return coditemnfe; } set { coditemnfe = value; } }
        private double basecalculopis;
        public double BaseCalculoPIS { get { return basecalculopis; } set { basecalculopis = value; } }
        private double aliquotapis;
        public double AliquotaPIS { get { return aliquotapis; } set { aliquotapis = value; } }
        private double basecalculocofins;
        public double BaseCalculoCOFINS { get { return basecalculocofins; } set { basecalculocofins = value; } }
        private double aliquotacofins;
        public double AliquotaCOFINS { get { return aliquotacofins; } set { aliquotacofins = value; } }
        private string codigocstxcsosn;
        public string CodigoCSTxCSOSN { get { return codigocstxcsosn; } set { codigocstxcsosn = value; } }
        private double custofobunitario;
        public double CustoFOBUnitario { get { return custofobunitario; } set { custofobunitario = value; } }
        private double custocifunitariodolar;
        public double CustoCIFUnitarioDOLAR { get { return custocifunitariodolar; } set { custocifunitariodolar = value; } }
        private double impostoimportacaounitario;
        public double ImpostoImportacaoUnitario { get { return impostoimportacaounitario; } set { impostoimportacaounitario = value; } }
        private double pisunitario;
        public double PisUnitario { get { return pisunitario; } set { pisunitario = value; } }
        private double cofinsunitario;
        public double CofinsUnitario { get { return cofinsunitario; } set { cofinsunitario = value; } }
        private string paisorigem;
        public string PaisOrigem { get { return paisorigem; } set { paisorigem = value; } }
        private double direitosantidumpingunitario;
        public double DireitosAntiDumpingUnitario { get { return direitosantidumpingunitario; } set { direitosantidumpingunitario = value; } }
        private string paginaDI;
        public string PaginaDI { get { return paginaDI; } set { paginaDI = value; } }

        public string InserirDados(NaoComponente naoComponente)
        {
            string mensagemErro = "";
            try
            {
                string sql = "";
                sql += " INSERT INTO COMPONENTE  ";
                sql += " ( XML_ID,   NOME,  CODIGONCM,  ESPECIFICACAOCOMPLEMENTAR,  ORIGEM,  QUANTIDADE,  UNIDADEMEDIDA,  NOMEFABRICANTE,  CNPJFABRICANTE, ";
                sql += "  NOMEFORNECEDOR,  CNPJFORNECEDOR,  ORIGEMITENSFINANCIAVEIS,  SEQCOMPONENTE, ";
                sql += "  ACESSORIO,PESOUNITARIO,CODIGOCFI,VALORUNITARIO,ALIQUOTAICM,BASECALCULOICM,ALIQUOTAIPI,NUMERODOCUMENTONFOUDI,CODIGOTIPODOCUMENTO, ";
                sql += "  CHAVENF,CODITEMNFE,BASECALCULOPIS,ALIQUOTAPIS,BASECALCULOCOFINS,ALIQUOTACOFINS,CODIGOCSTXCSOSN,CUSTOFOBUNITARIO,CUSTOCIFUNITARIODOLAR, ";
                sql += "  IMPOSTOIMPORTACAOUNITARIO,PISUNITARIO,COFINSUNITARIO,PAISORIGEM,DIREITOSANTIDUMPINGUNITARIO, PAGINADI ) ";
                sql += "VALUES  (";
                sql += " " + naoComponente.XMLID + ",";
                sql += " '" + naoComponente.Nome + "',";
                sql += " '" + naoComponente.CodigoNcm + "',";
                sql += " '" + naoComponente.EspecificacaoComplementar + "',";
                sql += " '" + naoComponente.Origem + "',";
                sql += " " + naoComponente.Quantidade.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoComponente.UnidadeMedida + "',";
                sql += " '" + naoComponente.NomeFabricante + "',";
                sql += " '" + naoComponente.CNPJFabricante + "',";
                sql += " '" + naoComponente.NomeFornecedor + "',";
                sql += " '" + naoComponente.CNPJFornecedor + "',";
                sql += " '" + naoComponente.OrigemItensFinanciaveis + "',";
                sql += " '" + naoComponente.SeqComponente + "',";
                sql += " '" + naoComponente.Acessorio + "',";
                sql += " " + naoComponente.PesoUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoComponente.CodigoCFI + "',";
                sql += " " + naoComponente.ValorUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.AliquotaICM.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.BaseCalculoICM.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.AliquotaIPI.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoComponente.NumeroDocumentoNFouDI + "',";
                sql += " " + naoComponente.CodigoTipoDocumento.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoComponente.ChaveNF + "',";
                sql += " '" + naoComponente.CodItemNFe + "',";
                sql += " " + naoComponente.BaseCalculoPIS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.AliquotaPIS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.BaseCalculoCOFINS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.AliquotaCOFINS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoComponente.CodigoCSTxCSOSN + "',";
                sql += " " + naoComponente.CustoFOBUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.CustoCIFUnitarioDOLAR.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.ImpostoImportacaoUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.PisUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + naoComponente.CofinsUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoComponente.PaisOrigem + "',";
                sql += " " + naoComponente.DireitosAntiDumpingUnitario.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + naoComponente.PaginaDI + "'";
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
                mensagemErro = mensagemErro + "Componente = Code: " + ex.ErrorCode + "\n" +
                                              "Message: " + ex.Message + "\n";
            }
            return mensagemErro;
        }

    }
}