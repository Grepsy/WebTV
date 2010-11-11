<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebTV.Model.MediaSet>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Mijn fotosets</h2>

    <p>
        Open een fotoset om deze te bewerken of
        <%: Html.ActionLink("maak een nieuwe aan", "New") %>.
    </p>

    <div class="mediaset-list">
    <% foreach (var item in Model) { %>
        <div class="mediaset">
            <h2><%: item.Name %></h2>
            <% if (item.StartDate.HasValue) { %>
                Vertoning van 
                <%: String.Format("{0:g}", item.StartDate) %> tot
                <%: String.Format("{0:g}", item.EndDate) %>
            <% } else { %>
                Deze fotoset heeft geen datum.
            <% } %>
            <ul class="mediaset-actions">
                <li class="action-delete"><%: Html.ActionLink("Verwijderen", "Delete", new { setId = item.MediaSetId }) %></li>
                <li class="action-copy"><%: Html.ActionLink("Kopieëren", "Copy", new { setId = item.MediaSetId, animationId = item.AnimationId }) %></li>
                <li class="action-edit"><%: Html.ActionLink("Aanpassen", "Edit", new { setId = item.MediaSetId }) %></li>
                <li class="action-preview"><%: Html.ActionLink("Preview", "Preview", new { setId = item.MediaSetId }) %></li>
            </ul>
        </div>
    <% } %>
    </div>
</asp:Content>

