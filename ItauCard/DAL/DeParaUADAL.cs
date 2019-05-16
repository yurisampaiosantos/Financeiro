using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class DeParaUADAL
    {
        public string CentroCusto(string ua)
        {
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            ObjetoItauCardDAL objetoItauCardDAL = new ObjetoItauCardDAL();
            MOD.ObjetoItauCard objetoItauCard = new MOD.ObjetoItauCard();

            string sql = null;
            string resultado = "";

            connection = new OleDbConnection(Dados.StringDeConexao);
            sql = "SELECT PARA ";
            sql += "FROM eep_finance.ITAUCARD_DE_PARA a ";
            sql += "WHERE replace(replace(de,'.',''),'-','')  = '" + ua + "' ";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    resultado = Convert.ToString(reader[0]);                 
                    
                }
            
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return resultado;
        }
    }
}
