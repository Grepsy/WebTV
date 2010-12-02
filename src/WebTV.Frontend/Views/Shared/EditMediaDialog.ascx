<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script id="editMetadataTemplate" type="text/html">
    <input name="id" type="hidden" value="{{= Id }}" />
    <label>Naam:</label>
    <input name="name" value="{{= Name }}" />
    <label>Omschrijving:</label>
    <input name="description" value="{{= Description }}" />
    <label>Prijs:</label>
    <input name="price" value="{{= Price }}" />
</script>

<div class="dialog dialog-editmetadata">
    <h2>Foto bewerken</h2>
    <form action="" method="post">
        <fieldset id="fieldset-metadata">
        </fieldset>
        <a href="" class="action-cancel">Annuleren</a> of
        <input type="submit" value="Opslaan" />
    </form>
</div>