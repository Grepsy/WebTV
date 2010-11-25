$(document).ready(function() {
  $('.media-actions .action-edit a').click(function () {
    var dialog = $('.dialog-editmedia').dialog({modal: true});
    var mediaId = $(this).closest("[data-mediaid]").attr('data-mediaid');

    $.getJSON('/Media/Index/' + mediaId, null, function(data) {
      $('#fieldset-media').empty().append($('#editMediaTemplate').tmpl(data));
    });

    return false;
  });
});