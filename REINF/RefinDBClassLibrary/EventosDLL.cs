using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefinDBClassLibrary
{
    public class EventosDLL
    {
        OracleConnection conn;
        ReinfDBClassLibrary.ReinfOraDB odb;

        public EventosDLL()
        {
            odb = new ReinfDBClassLibrary.ReinfOraDB();
            conn = odb.getConn();
        }

        public DataTable getEventos()
        {
            String sql = "select * from EVENTOS";
            return odb.getDataTable(sql);
        }

        public DataTable getEvento(int idReg)
        {
            String sql = "select * from EVENTOS where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public void delete(int idReg)
        {
            String sql = "delete from EVENTOS where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }

        public void incluir(string nome, string codigo, string tagEvento, string ativo)
        {
            String sql = "insert into EVENTOS (nome, codigo, tagevento, ativo) values ('" + nome + "','" + codigo + "','" + tagEvento + "','"+ativo+"')";
            odb.executeSql(sql);
        }

        public void atualiza(int idReg, string nome, string codigo, string tagEvento, string ativo)
        {
            String sql = "update EVENTOS set nome = '" + nome + "', codigo = '" + codigo + "', tagevento = '" + tagEvento + "', ativo = '"+ ativo+"' where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }
    }
}
