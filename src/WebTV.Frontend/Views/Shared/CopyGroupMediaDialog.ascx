<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<WebTV.Model.MediaGroup>>" %>

<div class="dialog dialog-copygroupmedia">
    <h2>Foto kopiëren</h2>
    <form action="/Media/Copy" method="post">
        <fieldset id="fieldset-copygroupmedia">
            <label>Naar groep:</label>
            <select name="mediaGroupId">
            <% foreach (var set in Model) { %>
                <option value="<%: set.MediaGroupId %>"><%: set.PropertyWithName("Naam").Value %></option>
            <% } %>
            </select>
            <p>
                Hier kunt u de kopie van nieuwe gegevens voorzien.
            </p>
            <input name="id" id="field-copymedia-id" type="hidden" />
            <label>Naam:</label>
            <input name="name" />
            <label>Omschrijving:</label>
            <input name="description"  />
            <label>Prijs:</label>
            <input name="price" />
        </fieldset>
        <a href="" class="action-cancel">Annuleren</a> of
        <input type="submit" value="Maak kopie" />
    </form>
</div>