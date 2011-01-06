<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebTV.Model.MediaSet>" %>

<div class="dialog dialog-editmediaset">
    <h2>Fotoset bewerken</h2>
    <% using (Html.BeginForm()) { %>
    <fieldset>
        <%: Html.HiddenFor(model => model.MediaSetId) %>
        
        <label for="Name">Naam:</label>
        <%: Html.EditorFor(model => model.Name) %>

        <label for="StartDate">Start datum:
        <%: Html.EditorFor(model => model.StartDate) %>

        <label for="EndDate">Eind datum:
        <%: Html.EditorFor(model => model.EndDate) %>

        <label for="Message">Bericht:
        <%: Html.EditorFor(model => model.Message) %>
    </fieldset>
    <a href="" class="action-cancel">Annuleren</a> of
    <input type="submit" value="Opslaan" />
    <% } %>
</div>