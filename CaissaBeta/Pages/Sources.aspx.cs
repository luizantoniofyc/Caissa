using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Persistencia;

public partial class Pages_Sources : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRepeater();
        }
    }

    protected void BindRepeater()
    {
        FonteDB fonDB = new FonteDB();

        rpSource.DataSource = fonDB.Selecionar().Tables[0].DefaultView;
        rpSource.DataBind();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewSource.aspx");
    }

    protected void btnEdit_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("Source.aspx?submit=" + e.CommandArgument);
        }
    }

    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            FonteDB fonDB = new FonteDB();
            int sourceId = Convert.ToInt32(e.CommandArgument);
            fonDB.Deletar(sourceId);

            Response.Redirect("Sources.aspx");
        }
    }
}