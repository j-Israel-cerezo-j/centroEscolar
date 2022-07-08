function buildDivisionsInSelect(divisions) {
    var selectDivisions = document.getElementById("divisiones")
    document.getElementById("divisiones").innerHTML = "";

    var optionSeleccioneUna = document.createElement("option")
    optionSeleccioneUna.value = "-1"
    optionSeleccioneUna.text = "Seleccione una opción";    
    selectDivisions.appendChild(optionSeleccioneUna);
    if (divisions.length>0) {
        for (var i = 0; i < divisions.length; i++) {
            if (selectDivisions != undefined) {
                var option = document.createElement("option")
                option.value = divisions[i].id;
                option.text = divisions[i].nombre;
                selectDivisions.appendChild(option);
            }
        }    
    }        
}