function addStudentCandidate(evt) {
    evt.preventDefault()
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);
    var formData = new FormData(document.getElementById("form1"));
    console.log(formData);
    $.ajax({
        url: "Handlers/preRegisterHandler.aspx",
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {            
            swal.close()
            if (resultado.success) {                
                alertWithDatas(resultado.data.info);
            }
            else {                
                Swal.fire({
                    icon: 'error',
                    confirmButtonColor: '#572364',
                    title: 'Oops...',
                    text: resultado.error
                })

            }
        },
        error: function (xhr, error, code) {
            console.log("error")
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


