using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace GedocDownload
{
    public class Download
    {
        //DEV
        //private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EGEDOC;Password=dOCdEV$";
        //PROD
        // private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_EGDOC;Password=FuncEnsA14";
        private static string StringDeConexao = "User Id=F_APP_EGDOC;Password=FuncEnsA14;Data Source=LDCRAC2-SCAN.intranet.local/CRP01.intranet.local";
        public OracleConnection getConn()
        {
            return new OracleConnection(StringDeConexao);
        }

        private string _diretorioPDF;

        public string DiretorioPDF
        {
            get { return _diretorioPDF; }
            set { _diretorioPDF = value; }
        }

        private string _diretorioXML;

        public string DiretorioXML
        {
            get { return _diretorioXML; }
            set { _diretorioXML = value; }
        }
        public void VerificarConexao()
        {
            string sql = "";
            sql += " SELECT DIRETORIO ";
            sql += " FROM EGEDOC.GEDOC_BARCODE_SCAN";
            sql += " WHERE rownum = 1";

            try
            {
                OracleConnection oc = getConn();
                oc.Open();
                OracleDataAdapter da = new OracleDataAdapter(sql, oc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                oc.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco");
            }
        }
        public string DownloadPDF(string barcode)
        {
            string diretorio = "";

            string sql = "";
            sql += " SELECT DIRETORIO ";
            sql += " FROM EGEDOC.GEDOC_BARCODE_SCAN";
            sql += " WHERE BARCODE = '"+barcode+"'";

            try
            {
                OracleConnection oc = getConn();
                oc.Open();
                OracleDataAdapter da = new OracleDataAdapter(sql, oc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                oc.Close();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (r["DIRETORIO"].ToString() != "")
                    {
                        diretorio = (string)r["DIRETORIO"];
                        diretorio = diretorio.Replace("E:\\Arquivos\\GEDOC\\", @"\\wdciis03\gedoc_arquivo$\");
                    }
                }

                if (diretorio != "")
                {
                    if (!System.IO.File.Exists(diretorio))
                    {
                        diretorio = "";
                    }
                }
            }
            catch (Exception ex)
            {
                diretorio = "";
            }
            return diretorio;
        }
        public string DownloadXML(string chaveAcesso)
        {
            string diretorio = "";

            string sql = "";
            sql += " SELECT DIRETORIO ";
            sql += " FROM EGEDOC.GEDOC_XML";
            sql += " WHERE CHAVE_ACESSO = '" + chaveAcesso + "'";

            try
            {
                OracleConnection oc = getConn();
                oc.Open();
                OracleDataAdapter da = new OracleDataAdapter(sql, oc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                oc.Close();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (r["DIRETORIO"].ToString() != "")
                    {
                        diretorio = (string)r["DIRETORIO"];
                        diretorio = diretorio.Replace("E:\\Arquivos\\GEDOC\\",@"\\wdciis03\gedoc_arquivo$\");
                    }
                }

                if (diretorio != "")
                {
                    if (!System.IO.File.Exists(diretorio))
                    {
                        diretorio = "";
                    }
                }
            }
            catch (Exception ex)
            {
                diretorio = "";
            }
            return diretorio;
        }
     
    }
}
