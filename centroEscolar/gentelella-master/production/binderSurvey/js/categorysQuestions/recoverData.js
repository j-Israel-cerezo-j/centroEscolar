function recoverDataa(event) {
    document.getElementById("form1").reset();
    document.getElementById("labelMsjAction").innerText = "Modificar registro";
    var id = event.target.attributes.id.value;
    $("#ctrl-principal").css('display', 'none');
    $("#ctrl-update").css('display', 'block');
    recoverDataAjax("recoverData", id);

}
function cancelUpdate() {
    $("#ctrl-principal").css('display', 'block');
    $("#ctrl-update").css('display', 'none');

    document.getElementById("save").value = "";
    document.getElementById("labelMsjAction").innerText = "Agregar categoria de preguntas en encuestas";
    document.getElementById("form1").reset();


}

function toggleSelectAll() {
    let isChecked = $("#check-all").prop('checked')
    $("#tbl-roles tbody input[type=checkbox]").prop('checked', !isChecked);
    $("#tbl-roles tbody ins").click();
}

