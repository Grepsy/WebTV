<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebTV.Model.MediaSet>" %>

<div class="dialog dialog-editmediaset">
    <h2>Fotoset bewerken</h2>
    <% using (Html.BeginForm()) { %>
    <fieldset>
        <%: Html.HiddenFor(model => model.MediaSetId) %>
        
        <%: Html.LabelFor(model => model.Name) %>
        <%: Html.EditorFor(model => model.Name) %>

        <%: Html.LabelFor(model => model.StartDate) %>
        <%: Html.EditorFor(model => model.StartDate) %>

        <%: Html.LabelFor(model => model.EndDate) %>
        <%: Html.EditorFor(model => model.EndDate) %>

        <%: Html.LabelFor(model => model.Message) %>
        <%: Html.EditorFor(model => model.Message) %>
    </fieldset>
    <a href="" class="action-cancel">Annuleren</a> of
    <input type="submit" value="Opslaan" />
    <% } %>
</div>