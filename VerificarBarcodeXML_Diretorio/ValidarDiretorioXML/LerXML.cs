using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.IO;

namespace ValidarDiretorioXML
{
    public class LerXML
    {
        //DEV
        //private string stringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EEP_FINANCE;Password=eep_financeSAeep$dev";
        //PROD
        private static string stringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_EGDOC;Password=FuncEnsA14";


        public List<XML> SelecionaXML()
        {
            List<XML> listResultadoXML = new List<XML>();
            try
            {
                string sql;
                sql = "";
                sql += "  SELECT ID , DIRETORIO from EGDOC.GEDOC_XML WHERE DIRETORIO IS NOT NULL";   

                using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            while (dataReader.Read())
                            {
                                XML resultadoXML = new XML();
                                if (dataReader["ID"] != DBNull.Value)
                                    resultadoXML.ID = (decimal)dataReader["ID"];
                                if (dataReader["DIRETORIO"] != DBNull.Value)
                                    resultadoXML.Diretorio = (string)dataReader["DIRETORIO"];
                                listResultadoXML.Add(resultadoXML);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                StreamWriter vWriter = new StreamWriter(@"c:\temp\XMLerro.txt", true);
                vWriter.WriteLine("erro");
                vWriter.Flush();
                vWriter.Close();
            }
            return listResultadoXML;
        }
        public List<XML> SelecionaXMLSAP()
        {
            List<XML> listResultadoXML = new List<XML>();
            try
            {
                string sql;
                sql = "";
                sql += "  SELECT ID , DIRETORIO from EGDOC.GEDOC_XML_SAP WHERE DIRETORIO IS NOT NULL";

                using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            while (dataReader.Read())
                            {
                                XML resultadoXML = new XML();
                                if (dataReader["ID"] != DBNull.Value)
                                    resultadoXML.ID = (decimal)dataReader["ID"];
                                if (dataReader["DIRETORIO"] != DBNull.Value)
                                    resultadoXML.Diretorio = (string)dataReader["DIRETORIO"];
                                listResultadoXML.Add(resultadoXML);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return listResultadoXML;
        }
        public void UpdateXMLSAP(decimal id)
        {
            try
            {
                ///Metodo para Listar todos no banco
                ///                     

                string sql;
                sql = "";
                sql += "  UPDATE EGDOC.GEDOC_XML_SAP SET DIRETORIO = null ";
                sql += "  WHERE ID =" + id;

                
                // cmd.CommandType = CommandType.Text;
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);                    
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void UpdateXML(decimal id)
        {
            try
            {
                ///Metodo para Listar todos no banco
                ///                     

                string sql;
                sql = "";
                sql += "  UPDATE EGDOC.GEDOC_XML SET STATUS = null ";
                sql += "  WHERE ID =" + id;


                // cmd.CommandType = CommandType.Text;
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {

            }
        }

        //-----------------
        public List<XML> SelecionaBarcode()
        {
            List<XML> listResultadoXML = new List<XML>();
            try
            {
                string sql;
                sql = "";
                sql += "  SELECT ID , PATH from TCG.FILES WHERE PATH IS NOT NULL";

                using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            while (dataReader.Read())
                            {
                                XML resultadoXML = new XML();
                                if (dataReader["ID"] != DBNull.Value)
                                    resultadoXML.ID = (decimal)dataReader["ID"];
                                if (dataReader["PATH"] != DBNull.Value)
                                    resultadoXML.Diretorio = (string)dataReader["PATH"];
                                listResultadoXML.Add(resultadoXML);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                StreamWriter vWriter = new StreamWriter(@"c:\temp\XMLerro.txt", true);
                vWriter.WriteLine("erro");
                vWriter.Flush();
                vWriter.Close();
            }
            return listResultadoXML;
        }
        public void ExcluirBarcode(decimal id)
        {
            try
            {
                ///Metodo para Listar todos no banco
                ///                     

                string sql;
                sql = "";
                sql += "  DELETE TCG.FILES ";
                sql += "  WHERE ID =" + id;


                // cmd.CommandType = CommandType.Text;
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
