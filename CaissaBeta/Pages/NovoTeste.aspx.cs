using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta;
using FrameworkBeta.Classes;
using FrameworkBeta.Persistencia;

public partial class Pages_NovoTeste : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            popularDropdownLists();
            limparCampos();
        }
    }

    protected void popularDropdownLists()
    {
        DimensaoDB dimDB = new DimensaoDB();
        ddlDimensaoTeste.DataSource = dimDB.Selecionar().Tables[0].DefaultView;
        ddlDimensaoTeste.DataTextField = "dim_titulo";
        ddlDimensaoTeste.DataValueField = "dim_codigo";
        ddlDimensaoTeste.DataBind();
        ddlDimensaoTeste.Items.Insert(0, "Selecione");
        ddlDimensaoTeste.SelectedIndex = 0;

        PropriedadeDB proDB = new PropriedadeDB();
        ddlPropriedadeTeste.DataSource = proDB.Selecionar().Tables[0].DefaultView;
        ddlPropriedadeTeste.DataTextField = "pro_titulo";
        ddlPropriedadeTeste.DataValueField = "pro_codigo";
        ddlPropriedadeTeste.DataBind();
        ddlPropriedadeTeste.Items.Insert(0, "Selecione");
        ddlPropriedadeTeste.SelectedIndex = 0;
    }

    protected void limparCampos()
    {
        txtTituloTeste.Text = string.Empty;
        txtTituloVisualizacaoTeste.Text = string.Empty;
        txtDescricaoTeste.Text = string.Empty;
        txtDataInicio.Text = string.Empty;
        txtDataFim.Text = string.Empty;
        ddlDimensaoTeste.SelectedIndex = 0;
        ddlPropriedadeTeste.SelectedIndex = 0;
        lblMensagem.Visible = false;
    }

    protected void btnCadastrarTeste_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(txtDataInicio.Text) <= Convert.ToDateTime(txtDataFim.Text))
        {
            Teste tes = new Teste();
            tes.Titulo = txtTituloTeste.Text;
            tes.TituloVisualizacao = txtTituloVisualizacaoTeste.Text;
            tes.Descricao = txtDescricaoTeste.Text;
            tes.DataInicio = Convert.ToDateTime(txtDataInicio.Text);
            tes.DataFim = Convert.ToDateTime(txtDataFim.Text);
            tes.SysteUnderTest = Convert.ToInt32(Session["SUT"]);
            //tes.Propriedade = Convert.ToInt32(ddlPropriedadeTeste.SelectedValue);
            //tes.Dimensao = Convert.ToInt32(ddlDimensaoTeste.SelectedValue);

            TesteDB tesDB = new TesteDB();
            tesDB.Cadastrar(tes);

            //TreeView treeview = (TreeView)Page.Master.FindControl("tvwTeste");
            //string textoNode = txtTituloTeste.Text;
            //string valorNode = "1" + tesDB.codigoTeste.ToString();

            //funcao.inserirNode(treeview, 0, textoNode, valorNode);

            //state.SaveTreeView(treeview, "TreeViewState", HttpContext.Current);

            Response.Redirect("Teste.aspx?submit=" + tesDB.codigoTeste);
        }
        else { lblMensagem.Text = "* Data início não pode ser maior do que a data fim."; lblMensagem.Visible = true; }
    }

    protected void btnCancelarTeste_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}