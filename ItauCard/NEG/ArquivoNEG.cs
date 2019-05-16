using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace NEG
{
    public class ArquivoNEG
    {
        public decimal SalvarAnexo(FileUpload fuAnexo, string diretorioLocal)
        {
            DAL.ArquivoDAL arquivoDAL = new DAL.ArquivoDAL();
            return arquivoDAL.SalvarAnexo(fuAnexo, diretorioLocal);
        }
    }
}
