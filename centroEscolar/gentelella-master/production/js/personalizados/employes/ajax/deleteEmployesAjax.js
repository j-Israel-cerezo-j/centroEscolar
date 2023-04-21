function deleteEmployesAjax(idTypeWorker, idsToDelete) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);
    var formData = new FormData(document.getElementById("form1"));
    $.ajax({
        url: "Handlers/deleteEmployeHandler.aspx?typeWorker=" + idTypeWorker + "&idsToDelete=" + idsToDelete,
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            swal.close()
            if (resultado.success) {
                Swal.fire({
                    icon: 'success',
                    title: 'Eliminado con exito.',
                    showConfirmButton: false,
                    timer: 1500
                })
                recoverTableByTypeWorkerAjax(idTypeWorker)
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