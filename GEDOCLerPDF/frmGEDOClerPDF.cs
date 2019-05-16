using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEDOCLerPDF
{
    public partial class frmGEDOClerPDF : Form
    {
        public frmGEDOClerPDF()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LerPafinacao();
            Close();
        }
        private void LerPafinacao()
        {
            DocumentoSCAN documentoSCAN = new DocumentoSCAN();
            documentoSCAN.LerPDF();            
        }
    }
}
