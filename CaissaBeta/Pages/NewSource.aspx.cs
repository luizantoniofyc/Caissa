using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Classes;
using FrameworkBeta.Persistencia;

public partial class Pages_NewSource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownLists();
            ClearFields();
        }
    }

    protected void BindDropDownLists()
    {
        TipoFonteDB typeDB = new TipoFonteDB();
        ddlSourceType.DataSource = typeDB.Selecionar().Tables[0].DefaultView;
        ddlSourceType.DataValueField = "tif_codigo";
        ddlSourceType.DataTextField = "tif_titulo";
        ddlSourceType.DataBind();
        ddlSourceType.Items.Insert(0, "Select");
    }

    protected void ClearFields()
    {
        txtTitle.Text = string.Empty;
        txtAuthor.Text = string.Empty;
        txtLink.Text = string.Empty;
        txtDescription.Text = string.Empty;
        ddlSourceType.SelectedIndex = 0;
        lblMessage.Visible = false;
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Fonte fon = new Fonte();
        fon.Titulo = txtTitle.Text;
        fon.Autor = txtAuthor.Text;
        fon.LinkExterno = txtLink.Text;
        fon.Descricao = txtDescription.Text;
        fon.TipoFonte = Convert.ToInt32(ddlSourceType.SelectedValue);

        FonteDB fonDB = new FonteDB();
        fonDB.Cadastrar(fon);

        Response.Redirect("Sources.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sources.aspx");
    }
}