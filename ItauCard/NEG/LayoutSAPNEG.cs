using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG
{
    public class LayoutSAPNEG
    {
        public List<MOD.LayoutSAP> ListagemAgrupada(decimal seqId)
        {
            DAL.LayoutSAPDAL layoutSAPDAL = new DAL.LayoutSAPDAL();
            return layoutSAPDAL.ListagemAgrupada(seqId);
        }
        public List<MOD.DeParaUA> ListDePara(decimal seqId)
        {
            DAL.LayoutSAPDAL layoutSAPDAL = new DAL.LayoutSAPDAL();
            return layoutSAPDAL.ListDePara(seqId);
        }

    }
}
