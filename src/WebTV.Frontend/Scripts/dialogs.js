$(document).ready(function() {
  $('.datetime').datepicker({dateFormat: 'dd-mm-yy'});

  $('.media-actions .action-edit a').click(function() { editMetadata(this, '/Media/Edit', 'mediaid'); return false; });
  $('.mediagroup-metadata .action-edit').click(function() { editMetadata(this, '/MediaGroup/Edit', 'mediagroupid'); return false; });

  var editMetadata = function (button, url, id) {
    $('.dialog-editmetadata').webtvdialog();
    $('#fieldset-metadata').parent('form').attr('action', url);
    var mediaId = $(button).closest("[data-" + id + "]").attr('data-' + id);

    $.getJSON(url + '/' + mediaId + '?type=json', null, function(data) {
      $('#fieldset-metadata').empty().append($('#editMetadataTemplate').tmpl(data));
    });
  };

  $('.mediaset-metadata .action-edit').click(function () {
    $('.dialog-editmediaset').webtvdialog();
    return false;
  });

  $('#mediaset-new').click(function() {
    $('.dialog-newmediaset').webtvdialog();
    return false;
  });

  $('.media-actions .action-copy a').click(function() {
    var mediaId = $(this).closest("[data-mediaid]").attr('data-mediaid');
    $('#field-copymedia-id').val(mediaId);
    $('.dialog-copymedia').webtvdialog();
    return false;
  });

  $('.mediaset-actions .action-copy a').click(function() {
    var setId = $(this).closest("[data-mediasetid]").attr('data-mediasetid');
    var animationId = $(this).closest("[data-animationid]").attr('data-animationid');
    $('#field-copymediaset-id').val(setId);
    $('#field-copymediaset-animationid').val(animationId);
    $('.dialog-copymediaset').webtvdialog();
    return false;
  });
});

jQuery.fn.webtvdialog = function() {
  var element = this.dialog({
    title: $('h2', this).hide().text(),
    modal: true
  });
  $('.action-cancel', this).click(function() {
    element.dialog("close");
    return false;
  });
  return this;
}