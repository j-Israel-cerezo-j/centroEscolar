function requestStatusCandidates(json, jsonOnkeyp=true) {    
    var f = $(this);
    var formData = new FormData(document.getElementById("form1"));
    $.ajax({
        url: "Handlers/requestStatusCandidateHandler.aspx",
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            if (resultado.success) {
                buildTableCandidates(json, resultado.data.jsonStatusCandidates, jsonOnkeyp);
            } else {
                if (resultado.error == undefined) {
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        title: 'Oops... ¡ Algo salio mal !',
                        text: resultado.error,
                        footer: resultado.data.footeer
                    })
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        title: 'Oops...',
                        text: resultado.error,
                        footer: resultado.data.footeer
                    })
                }
            }
        },
    });    
}