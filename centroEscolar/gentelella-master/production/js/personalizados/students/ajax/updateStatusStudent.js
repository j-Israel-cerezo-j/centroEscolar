function updateStatusAjax(idStatus, idStudent, user, typeWorker = "") {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var formData = new FormData(document.getElementById("form1"));
    var f = $(this);
    $.ajax({
        url: "Handlers/requestUpdateStatusUserHandler.aspx?idStatus=" + idStatus + "&idUser=" + idStudent + "&User=" + user + "&typeWorker=" + typeWorker,
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
                    title: 'El estatus del alumno se ha cambiado.',
                    showConfirmButton: false,
                    timer: 2000
                })
                buildTableStudents(resultado.data.jsonUsers, resultado.data.jsonStatusUsers);
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
            console.log(error);
            console.log(code);
            Swal.fire({
                icon: 'error',
                confirmButtonColor: '#572364',
                title: 'Oops... ¡ Algo salio mal !',
                text: 'Recargar la pagina por favor.'
            })
        }

    });
}