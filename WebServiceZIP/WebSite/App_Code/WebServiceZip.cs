using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebServiceZip
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceZip : System.Web.Services.WebService {

    public WebServiceZip () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string Zipar(string login, string codigos)
    {        
        Zipar zipar = new Zipar();
        return zipar.ZiparArquivos(login, Server.MapPath(""), codigos);        
    }
    [WebMethod]
    public string ZiparXML(string login, string codigos)
    {
        Zipar zipar = new Zipar();
        return zipar.ZiparArquivosXML(login, Server.MapPath(""), codigos);
    }
    [WebMethod]
    public string ZiparXMLSAP(string login, string codigos)
    {
        Zipar zipar = new Zipar();
        return zipar.ZiparArquivosXMLSAP(login, Server.MapPath(""), codigos);
    }
}
