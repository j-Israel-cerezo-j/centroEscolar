function deleteSessionRecentCard(formData) {    
    var f = $(this);
    $.ajax({
        url: "Handlers/deleteCardSessionRecentUserHandler.aspx",
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            if (resultado.success) {
                console.log("entre")
                window.location.href = "Login.aspx";
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