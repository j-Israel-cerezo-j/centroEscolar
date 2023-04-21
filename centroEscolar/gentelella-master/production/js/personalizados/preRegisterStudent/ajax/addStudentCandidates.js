function addStudentCandidate(formData) {    
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);
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
                //Swal.fire({
                //    icon: 'success',
                //    title: 'Registro exitoso, espera el dia de tu examen',
                //    showConfirmButton: false
                //})
                alertWithDatas(resultado.data.info);
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


