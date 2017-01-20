<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageProject.master" AutoEventWireup="true" CodeFile="NovoTeste.aspx.cs" Inherits="Pages_NovoTeste" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
        
    <div class="row">
        <div class="col-lg-12">
            <ol class="breadcrumb top30">
                <li><a href="#">Home</a></li>
                <li class="active">AddTest</li>
            </ol>
            <h3 class="page-header">Add Test</h3>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Title</asp:Label>
                        <asp:TextBox ID="txtTituloTeste" runat="server" CssClass="form-control" placeholder="Enter a title for the test"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">View Title</asp:Label>
                        <asp:TextBox ID="txtTituloVisualizacaoTeste" runat="server" CssClass="form-control" placeholder="Enter a view title for the test"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Start Date</asp:Label>
                        <asp:TextBox ID="txtDataInicio" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Completion Date</asp:Label>
                        <asp:TextBox ID="txtDataFim" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <!--<div class="form-group">
                    <h4>
                        <asp:Label runat="server">Security</asp:Label>
                    </h4>
                    <asp:DropDownList ID="ddlPropriedadeTeste" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <h4>
                        <asp:Label runat="server">Dimension</asp:Label>
                    </h4>
                    <asp:DropDownList ID="ddlDimensaoTeste" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>-->
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Description</asp:Label>
                        <asp:TextBox ID="txtDescricaoTeste" CssClass="form-control" Height="100px" TextMode="MultiLine" placeholder="Insert a brief description of the test here." runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="btn-group">
                        <asp:Button ID="btnCadastrarTeste" runat="server" CssClass="btn btn-default" Text="Add" Width="150px" OnClick="btnCadastrarTeste_Click" OnClientClick="return RequiredFieldsOn();" />
                        <asp:Button ID="btnCancelarTeste" runat="server" CssClass="btn btn-default" Text="Cancel" Width="150px" OnClick="btnCancelarTeste_Click" OnClientClick="return RequiredFieldsOff();" />
                    </div>
                    <asp:Label ID="lblMensagem" runat="server" ForeColor="#EE0000" Text="* Please, fill all of the required fields."></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function RequiredFieldsOn() {
            document.getElementById('ContentPlaceHolder_txtTituloTeste').required = 'true';
            document.getElementById('ContentPlaceHolder_txtDataInicio').required = 'true';
            document.getElementById('ContentPlaceHolder_txtDataFim').required = 'true';
        }
    </script>

    <script type="text/javascript">
        function RequiredFieldsOff() {
            document.getElementById('ContentPlaceHolder_txtTituloTeste').removeAttribute('required');
            document.getElementById('ContentPlaceHolder_txtDataInicio').removeAttribute('required');
            document.getElementById('ContentPlaceHolder_txtDataFim').removeAttribute('required');
        }
    </script>

</asp:Content>

