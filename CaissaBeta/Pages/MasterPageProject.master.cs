using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FrameworkBeta;
using FrameworkBeta.Persistencia;

public partial class Pages_ProjectMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sistema.Title = getSystemTitle();
            lblSistema.Text = "SUT - " + getSystemViewTitle();
            BindRepeater();
        }
    }

    private void BindRepeater()
    {
        TesteDB tesDB = new TesteDB();

        rptTeste.DataSource = tesDB.SelecionarTesteSUT(Convert.ToInt32(Session["SUT"])).Tables[0].DefaultView;
        rptTeste.DataBind();
    }

    private string getSystemTitle()
    {
        SystemUnderTestDB sutDB = new SystemUnderTestDB();

        return sutDB.SelecionarSUT(Convert.ToInt32(Session["SUT"])).Tables[0].Rows[0]["sut_titulo"].ToString();
    }

    private string getSystemViewTitle()
    {
        SystemUnderTestDB sutDB = new SystemUnderTestDB();

        return sutDB.SelecionarSUT(Convert.ToInt32(Session["SUT"])).Tables[0].Rows[0]["sut_titulo_visualizacao"].ToString();
    }

    protected void rptSUT_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TesteDB tesDB = new TesteDB();

            DataRowView dr = e.Item.DataItem as DataRowView;

            Repeater rptTeste = (Repeater)e.Item.FindControl("rptTeste");
            rptTeste.DataSource = tesDB.SelecionarTesteSUT(Convert.ToInt32(dr.Row["sut_codigo"])).Tables[0].DefaultView;
            rptTeste.DataBind();
        }
    }

    protected void btnCadastrarTeste_Click(object sender, EventArgs e)
    {

    }
}
