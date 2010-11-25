<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<ViewDataFileUpload>>" %>
<script type="text/javascript">
    swfobject.embedSWF("myContent.swf", "previewContent", "500", "400");
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Preview
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%: Html.ActionLink("Mijn fotosets", "Index", "MediaSet") %>
    <%=TempData["MediaSetLocation"] %>
    <h2>Preview</h2>
    <div id="previewContent"></div>
</asp:Content>
