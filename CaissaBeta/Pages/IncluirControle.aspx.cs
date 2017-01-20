using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Classes;
using FrameworkBeta.Persistencia;

public partial class Pages_IncluirControle : System.Web.UI.Page
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

    protected void BindRepeater()
    {
        ControleDB conDB = new ControleDB();
        int testId = Convert.ToInt32(Request.QueryString["submit"]);
        rpEvaluationItems.DataSource = conDB.SelecionarItemAvaliacaoTeste(testId).Tables[0].DefaultView;
        rpEvaluationItems.DataBind();
    }

    protected void btnBackward_Click(object sender, EventArgs e)
    {
        int testId = Convert.ToInt32(Request.QueryString["submit"]);
        Response.Redirect("Teste.aspx?submit=" + testId);
    }

    protected void btnIncludeItem_Click(object sender, EventArgs e)
    {
        int testId = Convert.ToInt32(Request.QueryString["submit"]);

        foreach (RepeaterItem item in rpEvaluationItems.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                var checkBox = (CheckBox)item.FindControl("chkBindItem");

                if (checkBox.Checked)
                {
                    TesteDB tesDB = new TesteDB();
                    int itemId = Convert.ToInt32(checkBox.Attributes["data-value"]);
                    tesDB.VincularItemAvaliacao(testId, itemId);
                }
            }
        }
        Response.Redirect("Teste.aspx?submit=" + testId.ToString());
    }
}