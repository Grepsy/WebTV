<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<ViewDataFileUpload>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Upload
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% if (ViewData.ContainsKey("mediaGroupId")) { %>
        <%: Html.ActionLink("Terug naar groep", "Edit", new { controller = "MediaGroup", id = ViewData["mediaGroupId"] })%>
    <% } else { %>
        <%: Html.ActionLink("Terug naar fotoset", "Index", new { controller = "MediaSet", id = ViewData["mediaSetId"] })%>
    <% } %>
     
    <h2>Upload</h2>
    <ul>
        <% foreach (var fileinfo in this.Model) { %>
            <li>
                <%: String.Format("Bestand: {0} ({1} bytes)", fileinfo.Filename, fileinfo.Filesize) %>
                <%: fileinfo.CheckResult.IsToSmall ? "Bestand te klein " : "" %>
                <%: fileinfo.CheckResult.IsToLarge ? "Bestand te groot " : "" %>
                <%: fileinfo.CheckResult.InvalidRatio ? "Onjuiste ratio " : "" %>
                <%: fileinfo.CheckResult.UnsupportedFormat ? "Onbekend formaat " : "" %>
            </li>
        <% } %>
    </ul>

    <form method="post" action="/Media/Upload" enctype="multipart/form-data">
        <input type="file" name="test" multiple="" />
        <%: Html.Hidden("mediaSetId", ViewData["mediaSetId"]) %>
        <%: Html.Hidden("mediaGroupId", ViewData["mediaGroupId"]) %>
        <input type="submit" value="Versturen" />
    </form>
</asp:Content>
