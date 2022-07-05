﻿function recoverData(type,id) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);
    var formData = new FormData(document.getElementById("form1"));
    formData.append('typeSubmit', type);

    $.ajax({
        url: "Handlers/submitHandlerCatalogos.aspx?id="+id,
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            swal.close()
            if (resultado.success) {
                switchCatalogosRecoverData(resultado.data.recoverDates, resultado.data.info);
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