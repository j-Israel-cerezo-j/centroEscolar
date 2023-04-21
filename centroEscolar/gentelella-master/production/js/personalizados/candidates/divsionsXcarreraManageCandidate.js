function divisionXcarreraMangeCan() {
    var option = document.getElementById("carreras").value;
    document.getElementById("containerTableCandidates").innerHTML = "";
    document.getElementById("containerTableCandidates").innerHTML = "<h4 class='text-center'>Seleccione una división por favor</h4>"
    if (option == "-2") {
        tableXdiviones(option);
    }
    divisionesXcarreraPre(); 
}