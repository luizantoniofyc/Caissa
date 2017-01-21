<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageProject.master" AutoEventWireup="true" CodeFile="NewSource.aspx.cs" Inherits="Pages_NewSource" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <div class="row">
        <div class="col-lg-12">
            <ol class="breadcrumb top30">
                <li><a href="#">Home</a></li>
                <li><a href="#">Sources</a></li>
                <li class="active">Source</li>
            </ol>
            <h3 class="page-header">Source</h3>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Title</asp:Label>
                        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Author</asp:Label>
                        <asp:TextBox ID="txtAuthor" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">External Link</asp:Label>
                        <asp:TextBox ID="txtLink" CssClass="form-control" TextMode="Url" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Source Type</asp:Label>
                        <asp:DropDownList ID="ddlSourceType" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Description</asp:Label>
                        <asp:TextBox ID="txtDescription" 
                                        CssClass="form-control" 
                                        TextMode="MultiLine" 
                                        Rows="3" 
                                        placeholder="Insert a brief description of the source here." 
                                        runat="server">
                        </asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="btn-group">
                        <asp:Button ID="btnInsert" 
                                    CssClass="btn btn-default" 
                                    Text="Add" 
                                    Width="150px" 
                                    OnClick="btnInsert_Click" 
                                    OnClientClick="return RequiredFieldsOn();" 
                                    runat="server" />
                        <asp:Button ID="btnCancel" 
                                    CssClass="btn btn-default" 
                                    Text="Cancel" 
                                    Width="150px" 
                                    OnClick="btnCancel_Click" 
                                    OnClientClick="return RequiredFieldsOff();" 
                                    runat="server" />
                    </div>
                    <asp:Label ID="lblMessage" 
                                ForeColor="#EE0000" 
                                Text="* Please, fill all of the required fields." 
                                runat="server">
                    </asp:Label>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function RequiredFieldsOn() {
            document.getElementById('ContentPlaceHolder_txtTitle').required = 'true';
            document.getElementById('ContentPlaceHolder_txtAuthor').required = 'true';
        }
    </script>

    <script type="text/javascript">
        function RequiredFieldsOff() {
            document.getElementById('ContentPlaceHolder_txtTitle').removeAttribute('required');
            document.getElementById('ContentPlaceHolder_txtAuthor').removeAttribute('required');
        }
    </script>

</asp:Content>

