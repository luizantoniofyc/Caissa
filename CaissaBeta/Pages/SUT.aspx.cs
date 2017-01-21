using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Classes;
using FrameworkBeta.Persistencia;

public partial class Pages_SUT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bloquearEdicao();
            carregarCampos();
        }
    }
    private void carregarCampos()
    {
        SystemUnderTestDB sutDB = new SystemUnderTestDB();
        txtTitulo.Text = sutDB.SelecionarSUT(Convert.ToInt32(Session["SUT"])).Tables[0].Rows[0]["sut_titulo"].ToString();
        txtTituloVisualizacao.Text = sutDB.SelecionarSUT(Convert.ToInt32(Session["SUT"])).Tables[0].Rows[0]["sut_titulo_visualizacao"].ToString();
        txtDescricao.Text = sutDB.SelecionarSUT(Convert.ToInt32(Session["SUT"])).Tables[0].Rows[0]["sut_descricao"].ToString();
        lblMensagem.Visible = false;
    }
    private void bloquearEdicao()
    {
        txtTitulo.Enabled = false;
        txtTituloVisualizacao.Enabled = false;
        txtDescricao.Enabled = false;

        btnAlterarSUT.Visible = true;
        btnSalvarSUT.Visible = false;
        btnCancelarSUT.Visible = false;
    }
    private void desbloquearEdicao()
    {
        txtTitulo.Enabled = true;
        txtTituloVisualizacao.Enabled = true;
        txtDescricao.Enabled = true;

        btnAlterarSUT.Visible = false;
        btnSalvarSUT.Visible = true;
        btnCancelarSUT.Visible = true;
    }
    protected void btnAlterarSUT_Click(object sender, EventArgs e)
    {
        carregarCampos();
        desbloquearEdicao();
    }
    protected void btnCancelarSUT_Click(object sender, EventArgs e)
    {
        Response.Redirect("SUT.aspx");
    }

    protected void btnSalvarSUT_Click(object sender, EventArgs e)
    {
        SystemUnderTest sut = new SystemUnderTest();
        sut.Codigo = Convert.ToInt32(Session["SUT"]);
        sut.Titulo = txtTitulo.Text;
        sut.TituloVisualizacao = txtTituloVisualizacao.Text;
        sut.Descricao = txtDescricao.Text;

        SystemUnderTestDB sutDB = new SystemUnderTestDB();
        sutDB.Atualizar(sut);

        Response.Redirect("SUT.aspx");
    }
}