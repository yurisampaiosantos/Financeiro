using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceBNDS
{
    public class Componente
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
        private double porcentagemSigPlaniPPB;
        public double PorcentagemSigPlaniPPB { get { return porcentagemSigPlaniPPB; } set { porcentagemSigPlaniPPB = value; } }
        private double distribuicaoPPB;
        public double DistribuicaoPPB { get { return distribuicaoPPB; } set { distribuicaoPPB = value; } }

        public string InserirDados(Componente componente)
        {
            string mensagemErro = "";
            try
            {
                string sql = "";
                sql += " INSERT INTO COMPONENTE  ";
                sql += " ( XML_ID,  NOME,  CODIGONCM,  ESPECIFICACAOCOMPLEMENTAR,  ORIGEM,  QUANTIDADE,  UNIDADEMEDIDA,  NOMEFABRICANTE,  CNPJFABRICANTE, ";
                sql += "  NOMEFORNECEDOR,  CNPJFORNECEDOR,  ORIGEMITENSFINANCIAVEIS,  SEQCOMPONENTE,  PORCENTAGEMSIGPLANIPPB,  DISTRIBUICAOPPB ) ";
                sql += "VALUES  (";
                sql += " " + componente.XMLID + ",";
                sql += " '" + componente.Nome + "',";
                sql += " '" + componente.CodigoNcm + "',";
                sql += " '" + componente.EspecificacaoComplementar + "',";
                sql += " '" + componente.Origem + ",";
                sql += " " + componente.Quantidade.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + componente.UnidadeMedida + "',";
                sql += " '" + componente.NomeFabricante + "',";
                sql += " '" + componente.CNPJFabricante + "',";
                sql += " '" + componente.NomeFornecedor + "',";
                sql += " '" + componente.CNPJFornecedor + "',";
                sql += " '" + componente.OrigemItensFinanciaveis + "',";
                sql += " '" + componente.SeqComponente + "',";
                sql += " " + componente.PorcentagemSigPlaniPPB.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + componente.DistribuicaoPPB.ToString().Replace(".", "").Replace(",", ".");
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