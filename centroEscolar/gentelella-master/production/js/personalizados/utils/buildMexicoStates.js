function buildMexicoStatesInSelect(jsonStates) {
    if (document.getElementById("estadosMexico") != undefined) {        
        if (document.getElementById("estadosMexico") != undefined) {
            var selectStates = document.getElementById("estadosMexico")
            document.getElementById("estadosMexico").innerHTML = "";
            var optionSeleccioneUna = document.createElement("option")
            optionSeleccioneUna.value = ""
            optionSeleccioneUna.text = "Seleccione una opción";
            selectStates.appendChild(optionSeleccioneUna);
            if (jsonStates.length > 0) {
                for (var i = 0; i < jsonStates.length; i++) {
                    if (selectStates != undefined) {
                        var option = document.createElement("option")
                        option.value = jsonStates[i].nombre
                        option.text = jsonStates[i].nombre
                        selectStates.appendChild(option);
                    }
                }
            }
        }       
    }    
}