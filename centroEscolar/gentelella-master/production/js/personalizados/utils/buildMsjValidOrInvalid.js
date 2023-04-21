function buildMsjValid(idContainer) {
    /*var html = `<span class="valid-feedback">¡ Buen trabajo</span>`;*/
    $("#containerMjsValidOrInValid").html("<div class='valid-feedback'>¡ Buen trabajo</div>")
    /*document.getElementById("containerMjsValidOrInValid").innerHTML = html;*/
}

function buildMsjInValid(msj, idContainer) {
    var html = `<div class="invalid-feedback">` + msj + ` es requerido</div>`;
    document.getElementById(idContainer).innerHTML = html;
}