function recoverDataa(event) {

    document.getElementById("labelMsjAction").innerText = "Modificar al trabajador";
    var idEmploye = event.target.attributes.id.value;
    var idTypeWorker = event.target.dataset.idTypeworker;
    $("#ctrl-principal").css('display', 'none');
    $("#ctrl-update").css('display', 'block');
    recoverDataEmplo(idEmploye, idTypeWorker);

    var idsInputs = ["nombres", "apellidoP", "apellidoM","curp", "email", "nombres", "apellidoP",
        "apellidoM", "email", "tel", "nomCalle", "noInterior", "noExterior",
        "cp", "colonia", "estadosMexico", "municipios","formFile"];
    styleBoxShadowGreen(idsInputs);
}
function cancelUpdate() {
    $("#ctrl-principal").css('display', 'block');
    $("#ctrl-update").css('display', 'none');
    $("#containerCarreras").css('display', 'none');

    document.getElementById("save").value = "";
    document.getElementById("labelMsjAction").innerText = "Agrega a un trabajador";
    document.getElementById("image").setAttribute("src", "");
    $("#containerRolesTypeWorker input[type=checkbox]").iCheck('uncheck');
    document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
    document.getElementById("containerRolesTypeWorker").innerHTML = ""    
    document.getElementById("form1").reset();
    document.getElementById('fechaNac').value = currentDate(document.getElementById("fechaNac").value);    
    onkeyupInputEmtyy('nombres')
    onkeyupInputEmtyy('apellidoP')
    onkeyupInputEmtyy('apellidoM')
    onkeyupInputEmtyy('curp')
    onkeyupInputEmtyy('email')
    onkeyupInputEmtyy('tel')
    onkeyupInputEmtyy('nomCalle')
    onkeyupInputEmtyy('noInterior')
    onkeyupInputEmtyy('noExterior')
    onkeyupInputEmtyy('cp')
    onkeyupInputEmtyy('colonia')
    onkeyupNoSelectInSlc('estadosMexico');
    onkeyupNoSelectInSlc('municipios');
    onkeyupInputEmtyy('formFile')
}

function toggleSelectAll() {
    let isChecked = $("#check-all").prop('checked')
    $("#tbl-roles tbody input[type=checkbox]").prop('checked', !isChecked);
    $("#tbl-roles tbody ins").click();
}
