function recoverRolesByTypeWorkerr(event, idInput ="") {
    var id = "";
    if (event != undefined) {
        idInput = event.target.attributes.id.value;  
    }
    id = document.getElementById(idInput).value;

    if (idInput == "radioDivisional") {
        $("#containerCarreras").css('display', 'block');
        $("#containerDivisiones").css('display', 'block');
    }
    else if (idInput == "radioGeneral") {
        $("#containerCarreras").css('display', 'none');
        $("#containerDivisiones").css('display', 'none');
    }
    var formData = new FormData();
    rolesByTypeWorkerr(id, "employes", formData);
}

