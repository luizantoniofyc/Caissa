using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Classes;
using FrameworkBeta.Persistencia;

public partial class Pages_Source : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindDropDownLists();
            bindFields();
            blockEdition();
        }
    }

    protected void bindDropDownLists()
    {
        TipoFonteDB typeDB = new TipoFonteDB();
        ddlSourceType.DataSource = typeDB.Selecionar().Tables[0].DefaultView;
        ddlSourceType.DataValueField = "tif_codigo";
        ddlSourceType.DataTextField = "tif_titulo";
        ddlSourceType.DataBind();
        ddlSourceType.Items.Insert(0, "Select");
    }

    protected void bindFields()
    {
        FonteDB fonDB = new FonteDB();

        int sourceId = Convert.ToInt32(Request.QueryString["submit"]);

        txtTitle.Text = fonDB.SelecionarFonte(sourceId).Tables[0].Rows[0]["fon_titulo"].ToString();
        txtAuthor.Text = fonDB.SelecionarFonte(sourceId).Tables[0].Rows[0]["fon_autor"].ToString();
        txtLink.Text = fonDB.SelecionarFonte(sourceId).Tables[0].Rows[0]["fon_link_externo"].ToString();
        txtDescription.Text = fonDB.SelecionarFonte(sourceId).Tables[0].Rows[0]["fon_descricao"].ToString();
        ddlSourceType.SelectedValue = fonDB.SelecionarFonte(sourceId).Tables[0].Rows[0]["tif_codigo"].ToString();

        lblMessage.Visible = false;
    }

    private void blockEdition()
    {
        txtTitle.Enabled = false;
        txtAuthor.Enabled = false;
        txtLink.Enabled = false;
        txtDescription.Enabled = false;
        ddlSourceType.Enabled = false;

        btnAlter.Visible = true;
        btnDelete.Visible = true;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
    }

    private void releaseEdition()
    {
        txtTitle.Enabled = true;
        txtAuthor.Enabled = true;
        txtLink.Enabled = true;
        txtDescription.Enabled = true;
        ddlSourceType.Enabled = true;

        btnAlter.Visible = false;
        btnDelete.Visible = false;
        btnUpdate.Visible = true;
        btnCancel.Visible = true;
    }

    protected void btnAlter_Click(object sender, EventArgs e)
    {
        ddlSourceType.Items.Clear();
        bindDropDownLists();
        bindFields();
        releaseEdition();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Fonte fon = new Fonte();

        int sourceId = Convert.ToInt32(Request.QueryString["submit"]);

        fon.Codigo = sourceId;
        fon.Titulo = txtTitle.Text;
        fon.Autor = txtAuthor.Text;
        fon.LinkExterno = txtLink.Text;
        fon.Descricao = txtDescription.Text;
        fon.TipoFonte = Convert.ToInt32(ddlSourceType.SelectedValue);

        FonteDB fonDB = new FonteDB();
        fonDB.Atualizar(fon);

        Response.Redirect("Source.aspx?submit=" + sourceId);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        int sourceId = Convert.ToInt32(Request.QueryString["submit"]);

        Response.Redirect("Source.aspx?submit=" + sourceId);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        FonteDB fonDB = new FonteDB();

        int sourceId = Convert.ToInt32(Request.QueryString["submit"]);

        fonDB.Inativar(sourceId);

        Response.Redirect("Sources.aspx");
    }
}