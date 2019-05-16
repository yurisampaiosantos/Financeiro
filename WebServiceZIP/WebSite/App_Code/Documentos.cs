using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

public class Documentos
{
    public static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_EGDOC;Password=FuncEnsA14";
                                     
    private string _diretorio;
    public string Diretorio
    {
        get { return _diretorio; }
        set { _diretorio = value; }
    }
    public List<Documentos> List(string codigos)
    {
        ///Metodo para Listar todos no banco
        ///
        string listPesquisa = "";
        string filtro = "";
        try
        {
            string[] listCodigos = codigos.Split(':');
            if (listCodigos.Count() <= 900)
            {
                for (int x = 1; x < (listCodigos.Count() - 1); x++)
                {
                    listPesquisa += listCodigos[x];
                    if (x + 1 < (listCodigos.Count() - 1))
                        listPesquisa += ",";
                }
                filtro = "  WHERE ID IN (" + listPesquisa + ")";
            }
            else
            {
                int cnt = 0;
                for (int x = 1; x < (listCodigos.Count() - 1); x++)
                {
                    listPesquisa += listCodigos[x];
                    if (cnt == x / 900)
                    {
                        if (x + 1 < (listCodigos.Count() - 1))
                            listPesquisa += ",";
                    }
                    if (cnt != x / 900)
                    {
                        if (cnt == 0)
                        {
                            filtro += "  WHERE ID IN (" + listPesquisa + ")";
                        }
                        else
                        {
                            filtro += "  OR ID IN (" + listPesquisa + ")";
                        }
                        cnt++;
                        listPesquisa = "";
                    }                    
                }
                filtro += "  OR ID IN (" + listPesquisa + ")";
            }
        }
        catch { }

        string sql;
        sql = "";
        sql += "  SELECT DIRETORIO FROM EGEDOC.VW_GEDOC_DOCUMENTO_ANEXO";
        sql += filtro; 


        OleDbConnection con = new OleDbConnection(StringDeConexao);
        OleDbCommand cmd = new OleDbCommand(sql, con);
        List<Documentos> resultListDocumentos = new List<Documentos>();
        cmd.CommandType = CommandType.Text;
        using (con)
        {
            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Documentos documentos = new Documentos();
                documentos.Diretorio = reader["DIRETORIO"].ToString();
                resultListDocumentos.Add(documentos);
            }

            con.Close();
            return resultListDocumentos;
        }
    }
    public List<Documentos> ListXML(string codigos)
    {
        ///Metodo para Listar todos no banco
        ///
        string listPesquisa = "";
        string filtro = "";
        try
        {
            string[] listCodigos = codigos.Split(':');
            if (listCodigos.Count() <= 900)
            {
                for (int x = 1; x < (listCodigos.Count() - 1); x++)
                {
                    listPesquisa += listCodigos[x];
                    if (x + 1 < (listCodigos.Count() - 1))
                        listPesquisa += ",";
                }
                filtro = "  WHERE ID IN (" + listPesquisa + ")";
            }
            else
            {
                int cnt = 0;
                for (int x = 1; x < (listCodigos.Count() - 1); x++)
                {
                    listPesquisa += listCodigos[x];
                    if (cnt == x / 900)
                    {
                        if (x + 1 < (listCodigos.Count() - 1))
                            listPesquisa += ",";
                    }
                    if (cnt != x / 900)
                    {
                        if (cnt == 0)
                        {
                            filtro += "  WHERE ID IN (" + listPesquisa + ")";
                        }
                        else
                        {
                            filtro += "  OR ID IN (" + listPesquisa + ")";
                        }
                        cnt++;
                        listPesquisa = "";
                    }
                }
                filtro += "  OR ID IN (" + listPesquisa + ")";
            }
        }
        catch { }

        string sql;
        sql = "";
        sql += "  SELECT DIRETORIO FROM EGEDOC.GEDOC_XML";
        sql += filtro;


        OleDbConnection con = new OleDbConnection(StringDeConexao);
        OleDbCommand cmd = new OleDbCommand(sql, con);
        List<Documentos> resultListDocumentos = new List<Documentos>();
        cmd.CommandType = CommandType.Text;
        using (con)
        {
            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Documentos documentos = new Documentos();
                documentos.Diretorio = reader["DIRETORIO"].ToString();
                resultListDocumentos.Add(documentos);
            }

            con.Close();
            return resultListDocumentos;
        }
    }
    public List<Documentos> ListXMLSAP(string codigos)
    {
        ///Metodo para Listar todos no banco
        ///
        string listPesquisa = "";
        string filtro = "";
        try
        {
            string[] listCodigos = codigos.Split(':');
            if (listCodigos.Count() <= 900)
            {
                for (int x = 1; x < (listCodigos.Count() - 1); x++)
                {
                    listPesquisa += listCodigos[x];
                    if (x + 1 < (listCodigos.Count() - 1))
                        listPesquisa += ",";
                }
                filtro = "  WHERE ID IN (" + listPesquisa + ")";
            }
            else
            {
                int cnt = 0;
                for (int x = 1; x < (listCodigos.Count() - 1); x++)
                {
                    listPesquisa += listCodigos[x];
                    if (cnt == x / 900)
                    {
                        if (x + 1 < (listCodigos.Count() - 1))
                            listPesquisa += ",";
                    }
                    if (cnt != x / 900)
                    {
                        if (cnt == 0)
                        {
                            filtro += "  WHERE ID IN (" + listPesquisa + ")";
                        }
                        else
                        {
                            filtro += "  OR ID IN (" + listPesquisa + ")";
                        }
                        cnt++;
                        listPesquisa = "";
                    }
                }
                filtro += "  OR ID IN (" + listPesquisa + ")";
            }
        }
        catch { }

        string sql;
        sql = "";
        sql += "  SELECT DIRETORIO FROM EGEDOC.GEDOC_XML";
        sql += filtro;


        OleDbConnection con = new OleDbConnection(StringDeConexao);
        OleDbCommand cmd = new OleDbCommand(sql, con);
        List<Documentos> resultListDocumentos = new List<Documentos>();
        cmd.CommandType = CommandType.Text;
        using (con)
        {
            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Documentos documentos = new Documentos();
                documentos.Diretorio = reader["DIRETORIO"].ToString();
                resultListDocumentos.Add(documentos);
            }

            con.Close();
            return resultListDocumentos;
        }
    }
    public void EnviarEmail(string login, string diretorio)
    {
        OleDbConnection con = new OleDbConnection(StringDeConexao);
        try
        {
            OleDbCommand comando = new OleDbCommand()
            {
                CommandText = "EGEDOC.PKG_TOOLS.PRC_SEND_MAIL_LINK",
                Connection = con,
                CommandType = CommandType.StoredProcedure,
            };
            comando.Parameters.Add(":P_LOGIN_INTEGRANTE", OleDbType.VarChar).Value = login;
            comando.Parameters.Add(":P_LINK", OleDbType.VarChar).Value = diretorio;
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
        }
        catch
        {
        }
        finally
        {
            con.Close();
        }
    }
}
