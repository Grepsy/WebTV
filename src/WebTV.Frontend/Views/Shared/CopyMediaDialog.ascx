<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<WebTV.Model.MediaSet>>" %>

<div class="dialog dialog-copymedia">
    <h2>Foto kopiëren</h2>
    <form action="/Media/Copy" method="post">
        <fieldset id="fieldset-copymedia">
            <label>Selecteer een fotoset voor de kopie</label>
            <select name="mediaSetId">
            <% foreach (var set in Model) { %>
                <option value="<%: set.MediaSetId %>"><%: set.Name %></option>
            <% } %>
            </select>
            <p>
                Geef de afbeelding een nieuwe titel.
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