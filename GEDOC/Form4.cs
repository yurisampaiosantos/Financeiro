using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NSOCR_NameSpace; //Add NSOCR namespace from "NSOCR.cs"

namespace Sample
{
    public partial class fmLanguages : Form
    {
        public Form1 fmMain;

        public fmLanguages()
        {
            InitializeComponent();
        }

        public void LoadLanguages()
        {
            int i;
            string val;
            for (i = 0; i < cbLanguages.Items.Count; i++)
            {
                if (fmMain.NsOCR.Cfg_GetOption(fmMain.CfgObj, TNSOCR.BT_DEFAULT, "Languages/" + cbLanguages.Items[i], out val) < TNSOCR.ERROR_FIRST)
                    cbLanguages.SetItemChecked(i, val == "1");
                else
                    cbLanguages.SetItemChecked(i, false);
            }
        }

        public bool ApplyLanguages()
        {
            int i;
            bool ch = false;
            for (i = 0; i < cbLanguages.Items.Count; i++)
                if (cbLanguages.GetItemChecked(i))
                {
                        ch = true;
                        break;
                }
            if (!ch)
            {
                System.Windows.Forms.MessageBox.Show("Please select at least one language for recognition.");
                return false;
            }

            for (i = 0; i < cbLanguages.Items.Count; i++)
                fmMain.NsOCR.Cfg_SetOption(fmMain.CfgObj, TNSOCR.BT_DEFAULT, "Languages/" + cbLanguages.Items[i], cbLanguages.GetItemChecked(i) ? "1" : "0");

            return true;
        }

        private void fmLanguages_Load(object sender, EventArgs e)
        {
            LoadLanguages();
        }

        private void bkCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bkOK_Click(object sender, EventArgs e)
        {
            if (ApplyLanguages())
                Close();
        }

    }
}
