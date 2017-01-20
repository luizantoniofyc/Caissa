<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageProject.master" AutoEventWireup="true" CodeFile="SUT.aspx.cs" Inherits="Pages_SUT" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    
    <div class="row">
        <div class="col-lg-12">
            <ol class="breadcrumb top30">
                <li><a href="#">Home</a></li>
                <li class="active">SUT</li>
            </ol>
            <h3 class="page-header">System Under Test</h3>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Title</asp:Label>
                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">View Title</asp:Label>
                        <asp:TextBox ID="txtTituloVisualizacao" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Description</asp:Label>
                        <asp:TextBox ID="txtDescricao" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control" placeholder="Insert a brief description of the system under test here."></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="btn-group">
                        <asp:Button ID="btnAlterarSUT" Text="Modify" CssClass="btn btn-default" Width="150px" OnClick="btnAlterarSUT_Click" runat="server" />
                        <asp:Button ID="btnSalvarSUT" Text="Save" CssClass="btn btn-default" Width="150px" OnClick="btnSalvarSUT_Click" runat="server" />
                        <asp:Button ID="btnCancelarSUT" Text="Cancel" CssClass="btn btn-default" Width="150px" OnClick="btnCancelarSUT_Click" runat="server" />
                    </div>
                    <asp:Label ID="lblMensagem" runat="server" ForeColor="#EE0000" Text="* Please, fill all of the required fields."></asp:Label>
                </div>
            </div>
        </div>
    </div>

    

</asp:Content>

