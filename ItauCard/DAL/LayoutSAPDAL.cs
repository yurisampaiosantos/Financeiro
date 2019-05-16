using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class LayoutSAPDAL
    {
        public List<MOD.DeParaUA> ListDePara(decimal seqId)
        {
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            ObjetoItauCardDAL objetoItauCardDAL = new ObjetoItauCardDAL();
            MOD.ObjetoItauCard objetoItauCard = new MOD.ObjetoItauCard();

            string sql = null;
            string cc_pp_oi;
            string consultaDePara; 

            List<MOD.DeParaUA> ListDePara = new List<MOD.DeParaUA>();
            connection = new OleDbConnection(Dados.StringDeConexao);
            sql = "SELECT distinct nvl(a.UAUNIDACOMP,0) ";
            sql += "FROM eep_finance.ItauCard a ";
            sql += "WHERE a.STATUS = 'D' ";
            sql += "AND (UAUNIDACOMP is not null OR nvl(NumBilhete,1) NOT IN ('INDEVIDO','CRÉDITO','CREDITO','CR¿DITO'))";
            sql += "AND SEQ_ID = " + seqId + " ";            

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                objetoItauCard = objetoItauCardDAL.Listagem(seqId);

                while (reader.Read())
                {
                    cc_pp_oi = Convert.ToString(reader[0]).Trim();
                    DeParaUADAL deParaUADAL = new DeParaUADAL();
                    if (cc_pp_oi != "" && cc_pp_oi.Length > 5)
                    {
                        consultaDePara = deParaUADAL.CentroCusto(cc_pp_oi.Substring(4, cc_pp_oi.Length - 4).Replace("-", "").Replace(".", "")).Trim();
                        if (consultaDePara != "")
                        {
                            MOD.DeParaUA dePara = new MOD.DeParaUA();
                            dePara.De = cc_pp_oi;
                            dePara.Para = consultaDePara;
                            ListDePara.Add(dePara);
                            cc_pp_oi = consultaDePara;
                        }
                    }

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return ListDePara;
        }

        public List<MOD.LayoutSAP> ListagemAgrupada(decimal seqId)
        {
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            ObjetoItauCardDAL objetoItauCardDAL = new ObjetoItauCardDAL();
            MOD.ObjetoItauCard objetoItauCard = new MOD.ObjetoItauCard();

            string sql = null;
            string cc_pp_oi;
            string cc_pp_oiOriginal;
            string consultaDePara; 
         //   decimal rateioCredito = objetoItauCardDAL.RateioCredito(seqId) - objetoItauCardDAL.RateioDebito(seqId);
            decimal debito = objetoItauCardDAL.Total(seqId);// +rateioCredito;
           // decimal pedenteCredito = 0;
          //  decimal valorItem = 0;
            decimal total = objetoItauCardDAL.Total(seqId);

            List<MOD.LayoutSAP> listLayoutSAP = new List<MOD.LayoutSAP>();
            connection = new OleDbConnection(Dados.StringDeConexao);
            /*sql = "SELECT nvl(a.UAUNIDACOMP,0), SUM(a.TOTAL) - ";
            sql += "NVL((SELECT SUM(b.TOTAL) FROM eep_finance.ItauCard b WHERE b.STATUS = 'C' AND a.UAUNIDACOMP = b.UAUNIDACOMP AND a.SEQ_ID = b.SEQ_ID),0) as TotalC ";
            sql += "FROM eep_finance.ItauCard a ";
            sql += "WHERE a.STATUS = 'D' ";
            sql += "AND a.UAUNIDACOMP is not null ";
            sql += "AND SEQ_ID = " + seqId + " ";
            sql += "Group BY a.SEQ_ID,a.UAUNIDACOMP ";*/

            sql = "SELECT NVL(UAUNIDACOMP,'000000'),STATUS, NVL(PASSAGEIRO,'DESPESA') , TOTAL ";
            sql += "FROM eep_finance.ItauCard a ";
            sql += "WHERE (UAUNIDACOMP is not null OR nvl(NumBilhete,1) NOT IN ('INDEVIDO')) ";
            //sql += "WHERE (UAUNIDACOMP is not null OR nvl(NumBilhete,1) NOT IN ('INDEVIDO','CRÉDITO','CREDITO','CR¿DITO')) ";
            sql += "AND SEQ_ID = " + seqId + " ";
            sql += "ORDER BY  STATUS, PASSAGEIRO";   



            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();
                objetoItauCard = objetoItauCardDAL.Listagem(seqId);

                while (reader.Read())
                {
                    MOD.LayoutSAP layoutSAP = new MOD.LayoutSAP();
                  //  if (listLayoutSAP.Count == 0)
                  //  {
                        layoutSAP.DataDocumento = DateTime.Now.Date.ToString("yyyy.MM.dd");
                        layoutSAP.Empresa = "1000";
                        layoutSAP.DataLancamento = layoutSAP.DataDocumento;
                        layoutSAP.Mes = layoutSAP.DataDocumento.Substring(5, 2);
                        layoutSAP.Moeda = "BRL";
                        layoutSAP.NotaFiscal = objetoItauCard.NumeroCartao;
                        layoutSAP.TextoCabecalho = "ITAUCARD - " + objetoItauCard.NumeroCartao;
                        layoutSAP.Fornecedor = "14501372";
                        layoutSAP.Vencimento = Convert.ToDateTime(objetoItauCard.VctoFatura).ToString("yyyy.MM.dd");                        
                        layoutSAP.ValorTotal = total.ToString("N2");                       
                  //  }
                  //  else
                   // {


                        layoutSAP.ContaDespesa = "4110010101";
                        layoutSAP.Tipo = Convert.ToString(reader[1]).Trim();
                        layoutSAP.Passageiro = Convert.ToString(reader[2]).Trim();
                        layoutSAP.ValorItem = Convert.ToString(reader[3]).Trim();


                        cc_pp_oi = Convert.ToString(reader[0]).Trim();                       
                        DeParaUADAL deParaUADAL = new DeParaUADAL();
                        if (cc_pp_oi != "" && cc_pp_oi.Length > 5)
                        {
                            consultaDePara = deParaUADAL.CentroCusto(cc_pp_oi.Substring(4, cc_pp_oi.Length - 4).Replace("-", "").Replace(".", "")).Trim();
                            if (consultaDePara != "")
                                cc_pp_oi = consultaDePara;                            
                        }

                        if (objetoItauCardDAL.CentroCusto(cc_pp_oi))
                        {
                            layoutSAP.CentroCusto = cc_pp_oi;
                        }
                        else
                            if (objetoItauCardDAL.Pep(cc_pp_oi))
                            {
                                layoutSAP.ElementoPep = cc_pp_oi;
                                layoutSAP.Alterar = false;
                            }
                            else
                            {
                                cc_pp_oiOriginal = cc_pp_oi;

                                cc_pp_oi = cc_pp_oiOriginal.Substring(4, cc_pp_oi.Length - 4).Replace("-", "").Replace(".", "");
                                if (objetoItauCardDAL.CentroCusto(cc_pp_oi))
                                {
                                    layoutSAP.CentroCusto = cc_pp_oi;
                                }
                                else
                                {
                                    cc_pp_oi = cc_pp_oi.PadRight(15, '0');
                                    if (objetoItauCardDAL.Pep(cc_pp_oi))
                                    {
                                        layoutSAP.ElementoPep = cc_pp_oi;
                                        layoutSAP.Alterar = false;
                                    }
                                    else
                                    {

                                        cc_pp_oi = cc_pp_oiOriginal.Replace("-", "").Replace(".", "");
                                        if (objetoItauCardDAL.CentroCusto(cc_pp_oi))
                                        {
                                            layoutSAP.CentroCusto = cc_pp_oi;
                                        }
                                        else
                                        {
                                            cc_pp_oi = cc_pp_oi.PadRight(15, '0');
                                            if (objetoItauCardDAL.Pep(cc_pp_oi))
                                            {
                                                layoutSAP.ElementoPep = cc_pp_oi;
                                                layoutSAP.Alterar = false;
                                            }
                                            else
                                            {
                                                layoutSAP.NaoEncontrado = cc_pp_oiOriginal;
                                                layoutSAP.Alterar = true;
                                                //layoutSAP.OrdemInterna = cc_pp_oi;
                                            }
                                        }
                                    }
                                    
                                }
                            }

                        //verifica se possui valor em credito para ratear
                   /*     valorItem = Convert.ToDecimal(reader[1]);
                        if (rateioCredito != 0)
                        {
                            layoutSAP.ValorItem = (valorItem - (valorItem / debito) * rateioCredito).ToString("N2");

                            pedenteCredito += Convert.ToDecimal(((Convert.ToDecimal(valorItem) / debito) * rateioCredito).ToString("N2"));
                        }
                        else
                        {
                            layoutSAP.ValorItem = valorItem.ToString("N2");
                        }*/

                   // }
                    listLayoutSAP.Add(layoutSAP);
                }
                //varifica se ficou alguma resudo do credito
             /*   if (rateioCredito > pedenteCredito)
                {
                    listLayoutSAP[listLayoutSAP.Count - 1].ValorItem = Convert.ToString(Convert.ToDecimal(listLayoutSAP[listLayoutSAP.Count - 1].ValorItem) - (rateioCredito - pedenteCredito));
                }
                else
                {
                    listLayoutSAP[listLayoutSAP.Count - 1].ValorItem = Convert.ToString(Convert.ToDecimal(listLayoutSAP[listLayoutSAP.Count - 1].ValorItem) + (pedenteCredito - rateioCredito));
                }*/
            
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return listLayoutSAP;
        }
    }
}
