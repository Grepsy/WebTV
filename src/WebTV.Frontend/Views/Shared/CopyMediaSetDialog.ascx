<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="dialog dialog-copymediaset">
    <h2>Fotoset kopiëren</h2>
    <form action="/MediaSet/Copy" method="post">
        <fieldset id="fieldset-copymediaset">
            <input name="id" id="field-copymediaset-id" type="hidden" />
            <input name="animationId" id="field-copymediaset-animationid" type="hidden" />
            <label>Titel van de nieuwe fotoset</label>
            <input name="name" />
        </fieldset>
        <a href="" class="action-cancel">Annuleren</a> of
        <input type="submit" value="Maak kopie" />
    </form>
</div>