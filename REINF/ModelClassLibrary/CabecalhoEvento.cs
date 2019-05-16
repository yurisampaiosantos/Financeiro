using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinfModelClassLibrary
{
    public static class DadosCabecalhoEventoConst
    {
        public const int procEmi = 1;
        public const int tpAmb = 2;
        public const string verProc = "1.03.02";
        public const int tpInsc = 1;
    }

    public class DadosCabecalhoEvento
    {
        public string id { get; set; }
        public string nrInsc { get; set; }
    }

}
