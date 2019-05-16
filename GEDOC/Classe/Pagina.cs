using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    class Pagina
    {
        private string _barcode;

        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }
        private int _paginaInicial;

        public int PaginaInicial
        {
            get { return _paginaInicial; }
            set { _paginaInicial = value; }
        }
        private int paginaFinal;

        public int PaginaFinal
        {
            get { return paginaFinal; }
            set { paginaFinal = value; }
        }
    }
}
