using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceGDOC
{
    public class AnexoDocumentoImportacao
    {
        //DEV
        //private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EEP_FINANCE;Password=eep_financeSAeep$dev";
        //PROD
        private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_EGDOC;Password=FuncEnsA14";
            //"Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=TCG;Password=OraEsnTCG";
                
        private decimal _id;

        public decimal Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private decimal _documentoImportacaoId;

        public decimal DocumentoImportacaoId
        {
            get { return _documentoImportacaoId; }
            set { _documentoImportacaoId = value; }
        }
        private string _nomeArquivo;

        public string NomeArquivo
        {
            get { return _nomeArquivo; }
            set { _nomeArquivo = value; }
        }
       
        private string _diretorio;

        public string Diretorio
        {
            get { return _diretorio; }
            set { _diretorio = value; }
        }
        private byte[] _anexo;

        public byte[] Anexo
        {
            get { return _anexo; }
            set { _anexo = value; }
        }
        //referente ao contrato
        public void SelecionarAnexoDocumentoImportacao(decimal anexoId)
        {
            string sql = "";
            sql += " SELECT ID,  DOCUMENTO_IMPORTACAO_ID, BLOB_CONTENT, DIRETORIO, FILENAME";
            sql += " FROM EGEDOC.GEDOC_DOCUMENTO_IMPORT_ANEXO";
            sql += " WHERE ID = " + anexoId;
            try
            {
                using (OleDbConnection conn = new OleDbConnection(StringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            if (dataReader.Read())
                            {
                                Id = (decimal)dataReader["ID"];
                                DocumentoImportacaoId = (decimal)dataReader["DOCUMENTO_IMPORTACAO_ID"];
                                NomeArquivo = (string)dataReader["FILENAME"];
                                if (dataReader["DIRETORIO"] != DBNull.Value)
                                {
                                    Diretorio = (string)dataReader["DIRETORIO"];
                                }
                                if (dataReader["BLOB_CONTENT"] != DBNull.Value)
                                {
                                    Anexo = (Byte[])dataReader["BLOB_CONTENT"];
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
        }
        public void AtualizarAnexoDocumentoImportacao(decimal anexoId, string diretorio)
        {
            string sql = "";
            sql += " UPDATE EGEDOC.GEDOC_DOCUMENTO_IMPORT_ANEXO SET  ";
            sql += " BLOB_CONTENT = NULL ,";
            sql += " DIRETORIO = '" + diretorio + "'";
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