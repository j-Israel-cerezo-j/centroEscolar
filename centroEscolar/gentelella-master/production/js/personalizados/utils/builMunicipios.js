function buildMunicipiosInSelect(json) {
    var select = document.getElementById("municipios")
    document.getElementById("municipios").innerHTML = "";

    var optionSeleccioneUna = document.createElement("option")
    optionSeleccioneUna.value = "-1"
    optionSeleccioneUna.text = "Seleccione una opción";
    select.appendChild(optionSeleccioneUna);
    if (json.response.municipios.length > 0) {
        for (var i = 0; i < json.response.municipios.length; i++) {
            if (select != undefined) {
                var option = document.createElement("option")
                option.value = json.response.municipios[i];
                option.text = json.response.municipios[i];
                select.appendChild(option);
            }
        }
    }
}