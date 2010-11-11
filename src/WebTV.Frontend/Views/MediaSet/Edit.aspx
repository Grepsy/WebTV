<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.MediaSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%: Html.ActionLink("Mijn fotosets", "Index") %>

    <h2><%: Model.Name %></h2>

    <div class="mediaset-metadata">
        <dl>
            <dt>Fotoset</dt>
            <dd><%: Model.Name %></dd>
            <dt>Vertoning</dt>
            <dd>
                <% if (Model.StartDate.HasValue) { %>
                    <%: String.Format("{0:g}", Model.StartDate) %> tot
                    <%: String.Format("{0:g}", Model.EndDate) %>
                <% } else { %>
                    Niet ingesteld.
                <% } %>
            </dd>
            <dt>Bericht</dt>
            <dd>
                <% if (!String.IsNullOrWhiteSpace(Model.Animation.Message)) { %>
                    <%: Model.Animation.Message%>
                <% } else { %>
                    Niet ingesteld.
                <% } %>
            </dd>
        </dl>
    </div>

    <div class="mediaset-upload">
        <p>
            Upload foto's van je eigen computer. Selecteer een foto en wijzig de informatie: titel omschrijving en prijs.
        </p>
        <%: Html.ActionLink("Upload", "Upload", "Media" , new { mediaSetId = Model.MediaSetId }, null) %>
    </div>

    <div class="mediaset-animation">
        <p>
            Kies een commercial waarin de fotoset wordt vertoond en bekijk de preview.
        </p>
        <select name="animationId">
            <% var animation = Model.Animation; %>
            <option value="<%: animation.AnimationId %>"><%: animation.Name %></option>
        </select>
        <a href="#">Preview</a>
    </div>

    <div class="mediaset-media">
        <% foreach (var item in Model.Media) { %>
            <div class="mediaset">
                <img src="/Media/Show?id=<%: item.Filename %>" />
                <h3 class="media-name"><%: item.PropertyWithName("Omschrijving").Value %></h3>
                <span class="media-price"><%: item.PropertyWithName("Prijs").Value %></span>
                <ul class="mediaset-actions">
                    <li class="action-delete"><%: Html.ActionLink("Verwijderen", "Delete", new { id = item.MediaId }) %></li>
                    <li class="action-copy"><%: Html.ActionLink("Kopieëren", "Copy", new { id = item.MediaId })%></li>
                    <li class="action-show"><%: Html.ActionLink("Tonen", "Preview", new { id = item.MediaSetId }) %></li>
                </ul>
            </div>
        <% } %>
    </div>
</asp:Content>
