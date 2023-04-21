﻿function recoverTableByTypeWorkerAjax(idTypeWorker) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })

    
    var f = $(this);
    var formData = new FormData(document.getElementById("form1"));
    //formData.append("urlDes", "requestTableEmployeByTypeWorkerHandler.aspx?typeWorker=" + idTypeWorker);
    $.ajax({
        url: "Handlers/requestTableEmployeByTypeWorkerHandler.aspx?typeWorker=" + idTypeWorker,
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            swal.close()
            if (resultado.success) {
                if (idTypeWorker == "Divisional") {
                    buildTableEmploysDivisionales(resultado.data.recoverTable, resultado.data.jsonStatusEmployes);
                } else if (idTypeWorker == "General") {
                    buildTableEmploysGenerales(resultado.data.recoverTable, resultado.data.jsonStatusEmployes);
                }
            }
            else {
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
        error: function (xhr, error, code) {
            alert("error");       
            Swal.fire({
                icon: 'error',
                confirmButtonColor: '#572364',
                title: 'Oops... ¡ Algo salio mal !',
                text: 'Recargar la pagina por favor.'
            })
        }

    });
}