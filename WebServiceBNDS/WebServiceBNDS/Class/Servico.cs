using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceBNDS
{
    public class Servico
    {
        private double xMLID;

        public double XMLID
        {
            get { return xMLID; }
            set { xMLID = value; }
        }

        private String codigo;
        public String Codigo { get { return codigo; } set { codigo = value; } }
        private String especificacaoComplementar;
        public String EspecificacaoComplementar { get { return especificacaoComplementar; } set { especificacaoComplementar = value; } }
        private String origem;
        public String Origem { get { return origem; } set { origem = value; } }
        private Double totalMoedaNacional;
        public Double TotalMoedaNacional { get { return totalMoedaNacional; } set { totalMoedaNacional = value; } }
        private Double aliquota_ISS;
        public Double Aliquota_ISS { get { return aliquota_ISS; } set { aliquota_ISS = value; } }
        private Double baseCalculo_ISS;
        public Double BaseCalculo_ISS { get { return baseCalculo_ISS; } set { baseCalculo_ISS = value; } }
        private Double taxaRateio;
        public Double TaxaRateio { get { return taxaRateio; } set { taxaRateio = value; } }
        private String nomePrestadora;
        public String NomePrestadora { get { return nomePrestadora; } set { nomePrestadora = value; } }
        private String cNPJPrestadora;
        public String CNPJPrestadora { get { return cNPJPrestadora; } set { cNPJPrestadora = value; } }
        private String servicoContratado;
        public String ServicoContratado { get { return servicoContratado; } set { servicoContratado = value; } }
        private string seqServico;
        public string SeqServico { get { return seqServico; } set { seqServico = value; } }
        private Double totalUS;
        public Double TotalUS { get { return totalUS; } set { totalUS = value; } }
        private String paisOrigem;
        public String PaisOrigem { get { return paisOrigem; } set { paisOrigem = value; } }



        public string InserirDados(Servico servico)
        {
            string mensagemErro = "";
            try
            {
                string sql = "";
                sql += " INSERT INTO SERVICO ";
                sql += "  ( XML_ID,  CODIGO,  ESPECIFICACAOCOMPLEMENTAR,  ORIGEM,  TOTALMOEDANACIONAL,  ALIQUOTA_ISS,  BASECALCULO_ISS,  TAXARATEIO,  NOMEPRESTADORA,";
                sql += "    CNPJPRESTADORA,  SERVICOCONTRATADO,  SEQSERVICO,  TOTALUS,  PAISORIGEM  ) ";
                sql += "VALUES  (";
                sql += " " + servico.XMLID + ",";
                sql += " '" + servico.Codigo + "',";
                sql += " '" + servico.EspecificacaoComplementar + "',";
                sql += " '" + servico.Origem + "',";
                sql += " " + servico.TotalMoedaNacional.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + servico.Aliquota_ISS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + servico.BaseCalculo_ISS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + servico.TaxaRateio.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + servico.NomePrestadora + "',";
                sql += " '" + servico.CNPJPrestadora + "',";
                sql += " '" + servico.ServicoContratado + "',";
                sql += " '" + servico.SeqServico + "',";
                sql += " " + servico.TotalUS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + servico.PaisOrigem +"'";
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
                mensagemErro = mensagemErro + "Servico = Code: " + ex.ErrorCode + "\n" +
                                              "Message: " + ex.Message + "\n";
            }
            return mensagemErro;
        }
    }
}