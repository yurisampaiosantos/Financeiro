using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Security;
using System.Data.OleDb;
using System.Data;
/// <summary>
/// Summary description for Dados
/// </summary>
public class Process
{
    public Process()
	{
	}
    public static string StringDeConexao
    {
        get
        {
        //DEV
           // return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EEP_FINANCE;Password=eep_financeSAeep$dev";
        //PROD
            return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_EGDOC;Password=FuncEnsA14";
            //return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=TCG;Password=OraEsnTCG";
        }
    }
    public void InserirBarcode(string barcode, string criadoPor, Int32 paginas)
    {
        if (!VerificarExistenciaBarcode(barcode))
        {
            //insert
            string sql;
            sql = "";
            sql += "INSERT INTO EGEDOC.GEDOC_BARCODE_SCAN  (  BARCODE,  PAGINA, CRIADO_POR ,  DIRETORIO  ) ";
            sql += "  VALUES ('" + barcode + "'," + paginas + ",'" + criadoPor + "', 'E:\\Arquivos\\GEDOC\\NF_ENT\\ENSEADA\\" + DateTime.Now.Date.ToString("yyyy") + "\\" + DateTime.Now.Date.ToString("yyyy-MM") + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\\" + barcode + ".pdf')";

            OleDbConnection con = new OleDbConnection(Process.StringDeConexao);
            try
            {
                OleDbCommand comando = new OleDbCommand(sql, con);
                con.Open();
                int count = comando.ExecuteNonQuery();
                con.Close();
            }
            catch { }
        }
        else
        {
            //Update
            string sql;
            sql = "";
            sql += "UPDATE EGEDOC.GEDOC_BARCODE_SCAN SET DIRETORIO = 'E:\\Arquivos\\GEDOC\\NF_ENT\\ENSEADA\\" + DateTime.Now.Date.ToString("yyyy") + "\\" + DateTime.Now.Date.ToString("yyyy-MM") + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\\" + barcode + ".pdf' ";
            sql += ", MODIFICADO_POR =  '" + criadoPor + "' ";
            sql += ", PAGINA =  " + paginas + " ";
            sql += "WHERE BARCODE =  '" + barcode + "'";

            OleDbConnection con = new OleDbConnection(Process.StringDeConexao);
            try
            {
                OleDbCommand comando = new OleDbCommand(sql, con);
                con.Open();
                int count = comando.ExecuteNonQuery();
                con.Close();
            }
            catch { }
        }
    }


    public void InserirContratoBarcode(string barcode, string criadoPor, Int32 paginas)
    {
        if (!VerificarExistenciaContratoBarcode(barcode))
        {
            //insert
            string sql;
            sql = "";
            sql += "INSERT INTO EGEDOC.SC_BARCODE_SCAN  (  BARCODE,  PAGINA, CRIADO_POR ,  DIRETORIO  ) ";
            sql += "  VALUES ('" + barcode + "'," + paginas + ",'" + criadoPor + "', 'E:\\Arquivos\\GEDOC\\NF_ENT\\ENSEADA\\" + DateTime.Now.Date.ToString("yyyy") + "\\" + DateTime.Now.Date.ToString("yyyy-MM") + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\\" + barcode + ".pdf')";

            OleDbConnection con = new OleDbConnection(Process.StringDeConexao);
            try
            {
                OleDbCommand comando = new OleDbCommand(sql, con);
                con.Open();
                int count = comando.ExecuteNonQuery();
                con.Close();
            }
            catch { }
        }
        else
        {
            //Update
            string sql;
            sql = "";
            sql += "UPDATE EGEDOC.SC_BARCODE_SCAN SET DIRETORIO = 'E:\\Arquivos\\GEDOC\\NF_ENT\\ENSEADA\\" + DateTime.Now.Date.ToString("yyyy") + "\\" + DateTime.Now.Date.ToString("yyyy-MM") + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\\" + barcode + ".pdf' ";
            sql += ", MODIFICADO_POR =  '" + criadoPor + "' ";
            sql += ", PAGINA =  " + paginas + " ";
            sql += "WHERE BARCODE =  '" + barcode + "'";

            OleDbConnection con = new OleDbConnection(Process.StringDeConexao);
            try
            {
                OleDbCommand comando = new OleDbCommand(sql, con);
                con.Open();
                int count = comando.ExecuteNonQuery();
                con.Close();
            }
            catch { }
        }
    }
    private bool VerificarExistenciaBarcode(string barcode)
    {
        bool resultado = false;
        //select
        string sql;
        sql = "";
        sql += "SELECT DIRETORIO FROM EGEDOC.GEDOC_BARCODE_SCAN WHERE BARCODE = '" + barcode + "'";


        OleDbConnection con = new OleDbConnection(Process.StringDeConexao);
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        
        using (con)
        {
            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                try
                {
                    FileInfo infoArquivo = new FileInfo(Convert.ToString(reader["DIRETORIO"]));
                    if (infoArquivo.Exists)
                    {
                        infoArquivo.Delete();
                    }
                }
                catch { }

                resultado = true;
            }
            con.Close();            
        }
        return resultado;
    }

    private bool VerificarExistenciaContratoBarcode(string barcode)
    {
        bool resultado = false;
        //select
        string sql;
        sql = "";
        sql += "SELECT DIRETORIO FROM EGEDOC.SC_BARCODE_SCAN WHERE BARCODE = '" + barcode + "'";


        OleDbConnection con = new OleDbConnection(Process.StringDeConexao);
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.CommandType = CommandType.Text;

        using (con)
        {
            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                try
                {
                    FileInfo infoArquivo = new FileInfo(Convert.ToString(reader["DIRETORIO"]));
                    if (infoArquivo.Exists)
                    {
                        infoArquivo.Delete();
                    }
                }
                catch { }

                resultado = true;
            }
            con.Close();
        }
        return resultado;
    }
}