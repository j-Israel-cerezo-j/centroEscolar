function buildcoloniasInSelect(json) {
    var select = document.getElementById("colonia")
    document.getElementById("colonia").innerHTML = "";

    var optionSeleccioneUna = document.createElement("option")
    optionSeleccioneUna.value = "-1"
    optionSeleccioneUna.text = "Seleccione una opción";
    select.appendChild(optionSeleccioneUna);
    if (json.asentamientos.length > 0) {
        for (var i = 0; i < json.asentamientos.length; i++) {
            if (select != undefined) {
                var option = document.createElement("option")
                option.value = json.asentamientos[i].nombre;
                option.text = json.asentamientos[i].nombre;
                select.appendChild(option);
            }
        }
    }
}