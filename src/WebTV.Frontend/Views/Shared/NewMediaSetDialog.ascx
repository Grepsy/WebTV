<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<WebTV.Model.Animation>>" %>

<div class="dialog dialog-newmediaset">
    <h2>Nieuwe fotoset</h2>
    <form action="/MediaSet/New" method="post">
        <fieldset id="fieldset-newmediaset">
            <label for="field-newmediaset-name">Titel van fotoset</label>
            <input id="field-newmediaset-name" name="name" />
            <label for="field-newmediaset-animation">Commercial</label>
            <select id="field-newmediaset-animation" name="animationId">
                <% foreach (var animation in Model) { %>
                    <option value="<%: animation.AnimationId %>"><%: animation.Name %></option>
                <% } %>
            </select>
        </fieldset>
        <a href="" class="action-cancel">Annuleren</a> of
        <input type="submit" value="Maak fotoset" />
    </form>
</div>