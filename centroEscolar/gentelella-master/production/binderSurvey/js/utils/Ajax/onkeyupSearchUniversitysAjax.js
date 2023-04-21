function OnkeyupSerchUniversity(formData) {
    var f = $(this);
    $.ajax({
        url: "Handlers/OnkeyupSearchUniversityHandler.aspx",
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            if (resultado.success) {
                mostrarCoincidenciasBusqueda(resultado.data.coincidencias);
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
