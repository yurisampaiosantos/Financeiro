using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btImportArquivo_Click(object sender, EventArgs e)
    {        
        NEG.ArquivoNEG arquivoNEG = new NEG.ArquivoNEG();
        decimal seqId = arquivoNEG.SalvarAnexo(FileUpload1, Server.MapPath(""));
        txtSeq.Text = seqId.ToString();

        NEG.ObjetoItauCardNEG objetoItauCardNEG = new NEG.ObjetoItauCardNEG();
        lbCredito.Text = objetoItauCardNEG.Credito(seqId).ToString("N2");
        lbDebito.Text = objetoItauCardNEG.Debito(seqId).ToString("N2");
        lbTotal.Text = objetoItauCardNEG.Total(seqId).ToString("N2");
        lbEncargos.Text = objetoItauCardNEG.Encargos(seqId).ToString("N2");
        pnResultado.Visible = true;
        btCSV.Visible = true;
        pnAlteracao.Visible = true;
        gvResultado.DataBind();
        gvDePara.DataBind();
    }
    protected void btCSV_Click(object sender, EventArgs e)
    {
        if (verificaPreenchimento())
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ItauCard.csv"));
            Response.ContentType = "application/text";
            StringBuilder str = new StringBuilder();

            gvResultado.Columns[0].Visible = true;
            gvResultado.Columns[1].Visible = true;
            gvResultado.Columns[2].Visible = true;
            gvResultado.Columns[3].Visible = true;
            gvResultado.Columns[4].Visible = true;
            gvResultado.Columns[5].Visible = true;
            gvResultado.Columns[6].Visible = true;
            gvResultado.Columns[7].Visible = true;
            gvResultado.Columns[8].Visible = true;
            gvResultado.Columns[9].Visible = true;
            gvResultado.Columns[10].Visible = true;
            gvResultado.Columns[11].Visible = true;
            gvResultado.Columns[12].Visible = true;
            gvResultado.Columns[13].Visible = true;   

//            gvResultado.DataBind();
            str.Append("");
            str.Append("\n");
            int iColCount = gvResultado.Columns.Count;
          /*  for (int j = 0; j < 1; j++)
            {
                GridViewRow linha = gvResultado.Rows[j];
                Control fornecedor = linha.FindControl("lbFornecedor");
                str.Append("C," + gvResultado.Rows[j].Cells[1].Text + "," +  ((Label)fornecedor).Text + "," + gvResultado.Rows[j].Cells[2].Text.Replace(".", "") + "," + gvResultado.Rows[j].Cells[5].Text
                    + "," + gvResultado.Rows[j].Cells[2].Text.Replace(".", "") + ",GV," + gvResultado.Rows[j].Cells[8].Text.Replace(".", "").Replace(",", ".") + "," + gvResultado.Rows[j].Cells[4].Text + ",1000," 
                    + gvResultado.Rows[j].Cells[6].Text + "," + gvResultado.Rows[j].Cells[9].Text.Replace(".", "") + ",C000," 
                    + gvResultado.Rows[j].Cells[5].Text.Substring(gvResultado.Rows[j].Cells[5].Text.Length-4,4));
                str.Append("\n");
            }*/

            for (int j = 0; j < gvResultado.Rows.Count; j++)
            {
                GridViewRow linha = gvResultado.Rows[j];                
                Control centroCusto = linha.FindControl("txtCentroCusto");
                Control ordeminterna = linha.FindControl("txtOrdeminterna");
                Control elementoPep = linha.FindControl("txtElementoPep");
                str.Append("I," + gvResultado.Rows[j].Cells[10].Text + "," + gvResultado.Rows[j].Cells[11].Text.Replace("C", "H").Replace("D", "S") + "," + gvResultado.Rows[j].Cells[12].Text.Replace("CR&#191;DITO", "CREDITO") + "," + gvResultado.Rows[j].Cells[13].Text.Replace(".", "").Replace(",", ".") + "," + ((TextBox)centroCusto).Text + "," + ((TextBox)elementoPep).Text + "," + ((TextBox)ordeminterna).Text);
                str.Append("\n");
            }
           
            for (int j = 0; j < 1; j++)
            {
                GridViewRow linha = gvResultado.Rows[j];
                Control fornecedor = linha.FindControl("lbFornecedor");
                gvResultado.DataBind();
                str.Insert(0,"C," + gvResultado.Rows[j].Cells[1].Text + "," + ((Label)fornecedor).Text + "," + gvResultado.Rows[j].Cells[2].Text.Replace(".", "") + "," + gvResultado.Rows[j].Cells[5].Text
                    + "," + gvResultado.Rows[j].Cells[2].Text.Replace(".", "") + ",GV," + gvResultado.Rows[j].Cells[8].Text.Replace(".", "").Replace(",", ".") + "," + gvResultado.Rows[j].Cells[4].Text + ",1000,"
                    + gvResultado.Rows[j].Cells[6].Text + "," + gvResultado.Rows[j].Cells[9].Text.Replace(".", "") + ",C000,"
                    + gvResultado.Rows[j].Cells[5].Text.Substring(gvResultado.Rows[j].Cells[5].Text.Length - 4, 4));
                //str.Append("\n");
            }


            Response.Write(str.ToString());
            Response.End();
        }
        else
        {
            Response.Write("<script>alert('Para geração do arquivo é necessario a correção de todos CC/PP/OI não encontrados. Favor corrigir e gerar novamente');</script>");
        }
    }
    private bool verificaPreenchimento()
    {
        bool result = true;
        NEG.ObjetoItauCardNEG objetoItauCardNEG = new NEG.ObjetoItauCardNEG();

        for (int j = 0; j < gvResultado.Rows.Count; j++)
        {
            GridViewRow linha = gvResultado.Rows[j];
            Control centroCusto = linha.FindControl("txtCentroCusto");
            Control ordeminterna = linha.FindControl("txtOrdeminterna");
            Control elementoPep = linha.FindControl("txtElementoPep");
            Control naoEncontrado = linha.FindControl("txtNaoEncontrado");
            if (((TextBox)centroCusto).Text == "" && ((TextBox)ordeminterna).Text == "" && ((TextBox)elementoPep).Text == "")
            {
                result = false;
            }
            else
            {
                if (((TextBox)centroCusto).Enabled == true)
                {
                    if (((TextBox)centroCusto).Text != "")
                    {
                        if (objetoItauCardNEG.CentroCusto(((TextBox)centroCusto).Text) == false)
                        {
                            ((TextBox)naoEncontrado).Text = ((TextBox)centroCusto).Text;
                            ((TextBox)centroCusto).Text = "";
                            result = false;
                        }
                    }
                    else
                    {
                        if (objetoItauCardNEG.Pep(((TextBox)elementoPep).Text) == false)
                        {
                            ((TextBox)naoEncontrado).Text = ((TextBox)elementoPep).Text;
                            ((TextBox)elementoPep).Text = "";
                            result = false;
                        }
                    }
                }
            }
        }
        return result;
    }

    protected void btAtualizar_Click(object sender, EventArgs e)
    {
         
        for (int j = 0; j < gvResultado.Rows.Count; j++)
        {
            GridViewRow linha = gvResultado.Rows[j];
            Label fornecedor = (Label)linha.FindControl("lbFornecedor");
            fornecedor.Text = txtCodigoFornecedor.Text;
        }
    }
}