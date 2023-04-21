function buildMunicipiosInSelect(json) {
    var select = document.getElementById("municipios")
    document.getElementById("municipios").innerHTML = "";

    var optionSeleccioneUna = document.createElement("option")
    optionSeleccioneUna.value = ""
    optionSeleccioneUna.text = "Seleccione una opción";
    select.appendChild(optionSeleccioneUna);
    if (json.municipios.length > 0) {
        for (var i = 0; i < json.municipios.length; i++) {
            if (select != undefined) {
                var option = document.createElement("option")
                option.value = json.municipios[i];
                option.text = json.municipios[i];
                select.appendChild(option);
            }
        }
    }
}