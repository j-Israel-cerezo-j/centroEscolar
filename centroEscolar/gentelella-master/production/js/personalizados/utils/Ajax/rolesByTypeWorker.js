function rolesByTypeWorkerr(typeWorkerID, catalogo, formData) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);
    $.ajax({
        url: "Handlers/rolesByTypeWorkerHandler.aspx?typeWorjerID=" + typeWorkerID + "&catalogo=" + catalogo,
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            swal.close()
            if (resultado.success) {
                switchTablePage(resultado.data.rolesByTypeWorker, resultado.data.catalogo);
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
                    buildRolesByTypeWotker(resultado.data.rolesByTypeWorker, resultado.data.catalogo)
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
function switchTablePage(json, info) {
    switch (info) {      
        case 'employes':
            buildRolesByTypeWotker(json);
            break;
    }
}