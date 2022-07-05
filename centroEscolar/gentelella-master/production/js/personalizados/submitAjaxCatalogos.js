function typeRequest(typeR) {
    catalogosAddUpdateDelete(typeR);
}

function catalogosAddUpdateDelete(typeR) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);
    var formData = new FormData(document.getElementById("form1"));
    formData.append(typeR, '');

    $.ajax({
        url: "submitHandlerCatalogos.aspx",
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
                    title: 'Agregado con exito.',
                    showConfirmButton: false,
                    timer: 1500
                })
            }
            else {
                if (resultado.error == undefined) {
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        title: 'Oops... ¡ Algo salio mal !',
                        text: i
                    })
                }
                else {
                    for (var i of resultado.error) {
                        Swal.fire({
                            icon: 'error',
                            confirmButtonColor: '#572364',
                            title: 'Oops...',
                            text: i
                        })
                    }
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
