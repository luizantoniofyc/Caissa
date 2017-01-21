<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageProject.master" AutoEventWireup="true" CodeFile="IncluirControle.aspx.cs" Inherits="Pages_IncluirControle" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <div class="row">
        <div class="col-lg-12">
            <ol class="breadcrumb top30">
                <li><a href="#">Home</a></li>
                <li><a href="#">Test</a></li>
                <li class="active">SelectAssessmentItem</li>
            </ol>
            <h3 class="page-header">Select Assesstment Item - <asp:Literal ID="lTest" runat="server"></asp:Literal></h3>
            <div class="row">
                <div class="col-lg-12">
                    <div class="btn-group pull-right">
                        <asp:LinkButton ID="btnBackward" CssClass="btn btn-default" OnClick="btnBackward_Click" runat="server">
                            <span class="fa fa-backward fa-fw"></span> Backward
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnIncludeItem" CssClass="btn btn-default" OnClick="btnIncludeItem_Click" runat="server">
                            <span class="fa fa-link fa-fw"></span> Select Item(s)
                        </asp:LinkButton>
                    </div>
                </div>
            </div>

            <div class="row top20">
                <div class="col-lg-12">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            All Registered Assesstment Items
                        </div>
                        <div class="panel-body">
                            <div class="dataTable_wrapper">
                                <table class="table table-striped table-bordered table-hover" id="dataTable_Sources">
                                    <thead>
                                        <tr>
                                            <th title="Knowledge Source">Source</th>
                                            <th>ID</th>
                                            <th title="Assessment Item">Item</th>
                                            <th title="Diversity of Assessment Dimension" class="text-center">DivDM</th>
                                            <th title="Diversity of Security Property" class="text-center">DivPP</th>
                                            <th title="Local Coverage of the Item" class="text-center">CovLoc</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpEvaluationItems" runat="server">
                                            <ItemTemplate>
                                                <tr class="odd gradeA">
                                                    <td><%# Eval("fon_titulo") %></td>
                                                    <td><%# Eval("con_sigla") %></td>
                                                    <td><%# Eval("con_titulo") %></td>
                                                    <td class="text-center"><%# Eval("con_div_dm") %></td>
                                                    <td class="text-center"><%# Eval("con_div_pp") %></td>
                                                    <td class="text-center"><%# Eval("con_cov_loc") %></td>
                                                    <td class="text-center">
                                                        <asp:CheckBox ID="chkBindItem"
                                                            data-value='<%# Eval("con_codigo") %>'
                                                            runat="server" />
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