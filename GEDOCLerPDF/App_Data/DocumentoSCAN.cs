using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using iTextSharp.text.pdf;

namespace GEDOCLerPDF
{
    public class DocumentoSCAN
    {
        //DEV
        //private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EGEDOC;Password=dOCdEV$";
        //PROD
        private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_EGDOC;Password=FuncEnsA14";
            
                
        private decimal _id;

        public decimal Id
        {
            get { return _id; }
            set { _id = value; }
        }

       
        private string _diretorio;

        public string Diretorio
        {
            get { return _diretorio; }
            set { _diretorio = value; }
        }
        public void LerPDF()
        {
            List<DocumentoSCAN> listaDocumentoSCAN = new List<DocumentoSCAN>();
            listaDocumentoSCAN = ListarAnexoDocumento();
            foreach (DocumentoSCAN anexo in listaDocumentoSCAN)
            {
                try
                {
                    using (PdfReader leitor = new PdfReader(anexo.Diretorio))
                    {
                        AtualizarPagina(anexo.Id, leitor.NumberOfPages);
                    }
                }
                catch
                {
                    AtualizarPagina(anexo.Id, 0);
                }
            }

            listaDocumentoSCAN = ListarAnexoDocumentoContrato();
            foreach (DocumentoSCAN anexo in listaDocumentoSCAN)
            {
                try
                {
                    using (PdfReader leitor = new PdfReader(anexo.Diretorio))
                    {
                        AtualizarContratoPagina(anexo.Id, leitor.NumberOfPages);
                    }
                }
                catch
                {
                    AtualizarContratoPagina(anexo.Id, 0);
                }
            }
           
        }
        private List<DocumentoSCAN> ListarAnexoDocumento()
        {
            string sql = "";
            sql += " SELECT ID,  DIRETORIO";
            sql += " FROM EGEDOC.GEDOC_BARCODE_SCAN";
            sql += " WHERE LIDO IS NULL ";

            List<DocumentoSCAN> listaDocumentoSCAN = new List<DocumentoSCAN>();            

            try
            {
                using (OleDbConnection conn = new OleDbConnection(StringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            while (dataReader.Read())
                            {
                                DocumentoSCAN documentoSCAN = new DocumentoSCAN();
                                documentoSCAN.Id = (decimal)dataReader["ID"];
                                if (dataReader["DIRETORIO"] != DBNull.Value)
                                {
                                    documentoSCAN.Diretorio = (string)dataReader["DIRETORIO"];
                                }

                                if (documentoSCAN.Diretorio != "" && documentoSCAN.Diretorio != null)
                                {
                                    listaDocumentoSCAN.Add(documentoSCAN);
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return listaDocumentoSCAN;
        }

        private List<DocumentoSCAN> ListarAnexoDocumentoContrato()
        {
            string sql = "";
            sql += " SELECT ID,  DIRETORIO";
            sql += " FROM EGEDOC.SC_BARCODE_SCAN";
            sql += " WHERE LIDO IS NULL ";

            List<DocumentoSCAN> listaDocumentoSCAN = new List<DocumentoSCAN>();

            try
            {
                using (OleDbConnection conn = new OleDbConnection(StringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            while (dataReader.Read())
                            {
                                DocumentoSCAN documentoSCAN = new DocumentoSCAN();
                                documentoSCAN.Id = (decimal)dataReader["ID"];
                                if (dataReader["DIRETORIO"] != DBNull.Value)
                                {
                                    documentoSCAN.Diretorio = (string)dataReader["DIRETORIO"];
                                }

                                if (documentoSCAN.Diretorio != "" && documentoSCAN.Diretorio != null)
                                {
                                    listaDocumentoSCAN.Add(documentoSCAN);
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return listaDocumentoSCAN;
        }
        private void AtualizarPagina(decimal anexoId, decimal pagina)
        {
            string sql = "";
            sql += " UPDATE EGEDOC.GEDOC_BARCODE_SCAN SET  ";
            sql += " PAGINA = " + pagina ;
            sql += " ,LIDO = 1";
            sql += " WHERE ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private void AtualizarContratoPagina(decimal anexoId, decimal pagina)
        {
            string sql = "";
            sql += " UPDATE EGEDOC.SC_BARCODE_SCAN SET  ";
            sql += " PAGINA = " + pagina;
            sql += " ,LIDO = 1";
            sql += " WHERE ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}