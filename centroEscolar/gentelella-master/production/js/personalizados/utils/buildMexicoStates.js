function buildMexicoStatesInSelect(jsonStates) {
    var selectStates = document.getElementById("estadosMexico")
    document.getElementById("estadosMexico").innerHTML = "";

    var optionSeleccioneUna = document.createElement("option")
    optionSeleccioneUna.value = "-1"
    optionSeleccioneUna.text = "Seleccione una opción";
    selectStates.appendChild(optionSeleccioneUna);
    if (jsonStates.length > 0) {
        for (var i = 0; i < jsonStates.length; i++) {
            if (selectStates != undefined) {
                var option = document.createElement("option")
                option.value = jsonStates[i].Entidad
                option.text = jsonStates[i].Entidad
                selectStates.appendChild(option);
            }
        }
    }
}