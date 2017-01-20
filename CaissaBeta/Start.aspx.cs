using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Persistencia;

public partial class Start : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            popularLista();
        }
    }
    protected void popularLista()
    {
        SystemUnderTestDB sutDB = new SystemUnderTestDB();
        lbSistema.DataSource = sutDB.Selecionar().Tables[0].DefaultView;
        lbSistema.DataTextField = "sut_titulo";
        lbSistema.DataValueField = "sut_codigo";
        lbSistema.DataBind();

        lblMensagem.Visible = false;
    }
    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pages/NovoSUT.aspx");
    }
    protected void btnCarregar_Click(object sender, EventArgs e)
    {
        if (lbSistema.SelectedIndex > -1)
        {
            Session["SUT"] = lbSistema.SelectedItem.Value;
            Response.Redirect("Pages/Index.aspx");
        }
        else { lblMensagem.Visible = true; }
    }
    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        if (lbSistema.SelectedIndex > -1)
        {
            SystemUnderTestDB sutDB = new SystemUnderTestDB();

            sutDB.Inativar(Convert.ToInt32(lbSistema.SelectedValue));
            popularLista();
        }
        else { lblMensagem.Visible = true; }
    }
    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        Session["SUT"] = lbSistema.SelectedValue;

        Response.Redirect("Pages/SUT.aspx");
    }
    protected void lbSistema_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensagem.Visible = false;
    }
}