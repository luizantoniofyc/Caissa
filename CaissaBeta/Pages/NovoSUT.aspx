<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageStart.master" AutoEventWireup="true" CodeFile="NovoSUT.aspx.cs" Inherits="Pages_NovoSUT" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <div class="row">
        <div class="col-md-12">
            <h3 class="page-header">Add System Under Test</h3>
            <div class="form-group">
                <asp:Label CssClass="label-form-title" runat="server">Title</asp:Label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Enter a title for the system under test"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label CssClass="label-form-title" runat="server">View Title</asp:Label>
                <asp:TextBox ID="txtTituloVisualizacao" runat="server" CssClass="form-control" placeholder="Enter a view title for the system under test"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label CssClass="label-form-title" runat="server">Description</asp:Label>
                <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" placeholder="Insert a brief description of the system under test here."></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="btn-group">
                <asp:Button ID="btnCadastrarSUT" Text="Add" CssClass="btn btn-default" Width="150px" OnClick="btnCadastrarSUT_Click" OnClientClick="return RequiredFieldsOn();" runat="server" />
                <asp:Button ID="btnCancelarSUT" Text="Cancel" CssClass="btn btn-default" Width="150px" OnClick="btnCancelarSUT_Click" OnClientClick="return RequiredFieldsOff();" runat="server" />
            </div>
            <asp:Label ID="lblMensagem" runat="server" ForeColor="#EE0000" Text="* Please, fill all of the required fields."></asp:Label>
        </div>
    </div>

    <script type="text/javascript">
        function RequiredFieldsOn() {
            document.getElementById('txtTitulo').required = 'true';
        }
    </script>

    <script type="text/javascript">
        function RequiredFieldsOff() {
            document.getElementById('txtTitulo').removeAttribute('required');
        }
    </script>

</asp:Content>

