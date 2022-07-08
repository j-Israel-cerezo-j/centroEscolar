function buildcpInSelect(json) {
    var select = document.getElementById("cp")
    document.getElementById("cp").innerHTML = "";

    var optionSeleccioneUna = document.createElement("option")
    optionSeleccioneUna.value = "-1"
    optionSeleccioneUna.text = "Seleccione una opción";
    select.appendChild(optionSeleccioneUna);
    if (json.response.cp.length > 0) {
        for (var i = 0; i < json.response.cp.length; i++) {
            if (select != undefined) {
                var option = document.createElement("option")
                option.value = json.response.cp[i];
                option.text = json.response.cp[i];
                select.appendChild(option);
            }
        }
    }
}