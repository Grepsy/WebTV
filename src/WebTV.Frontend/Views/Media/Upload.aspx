<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<string>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Upload
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Upload</h2>
    <ul>
        <% foreach (string file in this.Model) { %>
            <li><%: file %></li>
        <% } %>
    </ul>

    <form method="post" action="/Media/Upload" enctype="multipart/form-data">
        <input type="file" name="test" />
        <input type="submit" value="Versturen" />
    </form>
</asp:Content>
