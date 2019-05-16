using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Threading;

namespace WebServiceBNDS
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string ImportarPlanilha(double anexoId)
        {
            Importacao importaPlanilha = new Importacao();
            Thread threadPlanilha = new Thread(delegate()
            {
                importaPlanilha.Importar(anexoId, Server.MapPath(""));
            });
            threadPlanilha.Start();

            return "Importado";
        }
    }

}