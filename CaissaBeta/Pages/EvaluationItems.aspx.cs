using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Persistencia;

public partial class Pages_EvaluationItems : System.Web.UI.Page
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
        ControleDB conDB = new ControleDB();

        rpEvaluationItems.DataSource = conDB.Selecionar().Tables[0].DefaultView;
        rpEvaluationItems.DataBind();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewEvaluationItem.aspx");
    }

    protected void btnEdit_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("EvaluationItem.aspx");
        }
    }

    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            ControleDB conDB = new ControleDB();
            int itemId = Convert.ToInt32(e.CommandArgument);
            conDB.Inativar(itemId);

            Response.Redirect("EvaluationItems.aspx");
        }
    }
}