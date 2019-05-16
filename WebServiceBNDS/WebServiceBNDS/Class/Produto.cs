using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceBNDS
{
    public class Produto
    {
        private double xMLID;

        public double XMLID
        {
            get { return xMLID; }
            set { xMLID = value; }
        }

        private string nomeFabricante;

        public string NomeFabricante
        {
            get { return nomeFabricante; }
            set { nomeFabricante = value; }
        }
        private string cNPJFabricante;

        public string CNPJFabricante
        {
            get { return cNPJFabricante; }
            set { cNPJFabricante = value; }
        }
        private string codigoNcm;

        public string CodigoNcm
        {
            get { return codigoNcm; }
            set { codigoNcm = value; }
        }
        private string nomeProduto;

        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }
        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        private string tipoProduto;

        public string TipoProduto
        {
            get { return tipoProduto; }
            set { tipoProduto = value; }
        }
        private string tipoProducaoPPB;

        public string TipoProducaoPPB
        {
            get { return tipoProducaoPPB; }
            set { tipoProducaoPPB = value; }
        }
        private double precoAquisicaoTerceirizadaPPB;

        public double PrecoAquisicaoTerceirizadaPPB
        {
            get { return precoAquisicaoTerceirizadaPPB; }
            set { precoAquisicaoTerceirizadaPPB = value; }
        }
        private double precoVendaComImpostos;

        public double PrecoVendaComImpostos
        {
            get { return precoVendaComImpostos; }
            set { precoVendaComImpostos = value; }
        }
        private double baseCalculo;

        public double BaseCalculo
        {
            get { return baseCalculo; }
            set { baseCalculo = value; }
        }
        private double percentualIPI;

        public double PercentualIPI
        {
            get { return percentualIPI; }
            set { percentualIPI = value; }
        }
        private double percentualICMS;

        public double PercentualICMS
        {
            get { return percentualICMS; }
            set { percentualICMS = value; }
        }
        private double percentualPIS;

        public double PercentualPIS
        {
            get { return percentualPIS; }
            set { percentualPIS = value; }
        }
        private double percentualCOFINS;

        public double PercentualCOFINS
        {
            get { return percentualCOFINS; }
            set { percentualCOFINS = value; }
        }
        private double baseCalculoPIS;

        public double BaseCalculoPIS
        {
            get { return baseCalculoPIS; }
            set { baseCalculoPIS = value; }
        }
        private double baseCalculoCOFINS;

        public double BaseCalculoCOFINS
        {
            get { return baseCalculoCOFINS; }
            set { baseCalculoCOFINS = value; }
        }
        private double pesoLiquido;

        public double PesoLiquido
        {
            get { return pesoLiquido; }
            set { pesoLiquido = value; }
        }
        private double taxaCambio;

        public double TaxaCambio
        {
            get { return taxaCambio; }
            set { taxaCambio = value; }
        }
        private double codigoMoeda;

        public double CodigoMoeda
        {
            get { return codigoMoeda; }
            set { codigoMoeda = value; }
        }
        private string codigoFINAMEFCC;

        public string CodigoFINAMEFCC
        {
            get { return codigoFINAMEFCC; }
            set { codigoFINAMEFCC = value; }
        }
        private string razaoSocialClienteFinalFCC;

        public string RazaoSocialClienteFinalFCC
        {
            get { return razaoSocialClienteFinalFCC; }
            set { razaoSocialClienteFinalFCC = value; }
        }
        private string cNPJClienteFinalFCC;

        public string CNPJClienteFinalFCC
        {
            get { return cNPJClienteFinalFCC; }
            set { cNPJClienteFinalFCC = value; }
        }

        public string InserirDados(Produto produtos)
        {
            string mensagemErro = "";
            try
            {
                string sql = "";
                sql += " INSERT INTO PRODUTOS ";
                sql += "  ( XML_ID,    NOMEFABRICANTE,    CNPJFABRICANTE,    CODIGONCM,    NOMEPRODUTO,    MODELO,    TIPOPRODUTO,    TIPOPRODUCAOPPB,    PRECOAQUISICAOTERCEIRIZADAPPB,    PRECOVENDACOMIMPOSTOS, ";
                sql += "    BASECALCULO,    PERCENTUALIPI,    PERCENTUALICMS,    PERCENTUALPIS,    PERCENTUALCOFINS,    BASECALCULOPIS,    BASECALCULOCOFINS,    PESOLIQUIDO,    TAXACAMBIO,    CODIGOMOEDA, ";
                sql += "    CODIGOFINAMEFCC,    RAZAOSOCIALCLIENTEFINALFCC,    CNPJCLIENTEFINALFCC  ) ";
                sql += "VALUES  (";
                sql += " " + produtos.XMLID + ",";
                sql += " '" + produtos.nomeFabricante + "',";
                sql += " '" + produtos.cNPJFabricante.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0,14) + "',";
                sql += " '" + produtos.codigoNcm + "',";
                sql += " '" + produtos.nomeProduto + "',";
                sql += " '" + produtos.modelo + "',";
                sql += " '" + produtos.tipoProduto + "',";
                sql += " '" + produtos.tipoProducaoPPB + "',";
                sql += " " + produtos.precoAquisicaoTerceirizadaPPB.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.precoVendaComImpostos.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.baseCalculo.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.percentualIPI.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.percentualICMS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.percentualPIS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.percentualCOFINS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.baseCalculoPIS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.baseCalculoCOFINS.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.pesoLiquido.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.taxaCambio.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " " + produtos.codigoMoeda.ToString().Replace(".", "").Replace(",", ".") + ",";
                sql += " '" + produtos.codigoFINAMEFCC + "',";
                sql += " '" + produtos.razaoSocialClienteFinalFCC + "',";
                sql += " '" + produtos.cNPJClienteFinalFCC + "'";
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
                mensagemErro = mensagemErro + "Produto = Code: " + ex.ErrorCode + "\n" +
                                              "Message: " + ex.Message + "\n";
            }
            return mensagemErro;
        }
    }
}