<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageProject.master" AutoEventWireup="true" CodeFile="EvaluationItems.aspx.cs" Inherits="Pages_EvaluationItems" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <div class="row">
        <div class="col-lg-12">
            <ol class="breadcrumb top30">
                <li><a href="#">Home</a></li>
                <li class="active">AssessmentItems</li>
            </ol>
            <h3 class="page-header">Assessment Items</h3>
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
                            All Registered Assessment Items
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="dataTable_wrapper">
                                <table class="table table-striped table-bordered table-hover" id="dataTable_Sources">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th title="Assessment Item">Item</th>
                                            <th title="Procedure">PR/PE</th>
                                            <th title="Diversity of Assessment Dimension" class="text-center">DivDM</th>
                                            <th title="Diversity of Security Property" class="text-center">DivPP</th>
                                            <th title="Local Coverage of the Item" class="text-center">CovLoc</th>
                                            <th class="text-center"></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpEvaluationItems" runat="server">
                                            <ItemTemplate>
                                                <tr class="odd gradeA">
                                                    <td><%# Eval("con_sigla") %></td>
                                                    <td><%# Eval("con_titulo") %></td>
                                                    <td><%# Eval("con_procedimento") %></td>
                                                    <td class="text-center"><%# Eval("con_div_dm") %></td>
                                                    <td class="text-center"><%# Eval("con_div_pp") %></td>
                                                    <td class="text-center"><%# Eval("con_cov_loc") %></td>
                                                    <td class="text-center">
                                                        <div class="btn-group">
                                                            <asp:LinkButton ID="btnEdit" 
                                                                            CssClass="btn btn-default"
                                                                            CommandArgument='<%# Eval("con_codigo") %>'
                                                                            CommandName="Edit" 
                                                                            OnCommand="btnEdit_Command"
                                                                            runat="server">
                                                                <span class="fa fa-edit fa-fw"></span>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="btnDelete" 
                                                                            CssClass="btn btn-default" 
                                                                            CommandArgument='<%# Eval("con_codigo") %>' 
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

