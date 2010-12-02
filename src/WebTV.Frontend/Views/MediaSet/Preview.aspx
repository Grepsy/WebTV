<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<ViewDataFileUpload>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Preview
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    var flashvars = {"location":"<%=TempData["MediaSetLocation"];%>"};
    var params = {};
    var attributes = {};
    //swfobject.embedSWF("/Content/Flash/multimate_v2_27102010-FL10-CS3_B.swf", "previewContent", "500", "400", "10.0.0", "", flashvars, params, attributes);
</script>
    <%: Html.ActionLink("Mijn fotosets", "Index", "MediaSet") %>
    <h2>Preview</h2>
    <div id="previewContent"></div>
</asp:Content>
