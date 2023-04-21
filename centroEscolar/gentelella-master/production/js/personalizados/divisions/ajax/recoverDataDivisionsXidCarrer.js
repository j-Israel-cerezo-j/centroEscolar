function recoverDataDivisions(id) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);    
    $.ajax({
        url: "Handlers/handlerRequestDivisionsXCarrer.aspx?id=" + id,
        type: "post",
        dataType: "json",        
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            swal.close()
            if (resultado.success) {
                buildTableDivisions(resultado.data.recoverDates);
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
                    for (var i of resultado.error) {
                        Swal.fire({
                            icon: 'error',
                            confirmButtonColor: '#572364',
                            title: 'Oops...',
                            text: resultado.error,
                            footer: resultado.data.footeer
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