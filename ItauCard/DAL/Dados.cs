using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Collections.Specialized;


namespace DAL
{
    public class Dados
    {
        public static string StringDeConexao
        {
            get
            {//MSDAORA                 
                //------produção                                                                             
                return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=f_app_itaucard;Password=itaucardENSPRODora";
                //------desenvolvimento
                //return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EEP_FINANCE;Password=eep_financeSAeep$dev";
            }
        }
    }
}
