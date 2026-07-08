
function ShowMessage(message, messagetype) {
    var cssclass;
    switch (messagetype) {
        case 'Success':
            cssclass = 'alert-success'
            break;
        case 'Error':
            cssclass = 'alert-danger'
            break;
        case 'Warning':
            cssclass = 'alert-warning'
            break;
        default:
            cssclass = 'alert-info'
    }
    $('#alert_container').append('<div id="alert_div" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
}



