using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta;
using FrameworkBeta.Classes;
using FrameworkBeta.Persistencia;

//using jena framework
using com.hp.hpl.jena;
using com.hp.hpl.jena.rdf.model.impl;
using com.hp.hpl.jena.rdf.model;
using com.hp.hpl.jena.util;
using com.hp.hpl.jena.ontology;
using com.hp.hpl.jena.util.iterator;

using java.io;

public partial class Pages_AlterarTeste : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindLiteral();
            bloquearEdicao();
            popularDropDownLists();
            //popularFormulario();
            carregarCampos();
        }
    }

    private void BindLiteral()
    {
        TesteDB tesDB = new TesteDB();
        int testId = Convert.ToInt32(Request.QueryString["submit"]);
        lTest.Text = tesDB.SelecionarTeste(testId).Tables[0].Rows[0]["tes_titulo_visualizacao"].ToString();
    }

    private void bloquearEdicao()
    {
        txtTituloTeste.Enabled = false;
        txtTituloVisualizacaoTeste.Enabled = false;
        txtDescricaoTeste.Enabled = false;
        txtDataInicio.Enabled = false;
        txtDataFim.Enabled = false;
        txtTotCov.Enabled = false;
        ddlPropriedadeTeste.Enabled = false;
        ddlDimensaoTeste.Enabled = false;

        btnControleVinculado.Enabled = true;
        btnIncluirControle.Enabled = true;
        btnControleVinculado.CssClass = "btn btn-default";
        btnIncluirControle.CssClass = "btn btn-default";

        btnExcluirTeste.Visible = true;
        btnAlterarTeste.Visible = true;
        btnSalvarTeste.Visible = false;
        btnCancelarTeste.Visible = false;
    }
    private void desbloquearEdicao()
    {
        txtTituloTeste.Enabled = true;
        txtTituloVisualizacaoTeste.Enabled = true;
        txtDescricaoTeste.Enabled = true;
        txtDataInicio.Enabled = true;
        txtDataFim.Enabled = true;
        ddlPropriedadeTeste.Enabled = true;
        ddlDimensaoTeste.Enabled = true;

        btnControleVinculado.Enabled = false;
        btnIncluirControle.Enabled = false;
        btnControleVinculado.CssClass = "btn btn-default disabled";
        btnIncluirControle.CssClass = "btn btn-default disabled";

        btnExcluirTeste.Visible = false;
        btnAlterarTeste.Visible = false;
        btnSalvarTeste.Visible = true;
        btnCancelarTeste.Visible = true;
    }
    private void popularFormulario()
    {
        string NS = "http://wwwsemanticweb.org/ontologies/Portaria141_V1.owl#";

        string inputFileName = @"C:\Sites\frameworkbetav3.noip.me\Repository\Ontologies\Portaria141\Portaria141_V1.owl";

        //string inputFileName = @"C:\Users\usuario\Documents\Visual Studio 2013\WebSites\FrameworkBeta\Repository\Ontologies\e-GovSecAOnto\e-GovSecAOnto.owl";

        //string dmFileName = @"C:\Users\usuario\Documents\Visual Studio 2013\WebSites\FrameworkBeta\Repository\Ontologies\e-GovSecAOnto\ont-policy.rdf";

        InputStream inputStream = FileManager.get().open(inputFileName);
        if (inputStream == null)
        {
            throw new ArgumentException("File: " + inputFileName + " not found.");
        }

        //OntDocumentManager dm = new OntDocumentManager(dmFileName);
        //OntModelSpec modelSpec = new OntModelSpec(OntModelSpec.OWL_DL_MEM_TRANS_INF);
        //OntModelSpec modelSpec = new OntModelSpec(OntModelSpec.OWL_DL_MEM);
        //modelSpec.setDocumentManager(dm);
        OntModel m = ModelFactory.createOntologyModel();

        m.read(inputStream, "");

        OntClass assetClass = m.getOntClass(NS + "Security");

        Label abreAspas = new Label();
        abreAspas.Text = "( ";

        propriedade.Controls.Add(abreAspas);

        Label lblOntPropriedade = new Label();
        lblOntPropriedade.Text += assetClass.getLocalName().ToString();
        lblOntPropriedade.ToolTip = assetClass.getComment("").ToString();
        lblOntPropriedade.BackColor = System.Drawing.Color.LightGray;

        propriedade.Controls.Add(lblOntPropriedade);

        Label fechaAspas = new Label();
        fechaAspas.Text = " )";

        propriedade.Controls.Add(fechaAspas);

        for ( java.util.Iterator iter = assetClass.listSubClasses(); iter.hasNext(); )
        {
            OntClass c = (OntClass)iter.next();

            PropriedadeDB proDB = new PropriedadeDB();

            string localName = c.getLocalName().ToString();
            string localValue = proDB.SelecionarOnt(localName).Tables[0].Rows[0]["pro_codigo"].ToString();
            string localComment = c.getComment("");
            string r = System.Drawing.Color.LightGray.R.ToString("X2");
            string g = System.Drawing.Color.LightGray.G.ToString("X2");
            string b = System.Drawing.Color.LightGray.B.ToString("X2");

            ListItem item = new ListItem(localName, localValue);
            item.Attributes["title"] = localComment;
            item.Attributes["style"] = string.Format("background:#{0}{1}{2}", r, g, b);
            ddlPropriedadeTeste.Items.Add(item);
        }    
    }
    private void carregarCampos()
    {
        TesteDB tesDB = new TesteDB();

        int teste_codigo = Convert.ToInt32(Request.QueryString["submit"]);

        txtTituloTeste.Text = tesDB.SelecionarTeste(teste_codigo).Tables[0].Rows[0]["tes_titulo"].ToString();
        txtTituloVisualizacaoTeste.Text = tesDB.SelecionarTeste(teste_codigo).Tables[0].Rows[0]["tes_titulo_visualizacao"].ToString();
        txtDescricaoTeste.Text = tesDB.SelecionarTeste(teste_codigo).Tables[0].Rows[0]["tes_descricao_objetivo"].ToString();
        txtDataInicio.Text = Convert.ToDateTime(tesDB.SelecionarTeste(teste_codigo).Tables[0].Rows[0]["tes_data_inicio"].ToString()).ToString("yyyy-MM-dd");
        txtDataFim.Text = Convert.ToDateTime(tesDB.SelecionarTeste(teste_codigo).Tables[0].Rows[0]["tes_data_fim"].ToString()).ToString("yyyy-MM-dd");
        txtTotCov.Text = tesDB.SelecionarTeste(teste_codigo).Tables[0].Rows[0]["cov_tot"].ToString();
        //ddlDimensaoTeste.SelectedValue = tesDB.SelecionarTeste(teste_codigo).Tables[0].Rows[0]["dim_codigo"].ToString();
        //ddlPropriedadeTeste.SelectedValue = tesDB.SelecionarTeste(teste_codigo).Tables[0].Rows[0]["pro_codigo"].ToString();

        //txtTituloTeste.Text = tesDB.SelecionarTeste(Convert.ToInt32(Session["valorRecuperadoNode"])).Tables[0].Rows[0]["tes_titulo"].ToString();
        //txtDescricaoTeste.Text = tesDB.SelecionarTeste(Convert.ToInt32(Session["valorRecuperadoNode"])).Tables[0].Rows[0]["tes_descricao_objetivo"].ToString();
        //txtDataInicio.Text = Convert.ToDateTime(tesDB.SelecionarTeste(Convert.ToInt32(Session["valorRecuperadoNode"])).Tables[0].Rows[0]["tes_data_inicio"].ToString()).ToString("yyyy-MM-dd");
        //txtDataFim.Text = Convert.ToDateTime(tesDB.SelecionarTeste(Convert.ToInt32(Session["valorRecuperadoNode"])).Tables[0].Rows[0]["tes_data_fim"].ToString()).ToString("yyyy-MM-dd");
        //ddlDimensaoTeste.SelectedValue = tesDB.SelecionarTeste(Convert.ToInt32(Session["valorRecuperadoNode"])).Tables[0].Rows[0]["dim_codigo"].ToString();
        //ddlPropriedadeTeste.SelectedValue = tesDB.SelecionarTeste(Convert.ToInt32(Session["valorRecuperadoNode"])).Tables[0].Rows[0]["pro_codigo"].ToString();

        lblMensagem.Visible = false;
    }
    private void popularDropDownLists()
    {
        DimensaoDB dimDB = new DimensaoDB();
        ddlDimensaoTeste.DataSource = dimDB.Selecionar().Tables[0].DefaultView;
        ddlDimensaoTeste.DataTextField = "dim_titulo";
        ddlDimensaoTeste.DataValueField = "dim_codigo";
        ddlDimensaoTeste.DataBind();
        ddlDimensaoTeste.Items.Insert(0, "Select");

        PropriedadeDB proDB = new PropriedadeDB();
        ddlPropriedadeTeste.DataSource = proDB.Selecionar().Tables[0].DefaultView;
        ddlPropriedadeTeste.DataTextField = "pro_titulo";
        ddlPropriedadeTeste.DataValueField = "pro_codigo";
        ddlPropriedadeTeste.DataBind();
        ddlPropriedadeTeste.Items.Insert(0, "Select");
    }
    protected void btnSalvarTeste_Click(object sender, EventArgs e)
    {
        Teste tes = new Teste();

        int teste_codigo = Convert.ToInt32(Request.QueryString["submit"]);

        tes.Codigo = Convert.ToInt32(teste_codigo);
        tes.Titulo = txtTituloTeste.Text;
        tes.TituloVisualizacao = txtTituloVisualizacaoTeste.Text;
        tes.Descricao = txtDescricaoTeste.Text;
        tes.DataInicio = Convert.ToDateTime(txtDataInicio.Text);
        tes.DataFim = Convert.ToDateTime(txtDataFim.Text);
        //tes.Propriedade = Convert.ToInt32(ddlPropriedadeTeste.SelectedValue);
        //tes.Dimensao = Convert.ToInt32(ddlDimensaoTeste.SelectedValue);

        TesteDB tesDB = new TesteDB();
        tesDB.Atualizar(tes);

        //Session["isSelected"] = "S";

        Response.Redirect("Teste.aspx?submit=" + teste_codigo);
    }
    protected void btnAlterarTeste_Click(object sender, EventArgs e)
    {
        ddlPropriedadeTeste.Items.Clear();
        popularDropDownLists();
        //popularFormulario();
        carregarCampos();
        desbloquearEdicao();
    }
    protected void btnExcluirTeste_Click(object sender, EventArgs e)
    {
        TesteDB tesDB = new TesteDB();

        int teste_codigo = Convert.ToInt32(Request.QueryString["submit"]);

        tesDB.Inativar(Convert.ToInt32(teste_codigo));

        //TreeView treeview = new TreeView();
        //treeview = (TreeView)Page.Master.FindControl("tvwTeste");

        //funcao.removerNode(treeview, "");

        //state.SaveTreeView(treeview, "TreeViewState", HttpContext.Current);

        Response.Redirect("Index.aspx");
    }
    protected void btnCancelarTeste_Click(object sender, EventArgs e)
    {
        int testId = Convert.ToInt32(Request.QueryString["submit"]);
        Response.Redirect("Teste.aspx?submit=" + testId);
    }

    protected void btnControleVinculado_Click(object sender, EventArgs e)
    {
        int testId = Convert.ToInt32(Request.QueryString["submit"]);
        Response.Redirect("VisualizarControle.aspx?submit=" + testId);
    }

    protected void btnIncluirControle_Click(object sender, EventArgs e)
    {
        int testId = Convert.ToInt32(Request.QueryString["submit"]);
        Response.Redirect("IncluirControle.aspx?submit=" + testId);
    }
}