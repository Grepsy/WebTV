<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebTV.Model.MediaSet>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumps">
        <li>
            <%: Html.ActionLink("Mijn fotosets", "Index", new { controller = "MediaSet" })%>
        </li>
    </ul>
    <div class="actiontext">
        Open een fotoset om deze te bewerken of 
        <%: Html.ActionLink("maak een nieuwe aan", "New", null, new { id = "mediaset-new" }) %>.
    </div>

    <div class="mediaset-list">
    <% foreach (var item in Model) { %>
        <div class="mediaset" data-mediasetid="<%: item.MediaSetId %>" data-animationid="<%: item.AnimationId %>">
            <h2><%: item.Name %></h2>
            <% if (item.StartDate.HasValue) { %>
                Vertoning van 
                <%: String.Format("{0:D}", item.StartDate) %> tot
                <%: String.Format("{0:D}", item.EndDate) %>
            <% } else { %>
                Deze fotoset heeft geen datum.
            <% } %>
            <ul class="mediaset-actions">
                <li class="action-delete"><%: Html.ActionLink("verwijderen", "Delete", new { id = item.MediaSetId }) %></li>
                <li class="action-copy"><%: Html.ActionLink("kopieëren", "Copy", new { id = item.MediaSetId, animationId = item.AnimationId }) %></li>
                <li class="action-edit"><%: Html.ActionLink("aanpassen", "Edit", new { id = item.MediaSetId }) %></li>
                <li class="action-preview"><%: Html.ActionLink("preview", "Preview", new { id = item.MediaSetId }) %></li>
            </ul>
        </div>
    <% } %>
    </div>

    <% Html.RenderPartial("NewMediaSetDialog", ViewData["Animations"]); %>
    <% Html.RenderPartial("CopyMediaSetDialog"); %>
</asp:Content>

