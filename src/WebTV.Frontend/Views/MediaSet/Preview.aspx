<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<ViewDataFileUpload>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Preview
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    var flashvars = {"entrypoint":"<%=TempData["MediaSetLocation"]%>"};
    var params = {};
    var attributes = {};
    swfobject.embedSWF("/Content/Flash/<%=TempData["AnimationFile"]%>", "previewContent", "900", "500", "10.0.0", "", flashvars, params, attributes);
</script>
    <%: Html.ActionLink("Mijn fotosets", "Index", "MediaSet") %>
    <h2>Preview</h2>
    <div id="previewContent"></div>
</asp:Content>
