using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample
{
    public partial class Form6 : Form
    {
        public ListBox listaBarcodes = new ListBox();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            lbBarcodes.Items.Clear();
            foreach (object item in listaBarcodes.Items)
            {
                lbBarcodes.Items.Add(item.ToString());
            }
            lbTotal.Text = "Total : " + lbBarcodes.Items.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
