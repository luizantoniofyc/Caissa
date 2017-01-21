using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Classes;
using FrameworkBeta.Persistencia;

public partial class Pages_NovoSUT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMensagem.Visible = false;
    }
    protected void btnCadastrarSUT_Click(object sender, EventArgs e)
    {
        if (txtTitulo.Text.Trim() != string.Empty)
        {
            if (txtDescricao.Text.Trim() != string.Empty)
            {
                SystemUnderTest sut = new SystemUnderTest();
                sut.Titulo = txtTitulo.Text;
                sut.TituloVisualizacao = txtTituloVisualizacao.Text;
                sut.Descricao = txtDescricao.Text;

                SystemUnderTestDB sutDB = new SystemUnderTestDB();
                sutDB.Cadastrar(sut);

                Response.Redirect("/Start.aspx");
            }
            else { lblMensagem.Visible = true; }
        }
        else { lblMensagem.Visible = true; }
    }
    protected void btnCancelarSUT_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Start.aspx");
    }
}