<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageProject.master" AutoEventWireup="true" CodeFile="NewEvaluationItem.aspx.cs" Inherits="Pages_NewEvaluationItem" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <div class="row">
        <div class="col-lg-12">
            <ol class="breadcrumb top30">
                <li><a href="#">Home</a></li>
                <li><a href="#">AssessmentItem</a></li>
                <li class="active">AssessmentItem</li>
            </ol>
            <h3 class="page-header">Assessment Item</h3>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Identifier</asp:Label>
                        <asp:TextBox ID="txtIdentifier" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Title</asp:Label>
                        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Expected Result</asp:Label>
                        <asp:TextBox ID="txtExpectedResult" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Source</asp:Label>
                        <asp:DropDownList ID="ddlSource" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">DivDM</asp:Label>
                        <asp:TextBox ID="txtDivDM" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">DivPP</asp:Label>
                        <asp:TextBox ID="txtDivPP" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">CovLoc</asp:Label>
                        <asp:TextBox ID="txtCovLoc" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Label CssClass="label-form-title" runat="server">Procedure</asp:Label>
                        <asp:TextBox ID="txtProcedure" 
                                        CssClass="form-control" 
                                        TextMode="MultiLine" 
                                        Rows="3" 
                                        placeholder="Insert a brief description of the procedure of the assessment item here." 
                                        runat="server">
                        </asp:TextBox>
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
                                        placeholder="Insert a brief description of the assessment item here." 
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

