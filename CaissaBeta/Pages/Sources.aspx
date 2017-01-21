<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageProject.master" AutoEventWireup="true" CodeFile="Sources.aspx.cs" Inherits="Pages_Sources" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <div class="row">
        <div class="col-lg-12">
            <ol class="breadcrumb top30">
                <li><a href="#">Home</a></li>
                <li class="active">Sources</li>
            </ol>
            <h3 class="page-header">Sources</h3>
            <div class="row">
                <div class="col-lg-12">
                    <div class="btn-group pull-right">
                        <asp:LinkButton ID="btnInsert" CssClass="btn btn-default" OnClick="btnInsert_Click" runat="server">
                            <span class="fa fa-plus fa-fw"></span> Register
                        </asp:LinkButton>
                    </div>
                </div>
            </div>

            <div class="row top20">
                <div class="col-lg-12">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            All Registered Sources
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="dataTable_wrapper">
                                <table class="table table-striped table-bordered table-hover" id="dataTable_Sources">
                                    <thead>
                                        <tr>
                                            <th>Source Title</th>
                                            <th>Authorship</th>
                                            <th>External Link</th>
                                            <th>Source Type</th>
                                            <th title="Global Coverage of the Source" class="text-center">CovGlo</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpSource" runat="server">
                                            <ItemTemplate>
                                                <tr class="odd gradeA">
                                                    <td><%# Eval("fon_titulo") %></td>
                                                    <td><%# Eval("fon_autor") %></td>
                                                    <td><%# Eval("fon_link_externo") %></td>
                                                    <td><%# Eval("tif_titulo") %></td>
                                                    <td class="text-center"><%# Eval("cov_glo") %></td>
                                                    <td class="text-center">
                                                        <div class="btn-group">
                                                            <asp:LinkButton ID="btnEdit" 
                                                                            CssClass="btn btn-default"
                                                                            CommandArgument='<%# Eval("fon_codigo") %>'
                                                                            CommandName="Edit" 
                                                                            OnCommand="btnEdit_Command"
                                                                            runat="server">
                                                                <span class="fa fa-edit fa-fw"></span>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="btnDelete" 
                                                                            CssClass="btn btn-default" 
                                                                            CommandArgument='<%# Eval("fon_codigo") %>' 
                                                                            CommandName="Delete" 
                                                                            OnCommand="btnDelete_Command" 
                                                                            runat="server">
                                                                <span class="fa fa-close fa-fw"></span>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->

                </div>
            </div>
        </div>
    </div>

</asp:Content>

