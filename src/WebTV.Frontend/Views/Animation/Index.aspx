<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebTV.Model.Animation>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Animaties</h2>

    <ul>
    <% foreach (var animation in this.Model) { %>
        <li>
            <%: Html.ActionLink(animation.Name, "Edit", new { id = animation.AnimationId }) %>
            (<%: animation.MediaSets.Count() %> actieve sets)
        </li>
    <% } %>
    </ul>
</asp:Content>