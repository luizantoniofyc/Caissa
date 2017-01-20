<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Xml" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        string ontologyXML = Server.HtmlEncode(File.ReadAllText(Server.MapPath("~/App_Data/SecAOnto.xml")));
        xmlContent.Text = ontologyXML;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SecAOnto</title>
</head>
<body>
    <form id="formSecAOnto" runat="server">
    <div class="row">
        <div class="col-md-12">
            <pre lang="xml">
                <asp:Literal ID="xmlContent" runat="server"></asp:Literal>
            </pre>
        </div>
    </div>
    </form>
</body>
</html>
