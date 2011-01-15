<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.MediaSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Preview
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    var flashvars = {"entrypoint":"<%=TempData["MediaSetLocation"]%>"};
    var params = {};
    var attributes = {};
    swfobject.embedSWF("/Content/Flash/<%=TempData["AnimationFile"]%>", "previewContent", "675", "380", "10.0.0", "", flashvars, params, attributes);
</script>
    <ul class="breadcrumps">
        <li>
            <%: Html.ActionLink("Mijn fotosets", "Index", new { controller = "MediaSet" })%>
        </li>
        <% if (Model.MediaSetId > 0)
           { %>
        <li>
            Fotoset: <%: Html.ActionLink(Model.Name, "Edit", new { controller = "MediaSet", id = Model.MediaSetId })%>
        </li>
        <%} %>
        <li>
            Preview
        </li>
    </ul>
    <div class="actiontext">
        Een preview van de door u samengestelde commercial.
    </div>
    <div class="mediaset-preview">
        <div class="preview-container">
            <div id="previewContent"></div>
        </div> 
    </div>
</asp:Content>
