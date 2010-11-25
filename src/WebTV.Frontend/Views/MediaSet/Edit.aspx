<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.MediaSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%: Html.ActionLink("Mijn fotosets", "Index") %>

    <h2><%: Model.Name %></h2>

    <div class="mediaset-metadata" data-mediasetid="<%: Model.MediaSetId %>">
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
                <% if (!String.IsNullOrWhiteSpace(Model.Message)) { %>
                    <%: Model.Message%>
                <% } else { %>
                    Niet ingesteld.
                <% } %>
            </dd>
        </dl>
        <a class="action-edit" href="#">Aanpassen</a>
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

    <div class="dialog dialog-editmediaset">
        <h2>Fotoset bewerken</h2>
        <% using (Ajax.BeginForm("edit", new AjaxOptions {UpdateTargetId= "bladiebla" })) { %>
        <%: Html.HiddenFor(model => model.MediaSetId) %>
        
        <%: Html.LabelFor(model => model.Name) %>
        <%: Html.EditorFor(model => model.Name) %>

        <%: Html.LabelFor(model => model.StartDate) %>
        <%: Html.EditorFor(model => model.StartDate) %>

        <%: Html.LabelFor(model => model.EndDate) %>
        <%: Html.EditorFor(model => model.EndDate) %>

        <%: Html.LabelFor(model => model.Message) %>
        <%: Html.EditorFor(model => model.Message) %>

        <a href="#">Annuleren</a> of
        <input type="submit" value="Opslaan" />
        <% } %>
    </div>

    <script id="editMediaTemplate" type="text/html">
        <input name="id" type="hidden" value="{{= MediaId }}" />
        <label>Naam:</label>
        <input name="name" value="{{= Name }}" />
        <label>Omschrijving:</label>
        <input name="description" value="{{= Description }}" />
        <label>Prijs:</label>
        <input name="price" value="{{= Price }}" />
    </script>

    <div class="dialog dialog-editmedia">
        <h2>Foto bewerken</h2>
        <% using (Html.BeginForm("Edit", "Media")) { %>
            <fieldset id="fieldset-media">
            </fieldset>
            <a href="#">Annuleren</a> of
            <input type="submit" value="Opslaan" />
        <% } %>
    </div>
</asp:Content>
