﻿//edificios
function recoverDataa(event) {

    document.getElementById("labelMsjAction").innerText = "Modificar registro";
    var id = event.target.attributes.id.value;
    $("#ctrl-principal").css('display', 'none');
    $("#ctrl-update").css('display', 'block');
    recoverData("recoverData", id);
    document.getElementById("edificio").style.boxShadow = "0 0 0 0.25rem rgb(25 135 84 / 25%)"
    document.getElementById("carreras").style.boxShadow = "0 0 0 0.25rem rgb(25 135 84 / 25%)" 

}
function cancelUpdate() {
    $("#ctrl-principal").css('display', 'block');
    $("#ctrl-update").css('display', 'none');
    document.getElementById("save").value = "";
    document.getElementById("labelMsjAction").innerText = "Agregar edificio";
    document.getElementById("form1").reset();
    onkeyupInputEmtyy('edificio')
    onkeyupNoSelectInSlc('carreras');
}

function toggleSelectAll() {
    let isChecked = $("#check-all").prop('checked')
    $("#tbl-roles tbody input[type=checkbox]").prop('checked', !isChecked);
    $("#tbl-roles tbody ins").click();
}