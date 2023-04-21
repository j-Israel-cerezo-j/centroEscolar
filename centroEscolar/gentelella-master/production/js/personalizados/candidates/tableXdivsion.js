function tableXdiviones(fullCandidates = "") {
    var idSelectCarrera = "-1";
    if (fullCandidates != "") {
        idSelectCarrera = fullCandidates        
    } else {
        idSelectCarrera = document.getElementById("divisiones").value;
    }    
    recoverDataTableXdivisi(idSelectCarrera);
}