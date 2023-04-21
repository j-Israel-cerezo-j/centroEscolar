function crudCatalogAjax(typeR, formData) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);
    formData.append('typeSubmit', typeR);
    $.ajax({
        url: "Handlers/crudCatalogHandler.aspx",
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            swal.close()
            if (resultado.success) {
                if (resultado.data.type == "add") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Agregado con exito.',
                        showConfirmButton: false,
                        timer: 1500
                    })
                } else if (resultado.data.type == "delete") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Eliminado con exito.',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
                else if (resultado.data.type == "update") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Registro actualizado.',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    dafaultBtnsDisplay();
                }
                switchTablePahe(resultado.data.table, resultado.data.info)
            }
            else {
                if (resultado.error == undefined) {
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
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


function switchTablePahe(json, info) {
    switch (info) {
        case 'questionsAnswer':
            buildTableQuestionsAnswer(json);
            break;
        case 'questionsCategory':
            buildTableQuestionsCategory(json);
            break;
        case 'encuesta':
            Swal.fire({
                title: 'Muchas gracias',
                text: 'Registro exitoso.',                   
                icon: 'success',
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    closeSession();
                }
            })   
            break; 
        case 'questions':
            buildQuestions(json);
            break;
    }   
}