<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageStart.master" AutoEventWireup="true" CodeFile="Start.aspx.cs" Inherits="Start" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>

            <div id="page-wrapper">
                <div class="container-fluid">

                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <h3>Choose the SUT to get started:</h3>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <asp:ListBox ID="lbSistema" AutoPostBack="true" CssClass="listbox" multiple="" OnSelectedIndexChanged="lbSistema_SelectedIndexChanged" runat="server"></asp:ListBox>
                        </div>
                    </div>

                    <div class="row top15">
                        <div class="col-lg-12 text-center">
                            <div class="btn-group">
                                <asp:Button ID="btnCarregar" CssClass="btn btn-default" Width="150px" runat="server" OnClick="btnCarregar_Click" Text="Load" />
                                <asp:Button ID="btnNovo" CssClass="btn btn-default" Width="150px" runat="server" OnClick="btnNovo_Click" Text="Create" />
                                <asp:Button ID="btnExcluir" CssClass="btn btn-default" Width="150px" runat="server" OnClick="btnExcluir_Click" OnClientClick="return ShowConfirm(this.id,0);" Text="Delete" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <asp:Label ID="lblMensagem" runat="server" ForeColor="#EE0000" Text="* Você deve selecionar um SUT para continuar."></asp:Label>
                        </div>
                    </div>

                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

