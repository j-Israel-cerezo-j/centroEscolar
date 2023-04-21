function builSelectResponseTypeClassrooOption(json) {
    var select = document.getElementById("typeClassroomOptions")
    document.getElementById("typeClassroomOptions").innerHTML = "";

    var optionSeleccioneUna = document.createElement("option")
    optionSeleccioneUna.value = "-1"
    optionSeleccioneUna.text = "Seleccione una opción";

    var optionSeleccioneFullRegistros = document.createElement("option")
    optionSeleccioneFullRegistros.value = "-2"
    optionSeleccioneFullRegistros.text = "Todos los registros";
    select.appendChild(optionSeleccioneFullRegistros);
    if (json.length > 0) {
        for (var i = 0; i < json.length; i++) {
            if (select != undefined) {
                var option = document.createElement("option")
                option.text = json[i].nombre
                if (json[i].idEdificio != undefined) {
                    option.value = json[i].idEdificio
                }
                else if (json[i].idCarrera != undefined) {
                    option.value = json[i].idCarrera
                }
                else {
                    option.value = json[i].id
                }
                select.appendChild(option);
            }
        }
    }
}