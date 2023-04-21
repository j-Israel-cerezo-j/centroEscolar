function updateStatusAndAddCandidate(idStatus, idCandidate) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var formData = new FormData(document.getElementById("form1"));
    var f = $(this);
    $.ajax({
        url: "Handlers/manageStatusCandidatesAlumHandler.aspx?idStatus=" + idStatus + "&idCandidate=" + idCandidate,
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
                    title: 'El estatus del candidato se ha cambiado.',
                    showConfirmButton: false,
                    timer: 2000
                })
                buildTableCandidates(resultado.data.jsonCandidates, resultado.data.jsonStatusCandidates);
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