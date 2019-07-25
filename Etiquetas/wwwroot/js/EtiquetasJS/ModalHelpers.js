
function alertModal(title, body) {
  // Display error message to the user in a modal
  $('#alert-modal-title').html(title);
  $('#alert-modal-body').html(body);
  $('#alert-modal').modal('show');
}


function showRequest(title, quest) {
  // Display error message to the user in a modal
  $('#request-Modal-title').html(title);
  $('#request-Modal-quest').html(quest);
  $('#request-Modal').modal({backdrop: 'static', keyboard: false}) 
}

function showRequestFormulacion(title, quest) {
  // Display error message to the user in a modal
  $('#request-Formulacion-title').html(title);
  $('#request-Formulacion-quest').html(quest);
  $('#request-Formulacion').modal({backdrop: 'static', keyboard: false}) 
}
