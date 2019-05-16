using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class ObjetoItauCardDAL
    {
        public void Inserir(MOD.ObjetoItauCard objetoItauCard)
        {
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql = "insert into eep_finance.ItauCard (SEQ_ID,Autorizacao, CiaAerea, ClasseServico, Dataemissao, DataVoo, Localizador,";
            sql += "NumBilhete, NumeroCartao, Passageiro, PercEconCheiaAcordo, PercEconCheiaVendida, PercEconomiaEfetiva,";
            sql += "Solicitante, Status, TariaAcordo, TarifaCheia, TarifaLiquida, TarifaPromocional, TarifaVendida,";
            sql += "TaxaEmbarque, TipoEmissao, Total, Trechos, UAUnidAcomp, UEUnidEmpr, VctoFatura) ";

            sql += " values( ";

            if (objetoItauCard.SeqId != null && objetoItauCard.SeqId != 0)
                try
                {
                    sql += objetoItauCard.SeqId.ToString() + ",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.Autorizacao != null && objetoItauCard.Autorizacao != "")
                try
                {
                    sql += Convert.ToDecimal(objetoItauCard.Autorizacao).ToString().Replace(",",".") +",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.CiaAerea != null && objetoItauCard.CiaAerea != "")
                sql += "'" + objetoItauCard.CiaAerea + "',";
            else
                sql += "null,";

            if (objetoItauCard.ClasseServico != null && objetoItauCard.ClasseServico != "")
                sql += "'" + objetoItauCard.ClasseServico + "',";
            else
                sql += "null,";

            if (objetoItauCard.Dataemissao != null && objetoItauCard.Dataemissao != "")
                sql += "'" + objetoItauCard.Dataemissao + "',";
            else
                sql += "null,";

            if (objetoItauCard.DataVoo != null && objetoItauCard.DataVoo != "")
                sql += "'" + objetoItauCard.DataVoo + "',";
            else
                sql += "null,";

            if (objetoItauCard.Localizador != null && objetoItauCard.Localizador != "")
                sql += "'" + objetoItauCard.Localizador + "',";
            else
                sql += "null,";

            if (objetoItauCard.NumBilhete != null && objetoItauCard.NumBilhete != "")
                sql += "'" + objetoItauCard.NumBilhete + "',";
            else
                sql += "null,";

            if (objetoItauCard.NumeroCartao != null && objetoItauCard.NumeroCartao != "")
                              try
                {
                    sql += Convert.ToDecimal(objetoItauCard.NumeroCartao).ToString().Replace(",",".") +",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.Passageiro != null && objetoItauCard.Passageiro != "")
                sql += "'" + objetoItauCard.Passageiro + "',";
            else
                sql += "null,";

            if (objetoItauCard.PercEconCheiaAcordo != null && objetoItauCard.PercEconCheiaAcordo != "")
                sql += "'" + objetoItauCard.PercEconCheiaAcordo + "',";
            else
                sql += "null,";

            if (objetoItauCard.PercEconCheiaVendida != null && objetoItauCard.PercEconCheiaVendida != "")
                sql += "'" + objetoItauCard.PercEconCheiaVendida + "',";
            else
                sql += "null,";

            if (objetoItauCard.PercEconomiaEfetiva != null && objetoItauCard.PercEconomiaEfetiva != "")
                sql += "'" + objetoItauCard.PercEconomiaEfetiva + "',";
            else
                sql += "null,";

            if (objetoItauCard.Solicitante != null && objetoItauCard.Solicitante != "")
                sql += "'" + objetoItauCard.Solicitante + "',";
            else
                sql += "null,";

            if (objetoItauCard.Status != null && objetoItauCard.Status != "")
                sql += "'" + objetoItauCard.Status + "',";
            else
                sql += "null,";

            if (objetoItauCard.TariaAcordo != null && objetoItauCard.TariaAcordo != "")
                                try
                {
                    sql += Convert.ToDecimal(objetoItauCard.TariaAcordo).ToString().Replace(",",".") +",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.TarifaCheia != null && objetoItauCard.TarifaCheia != "")
                                try
                {
                    sql += Convert.ToDecimal(objetoItauCard.TarifaCheia).ToString().Replace(",",".") +",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.TarifaLiquida != null && objetoItauCard.TarifaLiquida != "")
                                try
                {
                    sql += Convert.ToDecimal(objetoItauCard.TarifaLiquida).ToString().Replace(",",".") +",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.TarifaPromocional != null && objetoItauCard.TarifaPromocional != "")
                                try
                {
                    sql += Convert.ToDecimal(objetoItauCard.TarifaPromocional).ToString().Replace(",",".") +",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.TarifaVendida != null && objetoItauCard.TarifaVendida != "")
                                try
                {
                    sql += Convert.ToDecimal(objetoItauCard.TarifaVendida).ToString().Replace(",",".") +",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.TaxaEmbarque != null && objetoItauCard.TaxaEmbarque != "")
                                try
                {
                    sql += Convert.ToDecimal(objetoItauCard.TaxaEmbarque).ToString().Replace(",",".") +",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.TipoEmissao != null && objetoItauCard.TipoEmissao != "")
                sql += "'" + objetoItauCard.TipoEmissao + "',";
            else
                sql += "null,";

            if (objetoItauCard.Total != null && objetoItauCard.Total != "")
                                try
                {
                    sql += Convert.ToDecimal(objetoItauCard.Total).ToString().Replace(",",".") +",";
                }
                catch { sql += "null,"; }
            else
                sql += "null,";

            if (objetoItauCard.Trechos != null && objetoItauCard.Trechos != "")
                sql += "'" + objetoItauCard.Trechos + "',";
            else
                sql += "null,";

            if (objetoItauCard.UAUnidAcomp != null && objetoItauCard.UAUnidAcomp != "")
                sql += "'" + objetoItauCard.UAUnidAcomp + "',";
            else
                sql += "null,";
            if (objetoItauCard.UEUnidEmpr != null && objetoItauCard.UEUnidEmpr != "")
                                try
                {
                    sql += Convert.ToDecimal(objetoItauCard.UEUnidEmpr).ToString().Replace(",", ".") + ",";
                }
                                catch { sql += "null,"; }
            else
                sql += "null,";
            if (objetoItauCard.VctoFatura != null && objetoItauCard.VctoFatura != "")
                sql += "'" + objetoItauCard.VctoFatura + "'";
            else
                sql += "null";

            sql += ")";
            try
            {
                connection.Open();
                oledbAdapter.InsertCommand = new OleDbCommand(sql, connection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }
        public decimal Encargos(decimal seqId)
        {
            decimal total = 0;

            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql = "SELECT SUM(TOTAL) FROM eep_finance.ItauCard ";
            sql += "WHERE STATUS = 'D' ";
            sql += "AND NumBilhete = 'DESPESAS' ";
            sql += "AND SEQ_ID = " + seqId + " ";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    total = Convert.ToDecimal(reader[0]);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            return total;
        }
        public decimal Credito(decimal seqId)
        {
            decimal total = 0;

            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql = "SELECT SUM(TOTAL) FROM eep_finance.ItauCard ";
            sql += "WHERE STATUS = 'C' ";
            sql += "AND ( UAUNIDACOMP is not null or NumBilhete IN ('CRÉDITO','CREDITO','CR¿DITO') )";
            sql += "AND SEQ_ID = " + seqId + " ";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    total = Convert.ToDecimal(reader[0]);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            return total;
        }
        public decimal Debito(decimal seqId)
        {
            decimal total = 0;
                       
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql = "SELECT SUM(TOTAL) FROM eep_finance.ItauCard ";
            sql += "WHERE STATUS = 'D' ";
            sql += "AND (UAUNIDACOMP is not null OR nvl(NumBilhete,1) NOT IN ('INDEVIDO','CRÉDITO','CREDITO','CR¿DITO'))";        
            sql += "AND SEQ_ID = " + seqId + " ";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    total = Convert.ToDecimal(reader[0]);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            return total;
        }
        public decimal Total(decimal seqId)
        {
            decimal total = 0;

            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql += "SELECT ";
            sql += "(SELECT SUM(TOTAL) FROM eep_finance.ItauCard ";
            sql += "WHERE STATUS = 'D' ";
            sql += "AND (UAUNIDACOMP is not null OR nvl(NumBilhete,1) NOT IN ('INDEVIDO','CRÉDITO','CREDITO','CR¿DITO')) ";
            sql += "AND SEQ_ID = " + seqId + ") ";
            sql += " - ";
            sql += "NVL((SELECT SUM(TOTAL) FROM eep_finance.ItauCard ";
            sql += "WHERE STATUS = 'C' ";
            sql += "AND (UAUNIDACOMP is not null or NumBilhete IN ('CRÉDITO','CREDITO','CR¿DITO')) ";
            sql += "AND SEQ_ID = " + seqId + "),0) ";
            sql += "FROM DUAL "; 
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    total = Convert.ToDecimal(reader[0]);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            return total;
        }
       /* public decimal RateioCredito(decimal seqId)
        {
            decimal total = 0;

            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql += "SELECT SUM(TOTAL) ";
            sql += "FROM eep_finance.ItauCard a  ";
            sql += "WHERE a.STATUS = 'C' ";
            sql += "AND NOT EXISTS (SELECT ID FROM eep_finance.ItauCard b WHERE b.STATUS = 'D' AND a.UAUNIDACOMP = b.UAUNIDACOMP AND a.SEQ_ID = b.SEQ_ID) ";
            sql += "AND SEQ_ID = " + seqId + " ";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    total = Convert.ToDecimal(reader[0]);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            return total;
        }*/
    /*    public decimal RateioDebito(decimal seqId)
        {
            decimal total = 0;

            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql = "SELECT nvl(a.UAUNIDACOMP,0), SUM(a.TOTAL) - ";
            sql += "NVL((SELECT SUM(b.TOTAL) FROM eep_finance.ItauCard b WHERE b.STATUS = 'C' AND a.UAUNIDACOMP = b.UAUNIDACOMP AND a.SEQ_ID = b.SEQ_ID),0) as TotalC ";
            sql += "FROM eep_finance.ItauCard a ";
            sql += "WHERE a.STATUS = 'D' ";
            sql += "AND a.UAUNIDACOMP is null ";
            sql += "AND SEQ_ID = " + seqId + " ";
            sql += "Group BY a.SEQ_ID,a.UAUNIDACOMP ";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    total = Convert.ToDecimal(reader[1]);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            return total;
        }*/
        public decimal Sequencia()
        {
            decimal total = 0;

            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql = "SELECT eep_finance.ITAUCARD_SEQ_ID.nextval FROM DUAL ";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    total = Convert.ToDecimal(reader[0]);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            return total;
        }
        public MOD.ObjetoItauCard Listagem(decimal seqId)
        {            
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            MOD.ObjetoItauCard objetoItauCard = new MOD.ObjetoItauCard();
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql = "SELECT Autorizacao, CiaAerea, ClasseServico, Dataemissao, DataVoo, Localizador,";
            sql += "NumBilhete, NumeroCartao, Passageiro, PercEconCheiaAcordo, PercEconCheiaVendida, PercEconomiaEfetiva,";
            sql += "Solicitante, Status, TariaAcordo, TarifaCheia, TarifaLiquida, TarifaPromocional, TarifaVendida,";
            sql += "TaxaEmbarque, TipoEmissao, Total, Trechos, UAUnidAcomp, UEUnidEmpr, VctoFatura FROM eep_finance.ItauCard ";
            sql += "where rownum = 1 ";
            sql += "AND SEQ_ID = " + seqId + " ";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {                   

                    objetoItauCard.Autorizacao = Convert.ToString(reader[0]);
                    objetoItauCard.CiaAerea = Convert.ToString(reader[1]);
                    objetoItauCard.ClasseServico = Convert.ToString(reader[2]);
                    objetoItauCard.Dataemissao = Convert.ToString(reader[3]);
                    objetoItauCard.DataVoo = Convert.ToString(reader[4]);
                    objetoItauCard.Localizador = Convert.ToString(reader[5]);
                    objetoItauCard.NumBilhete = Convert.ToString(reader[6]);
                    objetoItauCard.NumeroCartao = Convert.ToString(reader[7]);
                    objetoItauCard.Passageiro = Convert.ToString(reader[8]);
                    objetoItauCard.PercEconCheiaAcordo = Convert.ToString(reader[9]);
                    objetoItauCard.PercEconCheiaVendida = Convert.ToString(reader[10]);
                    objetoItauCard.PercEconomiaEfetiva = Convert.ToString(reader[11]);
                    objetoItauCard.Solicitante = Convert.ToString(reader[12]);
                    objetoItauCard.Status = Convert.ToString(reader[13]);
                    objetoItauCard.TariaAcordo = Convert.ToString(reader[14]);
                    objetoItauCard.TarifaCheia = Convert.ToString(reader[15]);
                    objetoItauCard.TarifaLiquida = Convert.ToString(reader[16]);
                    objetoItauCard.TarifaPromocional = Convert.ToString(reader[17]);
                    objetoItauCard.TarifaVendida = Convert.ToString(reader[18]);
                    objetoItauCard.TaxaEmbarque = Convert.ToString(reader[19]);
                    objetoItauCard.TipoEmissao = Convert.ToString(reader[20]);
                    objetoItauCard.Total = Convert.ToString(reader[21]);
                    objetoItauCard.Trechos = Convert.ToString(reader[22]);
                    objetoItauCard.UAUnidAcomp = Convert.ToString(reader[23]);
                    objetoItauCard.UEUnidEmpr = Convert.ToString(reader[24]);
                    objetoItauCard.VctoFatura = Convert.ToString(reader[25]);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return objetoItauCard;
        }
        public bool Pep(string pep)
        {
            bool resultado = false;

            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql += "SELECT 1 ";
            sql += "FROM sap_fi.Z_PEP_ELEMENT a  ";
            sql += "WHERE a.VBUKR = 1000 ";
            sql += "AND a.PROJ_STATUS = 0 ";
            sql += "AND a.BELKZ = 'X' ";
            sql += "AND PSPID = '" + pep + "'";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    resultado = true;
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }

            return resultado;
        }
        public bool CentroCusto(string centroCusto)
        {
            bool resultado = false;

            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql += "SELECT 1 ";
            sql += "FROM sap_fi.Z_COST_CENTER  a  ";
            sql += "WHERE a.BUKRS = 1000 ";
            sql += "AND a.BKZKP = 0 ";
            sql += "AND KOSTL = '" + centroCusto + "'";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    resultado = true;
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
