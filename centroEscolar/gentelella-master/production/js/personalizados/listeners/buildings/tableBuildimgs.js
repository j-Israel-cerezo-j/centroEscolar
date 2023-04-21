function recoverTableBuildings() {  
    var formData = new FormData(document.getElementById("form1"));
    var f = $(this);        
    $.ajax({
        url: "Handlers/handlersTables/tableBuildingsHandler.aspx",
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            if (resultado.success) {
                buildTableBuildings(resultado.data.recoverTable);
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