using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG
{
    public class ObjetoItauCardNEG
    {
        public decimal Encargos(decimal seqId)
        {
            DAL.ObjetoItauCardDAL objetoItauCardDAL = new DAL.ObjetoItauCardDAL();
            return objetoItauCardDAL.Encargos(seqId);
        }
        public decimal Credito(decimal seqId)
        {
            DAL.ObjetoItauCardDAL objetoItauCardDAL = new DAL.ObjetoItauCardDAL();
            return objetoItauCardDAL.Credito(seqId);
        }
        public decimal Debito(decimal seqId)
        {
            DAL.ObjetoItauCardDAL objetoItauCardDAL = new DAL.ObjetoItauCardDAL();
            return objetoItauCardDAL.Debito(seqId);
        }
        public decimal Total(decimal seqId)
        {
            DAL.ObjetoItauCardDAL objetoItauCardDAL = new DAL.ObjetoItauCardDAL();
            return objetoItauCardDAL.Total(seqId);
        }
        public bool Pep(string pep)
        {
            DAL.ObjetoItauCardDAL objetoItauCardDAL = new DAL.ObjetoItauCardDAL();
            return objetoItauCardDAL.Pep(pep);
        }
        public bool CentroCusto(string centroCusto)
        {
            DAL.ObjetoItauCardDAL objetoItauCardDAL = new DAL.ObjetoItauCardDAL();
            return objetoItauCardDAL.CentroCusto(centroCusto);
        }
        public decimal Sequencia()
        {
            DAL.ObjetoItauCardDAL objetoItauCardDAL = new DAL.ObjetoItauCardDAL();
            return objetoItauCardDAL.Sequencia();
        }
    }
}
