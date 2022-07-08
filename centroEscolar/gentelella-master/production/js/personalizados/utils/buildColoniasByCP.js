function buildcoloniasInSelect(json) {
    var select = document.getElementById("colonia")
    document.getElementById("colonia").innerHTML = "";

    var optionSeleccioneUna = document.createElement("option")
    optionSeleccioneUna.value = "-1"
    optionSeleccioneUna.text = "Seleccione una opción";
    select.appendChild(optionSeleccioneUna);
    if (json.response.colonia.length > 0) {
        for (var i = 0; i < json.response.colonia.length; i++) {
            if (select != undefined) {
                var option = document.createElement("option")
                option.value = json.response.colonia[i];
                option.text = json.response.colonia[i];
                select.appendChild(option);
            }
        }
    }
}