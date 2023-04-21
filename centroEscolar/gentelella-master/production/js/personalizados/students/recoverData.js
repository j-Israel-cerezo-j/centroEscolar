//Estudiantes
function recoverDataa(event) {
    document.getElementById("labelMsjAction").innerText = "Modificar alumno";
    var id = event.target.attributes.id.value;   
    recoverData("recoverData", id);
    $("#ctrl-update").css('display', 'block');
    $("#ctrl-principal").css('display', 'none');

    var idsInputs = ["nombres", "apellidoP", "apellidoM", "email", "nombres",
        "apellidoP", "apellidoM", "email", "tel", "nomCalle", "noInterior",
        "noExterior","cp", "colonia", "estadosMexico", "municipios", "save","formFile"];

    styleBoxShadowGreen(idsInputs);

    enabledOrDisabledInputs(idsInputs, false);

}
function cancelUpdate() {
    $("#ctrl-principal").css('display', 'block');
    $("#ctrl-update").css('display', 'none');
    document.getElementById("form1").reset();
    document.getElementById("labelMsjAction").innerText = "";
    document.getElementById("save").value = "";


    document.getElementById("image").setAttribute("src", "");
    document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""

    var idsInputs = ["nombres", "apellidoP", "apellidoM", "email", "nombres", "apellidoP",
        "apellidoM", "email", "tel", "nomCalle", "noInterior", "noExterior",
        "cp", "colonia", "estadosMexico", "municipios", "save","formFile"];
    enabledOrDisabledInputs(idsInputs, true);

    var inputImage = document.getElementById("image");
    inputImage.setAttribute('data-image-uploadAut', "");

    var saveBtn = document.getElementById("save");
    saveBtn.setAttribute('data-id-domicilie', "");

    
}

function toggleSelectAll() {
    let isChecked = $("#check-all").prop('checked')
    $("#tbl-roles tbody input[type=checkbox]").prop('checked', !isChecked);
    $("#tbl-roles tbody ins").click();
}