function recoverMunicipess() {
    var state = document.getElementById("estadosMexico").value
    apiMexico("municipios",state);
}