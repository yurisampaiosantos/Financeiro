using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceBNDS
{
    public class MaodeObra
    {
        private double xMLID;

        public double XMLID
        {
            get { return xMLID; }
            set { xMLID = value; }
        }
private String  funcao;
        public String  Funcao{get { return funcao; }set { funcao = value;}}
private String  nomeCBO;
        public String  NomeCBO{get { return nomeCBO; }set { nomeCBO = value;}}
private String  codigoCBO;
        public String  CodigoCBO{get { return codigoCBO; }set { codigoCBO = value;}}
        private String  origem;
        public String  Origem{get { return origem; }set { origem = value;}}

private Double  valorRemuneracaoMensal;
        public Double  ValorRemuneracaoMensal{get { return valorRemuneracaoMensal; }set { valorRemuneracaoMensal = value;}}
private Double  valorRemuneracaoAnualUS;
        public Double  ValorRemuneracaoAnualUS{get { return valorRemuneracaoAnualUS; }set { valorRemuneracaoAnualUS = value;}}
private Double  valorEncargos;
        public Double  ValorEncargos{get { return valorEncargos; }set { valorEncargos = value;}}
private Double  jornadaTrabalho;
        public Double  JornadaTrabalho{get { return jornadaTrabalho; }set { jornadaTrabalho = value;}}
private Double  produtividadeTrabalho;
        public Double  ProdutividadeTrabalho{get { return produtividadeTrabalho; }set { produtividadeTrabalho = value;}}
private String  seqMaoObra;
        public String  SeqMaoObra{get { return seqMaoObra; }set { seqMaoObra = value;}}
private String  paisOrigem;
        public String  PaisOrigem{get { return paisOrigem; }set { paisOrigem = value;}}
private Double  tempoUsualPermanenciaPais;
        public Double  TempoUsualPermanenciaPais{get { return tempoUsualPermanenciaPais; }set { tempoUsualPermanenciaPais = value;}}


        public string InserirDados(MaodeObra maodeObra)
        {
            string mensagemErro = "";
            try
            {
                string sql = "";
                sql += " INSERT INTO MAODEOBRA  ";
                sql += " ( XML_ID,  FUNCAO,  NOMECBO,  CODIGOCBO,  ORIGEM,  VALORREMUNERACAOMENSAL,  VALORREMUNERACAOANUALUS,  VALORENCARGOS,  JORNADATRABALHO, ";
                sql += "  PRODUTIVIDADETRABALHO,  SEQMAOOBRA,  PAISORIGEM,  TEMPOUSUALPERMANENCIAPAIS ) ";
                sql += "VALUES  (";
                sql += " " + maodeObra.XMLID + ",";
                sql += " '" + maodeObra.Funcao + "',";
                sql += " '" + maodeObra.NomeCBO + "',";
                sql += " '" + maodeObra.CodigoCBO + "',";
                sql += " '" + maodeObra.Origem + "',";
                sql += " " + maodeObra.ValorRemuneracaoMensal.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + maodeObra.ValorRemuneracaoAnualUS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + maodeObra.ValorEncargos.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + maodeObra.JornadaTrabalho.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + maodeObra.ProdutividadeTrabalho.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + maodeObra.SeqMaoObra + "',";
                sql += " '" + maodeObra.PaisOrigem + "',";
                sql += " " + maodeObra.TempoUsualPermanenciaPais.ToString().Replace(".", "").Replace(",", ".");
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
                mensagemErro = mensagemErro + "Mao de Obra = Code: " + ex.ErrorCode + "\n" +
                                              "Message: " + ex.Message + "\n";
            }
            return mensagemErro;
        }

    }
}