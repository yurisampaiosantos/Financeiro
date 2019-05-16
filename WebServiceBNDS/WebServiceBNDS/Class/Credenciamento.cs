using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceBNDS
{
    public class Credenciamento
    {
        private double xMLID;

        public double XMLID
        {
            get { return xMLID; }
            set { xMLID = value; }
        }

        private string responsavel;

        public string Responsavel
        {
            get { return responsavel; }
            set { responsavel = value; }
        }
        private string cargo;

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        private string endereco;

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string versao;

        public string Versao
        {
            get { return versao; }
            set { versao = value; }
        }

        public string InserirDados(Credenciamento credenciamento)
        {
            string mensagemErro = "";
            try
            {
                string sql = "";
                sql += " INSERT INTO CREDENCIAMENTO_PRODUTOS_CFI  ";
                sql += " ( XML_ID,  RESPONSAVEL,  CARGO,  ENDERECO,  TELEFONE,  EMAIL,  VERSAO ) ";
                sql += "VALUES  (";
                sql += " " + credenciamento.XMLID + ",";
                sql += " '" + credenciamento.Responsavel + "',";
                sql += " '" + credenciamento.Cargo + "',";
                sql += " '" + credenciamento.Endereco + "',";
                sql += " '" + credenciamento.Telefone + "',";
                sql += " '" + credenciamento.Email + "',";
                sql += " '" + credenciamento.Versao + "'";
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
                mensagemErro = mensagemErro + "Credenciamento = Code: " + ex.ErrorCode + "\n" +
                                              "Message: " + ex.Message +"\n";
            }
            return mensagemErro;
        }


    }
}