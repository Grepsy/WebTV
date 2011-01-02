<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.MediaSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Bewerken van: <%: Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumps">
        <li>
            <%: Html.ActionLink("Mijn fotosets", "Index", new { controller = "MediaSet" })%>
        </li>
        <li>
            Fotoset: <%: Model.Name %>
        </li>
    </ul>

    <div class="mediaset-metadata" data-mediasetid="<%: Model.MediaSetId %>">
        <dl>
            <dt>Fotoset</dt>
            <dd><%: Model.Name %></dd>
            <dt>Vertoning</dt>
            <dd>
                <% if (Model.StartDate.HasValue) { %>
                    <%: String.Format("{0:d}", Model.StartDate) %> tot
                    <%: String.Format("{0:d}", Model.EndDate) %>
                <% } else { %>
                    Niet ingesteld.
                <% } %>
            </dd>
            <dt>Bericht</dt>
            <dd>
                <% if (!String.IsNullOrWhiteSpace(Model.Message)) { %>
                    <%: Model.Message%>
                <% } else { %>
                    Niet ingesteld.
                <% } %>
            </dd>
        </dl>
        <a class="action-edit" href="#">Bewerk fotoset</a>
    </div>

    <% if (Model.Animation.MediaGroupedBy == 1) { %>
        <div class="mediaset-upload">
            <p>
                Upload foto's van je eigen computer. Selecteer een foto en wijzig de informatie:
                titel omschrijving en prijs.
            </p>
            
            <%: Html.ActionLink("Upload", "Upload", "Media", new { mediaSetId = Model.MediaSetId }, new { @class = "action-upload" })%>
        </div>
    <% }
       else { %>
        <div class="mediaset-creategroup">
            <p>
                Maak een nieuwe groep aan en open deze om foto's to uploaden.
            
                <% if ((bool)ViewData["HasMissingGroups"]) { %>
                    <span class="error-missinggroups">Vul alle groepen</span>
                <% } %>
            </p>
            <%: Html.ActionLink("Maak groep", "New", "MediaGroup", new { mediaSetId = Model.MediaSetId }, new { @class = "action-creategroup" })%>
        </div>
    <% } %>

    <div class="mediaset-animation">
        <p>
            Kies een commercial waarin de fotoset wordt vertoond en bekijk de preview.
        </p>
        <form action="<%:Url.Action("Preview","MediaSet")%>" method="post">
            <select name="AnimationId">
                <% foreach (var animation in (IEnumerable<WebTV.Model.Animation>)ViewData["Animations"]) { %>
                    <option value="<%: animation.AnimationId %>"><%: animation.Name %></option>
                <% } %>
            </select>
            <input type="hidden"  name="MediaSetId" value="<%: Model.MediaSetId %>" />
            <input type="submit" value="Preview" class="action-preview" />
            <!--<%: Html.ActionLink("Preview", "Preview", new { id = Model.MediaSetId }, new { @class = "action-preview" })%> -->
        </form>
    </div>

    <div class="mediaset-media">
        <% foreach (var item in Model.Media.Where(m => m.MediaGroupId == null)) { %>
            <div class="media" data-mediaid="<%: item.MediaId %>">
                <img src="/Media/Show?id=<%: item.Filename %>" style="width: 200px;"/>
                <h3 class="media-name"><%: item.PropertyWithName("Naam").Value %></h3>
                <span class="media-price"><%: item.PropertyWithName("Prijs").Value %></span>
                <ul class="media-actions">
                    <li class="action-delete"><%: Html.ActionLink("Verwijderen", "Delete", "Media", new { id = item.MediaId }, null) %> | </li>
                    <li class="action-copy"><%: Html.ActionLink("Kopieëren", "Copy", "Media", new { id = item.MediaId }, null)%> | </li>
                    <li class="action-edit"><a href="#">Bewerken</a></li>
                </ul>
            </div>
        <% } %>
        <% foreach (var item in Model.MediaGroups) { %>
            <div class="mediagroup" data-mediagroupid="<%: item.MediaGroupId %>">
                <%--<img src="/Media/Show?id=<%: item.Media.First().Filename %>" style="width: 200px;"/>--%>
                <h3 class="group-name"><%: item.PropertyWithName("Naam").Value %></h3>
                <span class="media-price"><%: item.PropertyWithName("Prijs").Value %></span>
                <ul class="mediagroup-actions">
                    <li class="action-delete"><%: Html.ActionLink("Verwijderen", "Delete", "MediaGroup", new { id = item.MediaGroupId }, null) %> | </li>
                    <li class="action-copy"><%: Html.ActionLink("Kopieëren", "Copy", "MediaGroup", new { id = item.MediaGroupId }, null)%> | </li>
                    <li class="action-edit"><%: Html.ActionLink("Openen", "Edit", "MediaGroup", new { id = item.MediaGroupId }, null) %></li>
                </ul>
            </div>
        <% } %>
    </div>

    <% Html.RenderPartial("EditMediaSetDialog", Model); %>
    <% Html.RenderPartial("EditMetadataDialog"); %>
    <% Html.RenderPartial("CopyMediaDialog", Model.Animation.MediaSets); %>
</asp:Content>
