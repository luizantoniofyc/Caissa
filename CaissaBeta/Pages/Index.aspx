<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPageProject.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Pages_Index" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <div class="row">
        <div class="col-lg-12">
            <ol class="breadcrumb top30">
                <li class="active">Home</li>
            </ol>
            <h1 class="page-header">Home</h1>
            <div class="project_form">
                <h3>Welcome guest,</h3>
                <p>Browse the menu next to make additions, changes or deletions of the information correlated to the system under test. Here below are some brief descriptions of the menu contents:</p>
                <ul>
                    <li>Search: not implemented</li>
                    <li>Add Test: allows you to insert a new test to the system</li>
                    <li>SUT: allows you to manage the system under test informations</li>
                    <li>Knowledge Sources: 
                        <ul>
                            <li>Sources: allows you to manage the sources</li>
                            <li>Assessment Items: allows you to manage the assessment items</li>
                        </ul>
                    </li>
                    <li>Test Management: lists all the tests and allows you to manage the information of each one</li>
                    <li>Supporting Institutions: lists all the institutions that helped in the project conception</li>
                </ul>
            </div>
        </div>
    </div>

</asp:Content>

