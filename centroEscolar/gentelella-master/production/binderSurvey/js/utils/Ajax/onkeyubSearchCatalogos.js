function OnkeyupSerchCatalogos(catalogo, formData) {
    var f = $(this);
    $.ajax({
        url: "Handlers/onkeyupSearchCatalogosHandler.aspx?catalogo=" + catalogo,
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            if (resultado.success) {
                if (resultado.data.accion == "sinCoincidencias") {
                    SwitchTableOnkeyup(resultado.data.catalogo, resultado.data.table, false);
                } else {
                    mostrarCoincidenciasBusqueda(resultado.data.coincidencias);
                    SwitchTableOnkeyup(resultado.data.catalogo, resultado.data.table, true);
                }
            } else {
                Swal.fire({
                    icon: 'error',
                    confirmButtonColor: '#572364',
                    title: 'Oops...',
                    text: resultado.error,
                    footer: resultado.data.footeer
                })
            }
        },
    });
}

function mostrarCoincidenciasBusqueda(coincidencias) {
    select = document.getElementById('datalistOptionsSerch');
    selectInnerHtml = document.getElementById('datalistOptionsSerch').innerHTML = "";
    for (var i = 0; i < coincidencias.length; i++) {
        var opt = document.createElement('option');
        opt.value = coincidencias[i];
        opt.innerHTML = coincidencias[i];
        select.appendChild(opt);
    }
}