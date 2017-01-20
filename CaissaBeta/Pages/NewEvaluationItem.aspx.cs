using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameworkBeta.Classes;
using FrameworkBeta.Persistencia;

public partial class Pages_NewEvaluationItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownLists();
            ClearFields();
        }
    }

    protected double CalculateLocalCoverage(double diversity, double count)
    {
        double local_coverage = 0.0;

        if ((local_coverage = diversity / count) >= 1.0)
            return 1.0;
        else
            return local_coverage;
    }

    protected double CalculateDiversity(double value)
    {
        int i, j, max_dim = 6;
        int[] lista = new int[6];

        double[,] grafo =
        {
            { 0.0, 0.5, 0.2, 0.6, 0.7, 0.9 },
            { 0.0, 0.0, 0.9, 0.7, 0.6, 0.8 },
            { 0.0, 0.0, 0.0, 0.4, 0.2, 0.6 },
            { 0.0, 0.0, 0.0, 0.0, 0.5, 0.2 },
            { 0.0, 0.0, 0.0, 0.0, 0.0, 0.8 },
            { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
        };

        for (i = 0; i < max_dim; i++)
        {
            if (lista[i] == 1)
            {
                for (j = 0; j < max_dim; j++)
                {
                    if (grafo[i,j] > 0.0 && lista[j] == 1)
                    {
                        value = value + grafo[i,j];
                    }
                }
            }
        }
        return value;
    }

    protected void BindDropDownLists()
    {
        FonteDB fonDB = new FonteDB();
        ddlSource.DataSource = fonDB.Selecionar().Tables[0].DefaultView;
        ddlSource.DataValueField = "fon_codigo";
        ddlSource.DataTextField = "fon_titulo";
        ddlSource.DataBind();
        ddlSource.Items.Insert(0, "Select");
    }

    protected void ClearFields()
    {
        txtIdentifier.Text = string.Empty;
        txtTitle.Text = string.Empty;
        txtExpectedResult.Text = string.Empty;
        txtDivDM.Text = string.Empty;
        txtDivPP.Text = string.Empty;
        txtCovLoc.Text = string.Empty;
        txtProcedure.Text = string.Empty;
        txtDescription.Text = string.Empty;
        ddlSource.SelectedIndex = 0;
        lblMessage.Visible = false;
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Controle con = new Controle
        {
            Sigla = txtIdentifier.Text,
            Titulo = txtTitle.Text,
            ResultadoEsperado = txtExpectedResult.Text,
            Source = Convert.ToInt32(ddlSource.SelectedValue),
            DivDM = Convert.ToDouble(txtDivDM.Text),
            DivPP = Convert.ToDouble(txtDivPP.Text),
            CovLoc = Convert.ToDouble(txtDivPP.Text),
            Procedimento = txtProcedure.Text,
            Descricao = txtDescription.Text
        };

        ControleDB conDB = new ControleDB();
        conDB.Cadastrar(con);

        Response.Redirect("EvaluationItems.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EvaluationItems.aspx");
    }
}