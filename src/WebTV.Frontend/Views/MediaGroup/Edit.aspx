<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.MediaGroup>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="breadcrumps">
        <li>
            <%: Html.ActionLink("Mijn fotosets", "Index", new { controller = "MediaSet" })%>
        </li>
        <li>
            Fotoset: <%: Html.ActionLink(Model.MediaSet.Name, "Index", new { controller = "MediaSet", id = Model.MediaSetId })%>
        </li>
        <li>
            Groep: <%: Model.PropertyWithName("Naam").Value %>
        </li>
    </ul>

    <div class="mediagroup-metadata" data-mediagroupid="<%: Model.MediaGroupId %>">
        <p>Bewerk de groep en wijzig titel, omschrijving en prijs.</p>
        <a class="action-edit" href="#">Bewerk groep</a>
    </div>

    <div class="mediagroup-upload">
        <p>
            Upload foto's van je eigen computer. Bewerk een foto om de informatie te wijzigen.
        </p>
        <%: Html.ActionLink("Upload", "Upload", "Media", 
            new { mediaSetId = Model.MediaSetId, mediaGroupId = Model.MediaGroupId }, null) %>
    </div>

    <div class="mediagroup-media">
        <% foreach (var item in Model.Media) { %>
            <div class="media" data-mediaid="<%: item.MediaId %>">
                <img src="/Media/Show?id=<%: item.Filename %>" style="width: 200px;"/>
                <h3 class="media-name"><%: item.PropertyWithName("Naam").Value %></h3>
                <span class="media-price"><%: item.PropertyWithName("Prijs").Value %></span>
                <ul class="media-actions">
                    <li class="action-delete"><%: Html.ActionLink("Verwijderen", "Delete", "Media", new { id = item.MediaId }, null) %></li>
                    <li class="action-copy"><%: Html.ActionLink("Kopieëren", "Copy", "Media", new { id = item.MediaId }, null)%></li>
                    <li class="action-edit"><a href="#">Bewerken</a></li>
                </ul>
            </div>
        <% } %>
    </div>

    <% Html.RenderPartial("EditMediaDialog"); %>
        
</asp:Content>
