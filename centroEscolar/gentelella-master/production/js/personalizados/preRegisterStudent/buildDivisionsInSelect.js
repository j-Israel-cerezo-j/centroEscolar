function buildDivisionsInSelect(divisions) {
    var selectDivisions = document.getElementById("divisiones")
    document.getElementById("divisiones").innerHTML = "";
    if (divisions.length == 0) {
        var option = document.createElement("option")
        option.value = "-1"
        option.text = "Seleccione una opción"
        selectDivisions.appendChild(option);
    } else {
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