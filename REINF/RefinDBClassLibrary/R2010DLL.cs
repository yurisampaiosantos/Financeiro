using evtTomadorServicos;
using Oracle.ManagedDataAccess.Client;
using ReinfDBClassLibrary;
using ReinfModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ReinfDBClassLibrary
{
    public class R2010DLL
    {

        private OracleConnection oc;
        ReinfOraDB odb = new ReinfOraDB();

        public R2010DLL()
        {
            odb = new ReinfOraDB();
            oc = odb.getConn();
        }

        public void delete(int idReg)
        {
            String sql = "delete from R2010 where idReg = " + idReg.ToString();
            odb.executeSql(sql);            
        }

        public void gerarEventoExclusao(string cnpj, string nrRecibo, string perApur)
        {
            R9000DLL r = new R9000DLL();
            r.incluir(cnpj, "R-2010", nrRecibo, perApur);
        }

        public void limparR2010Temp()
        {
            string sqlDelete = "delete from r2010_temp";
            odb.executeSql(sqlDelete);

        }

        public void carregaR2010Temp(DataSet ds)
        {

            limparR2010Temp();
            string sql = "insert into r2010_temp (perapur, empresa, filial, dtemissaonf, vlrretencao, codanacont, cpf_cnpjprestador, vlrbruto, numdocto) " +
                "values (:perapur, :empresa, :filial, :dtemissaonf, :vlrretencao, :codanacont, :cpf_cnpjprestador, :vlrbruto, :numdocto)";
            
            oc.Open();

            // Preencher com os dados da Carga
            OracleCommand cmd = new OracleCommand(sql, oc);
            cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("empresa", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("filial", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("dtemissaonf", OracleDbType.Date));
            cmd.Parameters.Add(new OracleParameter("vlrretencao", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("codanacont", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("cpf_cnpjprestador", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrbruto", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("numdocto", OracleDbType.Varchar2, ParameterDirection.Input));

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                DateTime dtEmi = Convert.ToDateTime(r["dtemissaonf"].ToString());
                cmd.Parameters["perapur"].Value = r["perapur"].ToString();
                cmd.Parameters["empresa"].Value = r["empresa"].ToString();
                cmd.Parameters["filial"].Value = r["filial"].ToString();
                cmd.Parameters["dtemissaonf"].Value = dtEmi;
                cmd.Parameters["vlrretencao"].Value = Convert.ToDecimal(r["vlrretencao"].ToString());
                cmd.Parameters["codanacont"].Value = r["codanacont"].ToString();
                cmd.Parameters["cpf_cnpjprestador"].Value = r["cpf_cnpjprestador"].ToString();
                cmd.Parameters["vlrbruto"].Value = Convert.ToDecimal(r["vlrbruto"].ToString());
                cmd.Parameters["numdocto"].Value = r["numdocto"].ToString();

                cmd.ExecuteNonQuery();
            }

            oc.Close();
        }

        public void preencherR2010()
        {
            int i = 0;

            string sqlEventos = "select distinct perapur, " +
                                  "empresa, filial,  " +
                                  " decode(empresa, '1000', '12243301000125', '2000', '15427668000197') nrInsc, " +
                                  " decode(filial, '1000', '12243301000125','1006','12243301000710','1007','12243301000800') nrInscEstab " +
                                  " from " +
                                  " r2010_temp";

            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sqlEventos, oc);
            DataSet ds2010 = new DataSet();
            da.Fill(ds2010);

            // Preencher com os dados da Carga
            string sqlInsR2010 = "insert into r2010 (id, indretif,perapur, tpamb, procemi, verproc, tpinsc, nrinsc, tpinscestab, nrinscestab, indobra) " +
                " values (:id, :indretif, :perapur, :tpamb, :procemi, :verproc, :tpinsc, :nrinsc, :tpinscestab, :nrinscestab, :indobra) " +
                 " RETURNING idReg INTO :idReg";

            OracleCommand cmd = new OracleCommand(sqlInsR2010, oc);
            cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("indretif", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpamb", OracleDbType.Int16));
            cmd.Parameters.Add(new OracleParameter("procemi", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("verproc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpinscestab", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinscestab", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("indobra", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("idReg", OracleDbType.Int64, ParameterDirection.Output));

            // Inserir no Evento R2010
            foreach (DataRow r in ds2010.Tables[0].Rows)
            {
                i++;
                cmd.Parameters["id"].Value = "ID1" + r["nrinsc"].ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + i.ToString("00000");
                cmd.Parameters["indretif"].Value = 1;
                cmd.Parameters["perapur"].Value = r["perapur"].ToString();
                cmd.Parameters["tpamb"].Value = DadosCabecalhoEventoConst.tpAmb;
                cmd.Parameters["procemi"].Value = DadosCabecalhoEventoConst.procEmi;
                cmd.Parameters["verproc"].Value = DadosCabecalhoEventoConst.verProc;
                cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
                cmd.Parameters["nrinsc"].Value = r["nrinsc"].ToString();
                cmd.Parameters["tpinscestab"].Value = DadosCabecalhoEventoConst.tpInsc;
                cmd.Parameters["nrinscestab"].Value = r["nrinscestab"].ToString();
                cmd.Parameters["indobra"].Value = 0;
                cmd.ExecuteNonQuery();
                int idReg2010 = Convert.ToInt16(cmd.Parameters["idReg"].Value.ToString());

                // Inserir no Evento R2010_IDEPRESTSERV
                string sql2010_IdePrestServ = "select CPF_CNPJPRESTADOR, CODANACONT, sum(VLRBRUTO) vlrTotalBruto, sum(VLRRETENCAO) vlrTotalRetPrinc " +
                                        " from R2010_TEMP where empresa = '" + r["empresa"].ToString() + "' and filial = '" + r["filial"].ToString() + "' and PERAPUR = '" + r["perapur"].ToString() + "' " +
                                        " group by CPF_CNPJPRESTADOR, CODANACONT";
                da = new OracleDataAdapter(sql2010_IdePrestServ, oc);
                DataSet ds2010IdePrestServ = new DataSet();
                da.Fill(ds2010IdePrestServ);


                string sqlInsR2010_IDEPRESTSERV = "insert into r2010_IDEPRESTSERV (cnpjprestador,codanacont,indcprb,r2010_idreg) " +
                    " values (:cnpjprestador, :codanacont, :indcprb, :r2010_idreg) " +
                     " RETURNING idReg INTO :idRegIdePrestServ";
                OracleCommand cmdIdePrestServ = new OracleCommand(sqlInsR2010_IDEPRESTSERV, oc);
                cmdIdePrestServ.Parameters.Add(new OracleParameter("cnpjprestador", OracleDbType.Varchar2, ParameterDirection.Input));
                cmdIdePrestServ.Parameters.Add(new OracleParameter("codanacont", OracleDbType.Varchar2, ParameterDirection.Input));
                cmdIdePrestServ.Parameters.Add(new OracleParameter("indcprb", OracleDbType.Int16));
                cmdIdePrestServ.Parameters.Add(new OracleParameter("r2010_idreg", OracleDbType.Int16, ParameterDirection.Input));
                cmdIdePrestServ.Parameters.Add(new OracleParameter("idRegIdePrestServ", OracleDbType.Int64, ParameterDirection.Output));
                foreach (DataRow rIdePrestServ in ds2010IdePrestServ.Tables[0].Rows)
                {
                    cmdIdePrestServ.Parameters["cnpjprestador"].Value = rIdePrestServ["CPF_CNPJPRESTADOR"].ToString();
                    cmdIdePrestServ.Parameters["codanacont"].Value = rIdePrestServ["CODANACONT"].ToString();
                    cmdIdePrestServ.Parameters["indcprb"].Value = 1;
                    cmdIdePrestServ.Parameters["r2010_idreg"].Value = idReg2010;
                    cmdIdePrestServ.ExecuteNonQuery();
                    int idRegIdePrestServ = Convert.ToInt16(cmdIdePrestServ.Parameters["idRegIdePrestServ"].Value.ToString());

                    // Inserir no Evento R2010_NFS
                    string sql2010_NFS = "select * from R2010_TEMP where empresa = '" + r["empresa"].ToString() + "' and filial = '" + r["filial"].ToString() + "' and PERAPUR = '" + r["perapur"].ToString() + "' " +
                                         " and CPF_CNPJPRESTADOR = '" + rIdePrestServ["CPF_CNPJPRESTADOR"].ToString() + "'";
                    da = new OracleDataAdapter(sql2010_NFS, oc);
                    DataSet ds2010NFS = new DataSet();
                    da.Fill(ds2010NFS);

                    string sqlInsR2010_NFS = "insert into r2010_NFS (SERIE,NUMDOCTO,DTEMISSAONF,VLRBRUTO, OBS, R2010_IDEPRESTSERV_IDREG) " +
                        " values (:SERIE,:NUMDOCTO,:DTEMISSAONF,:VLRBRUTO, :OBS, :R2010_IDEPRESTSERV_IDREG) " +
                         " RETURNING idReg INTO :idRegNFS";
                    OracleCommand cmdNFS = new OracleCommand(sqlInsR2010_NFS, oc);
                    cmdNFS.Parameters.Add(new OracleParameter("SERIE", OracleDbType.Varchar2, ParameterDirection.Input));
                    cmdNFS.Parameters.Add(new OracleParameter("NUMDOCTO", OracleDbType.Varchar2, ParameterDirection.Input));
                    cmdNFS.Parameters.Add(new OracleParameter("DTEMISSAONF", OracleDbType.Date));
                    cmdNFS.Parameters.Add(new OracleParameter("VLRBRUTO", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdNFS.Parameters.Add(new OracleParameter("OBS", OracleDbType.Varchar2, ParameterDirection.Input));
                    cmdNFS.Parameters.Add(new OracleParameter("R2010_IDEPRESTSERV_IDREG", OracleDbType.Int64, ParameterDirection.Input));
                    cmdNFS.Parameters.Add(new OracleParameter("idRegNFS", OracleDbType.Int64, ParameterDirection.Output));
                    foreach (DataRow rNFS in ds2010NFS.Tables[0].Rows)
                    {
                        cmdNFS.Parameters["SERIE"].Value = "1";// rNFS["SERIE"].ToString();
                        cmdNFS.Parameters["NUMDOCTO"].Value = rNFS["NUMDOCTO"].ToString();
                        cmdNFS.Parameters["DTEMISSAONF"].Value = Convert.ToDateTime(rNFS["DTEMISSAONF"].ToString());
                        cmdNFS.Parameters["VLRBRUTO"].Value = Convert.ToDecimal(rNFS["VLRBRUTO"].ToString());
                        cmdNFS.Parameters["OBS"].Value = "";
                        cmdNFS.Parameters["R2010_IDEPRESTSERV_IDREG"].Value = idRegIdePrestServ;
                        cmdNFS.ExecuteNonQuery();
                        int idRegNFS = Convert.ToInt16(cmdNFS.Parameters["idRegNFS"].Value.ToString());

                        // Inserir no Evento R2010_INFOTPSERV
                        string sql2010_INFOTPSERV = "select * from R2010_TEMP where empresa = '" + r["empresa"].ToString() + "' and filial = '" + r["filial"].ToString() + "' and PERAPUR = '" + r["perapur"].ToString() + "' " +
                         " and CPF_CNPJPRESTADOR = '" + rIdePrestServ["CPF_CNPJPRESTADOR"].ToString() + "' and numdocto = '" + rNFS["numdocto"].ToString() + "'";
                        da = new OracleDataAdapter(sql2010_INFOTPSERV, oc);
                        DataSet ds2010InfoTpServ = new DataSet();
                        da.Fill(ds2010InfoTpServ);
                        string sqlInsR2010__INFOTPSERV = "insert into r2010_INFOTPSERV (TPSERVICO,VLRMATEQUIP,VLRDEDALIM,VLRDEDTRANS, VLRBASERET, VLRRETENCAO,VLRRETSUB,VLRNRETPRINC,VLRSERVICOS15,VLRSERVICOS20,VLRSERVICOS25,VLRADICIONAL,VLRNRETADIC,R2010_NFS_IDREG ) " +
                            " values (:TPSERVICO, :VLRMATEQUIP, :VLRDEDALIM, :VLRDEDTRANS, :VLRBASERET, :VLRRETENCAO,:VLRRETSUB,:VLRNRETPRINC,:VLRSERVICOS15,:VLRSERVICOS20,:VLRSERVICOS25,:VLRADICIONAL,:VLRNRETADIC,:R2010_NFS_IDREG) " +
                             " RETURNING idReg INTO :idRegINFOTPSERV";
                        OracleCommand cmdINFOTPSERV = new OracleCommand(sqlInsR2010__INFOTPSERV, oc);
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("TPSERVICO", OracleDbType.Varchar2, ParameterDirection.Input));
                        //cmdINFOTPSERV.Parameters.Add(new OracleParameter("CODATIVECON", OracleDbType.Int64, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRMATEQUIP", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRDEDALIM", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRDEDTRANS", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRBASERET", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRRETENCAO", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRRETSUB", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRNRETPRINC", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRSERVICOS15", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRSERVICOS20", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRSERVICOS25", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRADICIONAL", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRNRETADIC", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("R2010_NFS_IDREG", OracleDbType.Int64, ParameterDirection.Input));
                        cmdINFOTPSERV.Parameters.Add(new OracleParameter("idRegINFOTPSERV", OracleDbType.Int64, ParameterDirection.Output));
                        foreach (DataRow rNFOTPSERV in ds2010InfoTpServ.Tables[0].Rows)
                        {
                            cmdINFOTPSERV.Parameters["TPSERVICO"].Value = "03";
                            //cmdINFOTPSERV.Parameters["CODATIVECON"].Value = DBNull.Value;
                            cmdINFOTPSERV.Parameters["VLRMATEQUIP"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRDEDALIM"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRDEDTRANS"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRBASERET"].Value = Convert.ToDecimal(rNFOTPSERV["VLRBRUTO"].ToString());
                            cmdINFOTPSERV.Parameters["VLRRETENCAO"].Value = Convert.ToDecimal(rNFOTPSERV["VLRRETENCAO"].ToString());
                            cmdINFOTPSERV.Parameters["VLRRETSUB"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRNRETPRINC"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRSERVICOS15"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRSERVICOS20"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRSERVICOS25"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRADICIONAL"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRNRETADIC"].Value = 0;
                            cmdINFOTPSERV.Parameters["R2010_NFS_IDREG"].Value = idRegNFS;
                            cmdINFOTPSERV.ExecuteNonQuery();
                            int idRegINFOTPSERV = Convert.ToInt16(cmdINFOTPSERV.Parameters["idRegINFOTPSERV"].Value.ToString());
                        }
                    }
                }
            }
            oc.Close();
        }

        public DataTable getData()
        {
            string sql = "select * from R2010";
            return odb.getDataTable(sql);
        }
        public DataTable getData(int idReg)
        {
            string sql = "select * from R2010 where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }
        public DataTable getDataR2010IdePrestServ(int R2010_idReg)
        {
            string sql =
                    "       select                                        " +
                    "         r.idReg,                            " +
                    "         r.CNPJPRESTADOR,                            " +
                    "         r.CODANACONT,                               " +
                    "         r.INDCPRB,                                  " +
                    "         sum(vlrBruto) vlrTotalBruto,                " +
                    "         sum(vlrBaseRet) vlrTotalBaseRet,            " +
                    "         sum(vlrRetencao) vlrTotalRetPrinc,          " +
                    "         sum(vlrAdicional) vlrTotalRetAdic,          " +
                    "         sum(vlrNRetPrinc) vlrTotalNRetPrinc,        " +
                    "         sum(vlrNRetAdic) vlrTotalNRetAdic           " +
                    "       from                                          " +
                    "         R2010_IDEPRESTSERV r,                       " +
                    "         R2010_NFS n,                                " +
                    "         R2010_INFOTPSERV t                          " +
                    "       where                                         " +
                    "         t.R2010_NFS_IDREG = n.IDREG and             " +
                    "         n.R2010_IDEPRESTSERV_IDREG = r.IDREG and    " +
                    "         r.R2010_idReg = " + R2010_idReg.ToString() +
                    "       group by                                      " +
                    "       r.idReg, r.CNPJPRESTADOR,  " +
                    "         r.CODANACONT,                               " +
                    "         r.INDCPRB                                   ";
            return odb.getDataTable(sql);
        }
        public DataTable getDataR2010NFS(int R2010_IdePrestServ_IdReg)
        {
            string sql = "select * from R2010_NFS where R2010_IDEPRESTSERV_IDREG = " + R2010_IdePrestServ_IdReg.ToString();
            return odb.getDataTable(sql);
        }
        public DataTable getDataR2010INFOTPSERV(int R2010_NFS_IDREG)
        {
            string sql = "select * from R2010_INFOTPSERV where R2010_NFS_IDREG = " + R2010_NFS_IDREG.ToString();
            return odb.getDataTable(sql);
        }
        public XmlDocument getXMLEvt(int idReg)
        {
            ReinfOraDB reinfOraDB = new ReinfOraDB();
            DataTable t = getData(idReg);

            evtTomadorServicos.Reinf r = new evtTomadorServicos.Reinf();
            ReinfEvtServTom evt = new ReinfEvtServTom();

            // Cabeçalho comum a todos os eventos
            evt.id = t.Rows[0]["id"].ToString();
            evt.ideEvento = new ReinfEvtServTomIdeEvento();
            evt.ideEvento.procEmi = Convert.ToByte(t.Rows[0]["procEmi"].ToString());
            evt.ideEvento.tpAmb = Convert.ToByte(t.Rows[0]["tpAmb"].ToString());
            evt.ideEvento.verProc = t.Rows[0]["verProc"].ToString();
            evt.ideContri = new ReinfEvtServTomIdeContri();
            evt.ideContri.tpInsc = Convert.ToByte(t.Rows[0]["tpInsc"].ToString());
            evt.ideContri.nrInsc = t.Rows[0]["nrInsc"].ToString();
            // Fim do Cabeçalho

            evt.ideEvento.perApur = t.Rows[0]["perApur"].ToString();

            DataTable dt2010 = getData(idReg);
            // Cessão de Mao de Obra ou Empreitada
            evt.infoServTom = new ReinfEvtServTomInfoServTom();
            evt.infoServTom.ideEstabObra = new ReinfEvtServTomInfoServTomIdeEstabObra();
            evt.infoServTom.ideEstabObra.tpInscEstab = Convert.ToByte(dt2010.Rows[0]["tpInscEstab"].ToString());
            evt.infoServTom.ideEstabObra.nrInscEstab = dt2010.Rows[0]["nrInscEstab"].ToString();
            evt.infoServTom.ideEstabObra.indObra = Convert.ToByte(dt2010.Rows[0]["indObra"].ToString());

            // Adicionar os Prestadores
            DataTable dt2010IdePrestServ = getDataR2010IdePrestServ(idReg);
            evt.infoServTom.ideEstabObra.idePrestServ = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ[dt2010IdePrestServ.Rows.Count];
            for (int i = 0; i < dt2010IdePrestServ.Rows.Count; i++)
            {
                evt.infoServTom.ideEstabObra.idePrestServ[i] = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ();
                evt.infoServTom.ideEstabObra.idePrestServ[i].cnpjPrestador = dt2010IdePrestServ.Rows[i]["cnpjPrestador"].ToString();
                evt.infoServTom.ideEstabObra.idePrestServ[i].vlrTotalBruto = dt2010IdePrestServ.Rows[i]["vlrTotalBruto"].ToString();
                evt.infoServTom.ideEstabObra.idePrestServ[i].vlrTotalBaseRet = dt2010IdePrestServ.Rows[i]["vlrTotalBaseRet"].ToString();
                evt.infoServTom.ideEstabObra.idePrestServ[i].vlrTotalRetPrinc = dt2010IdePrestServ.Rows[i]["vlrTotalRetPrinc"].ToString();
                evt.infoServTom.ideEstabObra.idePrestServ[i].vlrTotalRetAdic = dt2010IdePrestServ.Rows[i]["vlrTotalRetAdic"].ToString();
                evt.infoServTom.ideEstabObra.idePrestServ[i].vlrTotalNRetPrinc = dt2010IdePrestServ.Rows[i]["vlrTotalNRetPrinc"].ToString();
                evt.infoServTom.ideEstabObra.idePrestServ[i].vlrTotalNRetAdic = dt2010IdePrestServ.Rows[i]["vlrTotalNRetAdic"].ToString();
                evt.infoServTom.ideEstabObra.idePrestServ[i].codAnaCont = dt2010IdePrestServ.Rows[i]["codAnaCont"].ToString();
                evt.infoServTom.ideEstabObra.idePrestServ[i].indCPRB = 0;


                // Adicionar as Notas Fiscais do Prestador                    
                DataTable dt2010NFS = getDataR2010NFS(Convert.ToInt32(dt2010IdePrestServ.Rows[i]["idReg"].ToString()));
                evt.infoServTom.ideEstabObra.idePrestServ[i].nfs = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs[dt2010NFS.Rows.Count];
                for (int j = 0; j < dt2010NFS.Rows.Count; j++)
                {
                    evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j] = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs();
                    evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].serie = dt2010NFS.Rows[j]["serie"].ToString();
                    evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].numDocto = dt2010NFS.Rows[j]["numDocto"].ToString();
                    evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].dtEmissaoNF = DateTime.Parse(dt2010NFS.Rows[j]["dtEmissaoNF"].ToString());
                    evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].vlrBruto = dt2010NFS.Rows[j]["vlrBruto"].ToString(); ;
                    evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].obs = dt2010NFS.Rows[j]["obs"].ToString();

                    // Adicionar os Tipos de Servicos constantes da NF
                    DataTable dt2010InfoTpServ = getDataR2010INFOTPSERV(Convert.ToInt32(dt2010NFS.Rows[j]["idReg"].ToString()));
                    evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].infoTpServ = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ[dt2010InfoTpServ.Rows.Count];
                    for (int k = 0; k < dt2010InfoTpServ.Rows.Count; k++)
                    {
                        evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].infoTpServ[k] = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ();
                        evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].infoTpServ[k].tpServico = dt2010InfoTpServ.Rows[k]["tpServico"].ToString();
                        evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].infoTpServ[k].codAtivEcon = dt2010InfoTpServ.Rows[k]["codAtivEcon"].ToString();
                        evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].infoTpServ[k].vlrMatEquip = dt2010InfoTpServ.Rows[k]["vlrMatEquip"].ToString();
                        evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].infoTpServ[k].vlrDedAlim = dt2010InfoTpServ.Rows[k]["vlrDedAlim"].ToString();
                        evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].infoTpServ[k].vlrDedTrans = dt2010InfoTpServ.Rows[k]["vlrDedTrans"].ToString();
                        evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].infoTpServ[k].vlrBaseRet = dt2010InfoTpServ.Rows[k]["vlrBaseRet"].ToString();
                        evt.infoServTom.ideEstabObra.idePrestServ[i].nfs[j].infoTpServ[k].vlrRetencao = dt2010InfoTpServ.Rows[k]["vlrRetencao"].ToString();
                    }
                }
            }

            r.evtServTom = evt;



            // Serializaçao do Objeto em Memória para retonrar o XMLDocument
            XmlSerializer x = new XmlSerializer(r.GetType());

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "http://www.reinf.esocial.gov.br/schemas/" + r.GetType().Namespace + "/v1_01_01");

            MemoryStream memStm = new MemoryStream();
            x.Serialize(memStm, r, xsn);
            memStm.Position = 0;

            // Retirar as quebras de linhas e espaços em branco do XML
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            var xtr = XmlReader.Create(memStm, settings);

            // Criar o docoumento de retorno
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xtr);

            // Retornar o XMLDocument com o Envento
            return xmlDoc;
        }


    }
}
