using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Classes;
using FrameworkBeta.Persistencia;

public partial class Pages_VisualizarControle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindLiteral();
            BindRepeater();
        }
    }

    private void BindLiteral()
    {
        TesteDB tesDB = new TesteDB();
        int testId = Convert.ToInt32(Request.QueryString["submit"]);
        lTest.Text = tesDB.SelecionarTeste(testId).Tables[0].Rows[0]["tes_titulo_visualizacao"].ToString();
    }

    private void BindRepeater()
    {
        TesteDB tesDB = new TesteDB();
        int testId = Convert.ToInt32(Request.QueryString["submit"]);
        rpEvaluationItems.DataSource = tesDB.SelecionarItensAvaliacaoTeste(testId).Tables[0].DefaultView;
        rpEvaluationItems.DataBind();
    }

    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Response.Write(e.CommandArgument);
        }
    }

    protected void btnBackward_Click(object sender, EventArgs e)
    {
        int testId = Convert.ToInt32(Request.QueryString["submit"]);
        Response.Redirect("Teste.aspx?submit=" + testId);
    }

    protected void btnUnbindItem_Click(object sender, EventArgs e)
    {
        int testId = Convert.ToInt32(Request.QueryString["submit"]);

        foreach (RepeaterItem item in rpEvaluationItems.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                var checkBox = (CheckBox)item.FindControl("chkUnbindItem");

                if (checkBox.Checked)
                {
                    TesteDB tesDB = new TesteDB();
                    int itemId = Convert.ToInt32(checkBox.Attributes["data-value"]);
                    tesDB.DesvincularItemAvaliacaoTeste(itemId);
                }
            }
        }
        Response.Redirect("Teste.aspx?submit=" + testId.ToString());
    }
}