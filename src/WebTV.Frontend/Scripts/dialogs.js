$(document).ready(function() {
  $('.datetime').datepicker({dateFormat: 'dd-mm-yy'});

  $('.media-actions .action-edit a').click(function() { editMetadata(this, '/Media/Edit', 'mediaid'); return false; });
  $('.mediagroup-metadata .action-edit').click(function() { editMetadata(this, '/MediaGroup/Edit', 'mediagroupid'); return false; });

  var editMetadata = function (button, url, id) {
    var dialog = $('.dialog-editmetadata');
    dialog.dialog({
      title: $('h2', dialog).hide().text(),
      modal: true
    });
    $('.action-cancel', dialog).click(function() {
      dialog.dialog("close");
      return false;
    });
    $('#fieldset-metadata').parent('form').attr('action', url);
    var mediaId = $(button).closest("[data-" + id + "]").attr('data-' + id);

    $.getJSON(url + '/' + mediaId + '?type=json', null, function(data) {
      $('#fieldset-metadata').empty().append($('#editMetadataTemplate').tmpl(data));
    });
  };

  $('.mediaset-metadata .action-edit').click(function () {
    var dialog = $('.dialog-editmediaset').dialog({modal: true});

    return false;
  });
});