function XMLHttpRequestCPByMunicipe() {
    var municipio = document.getElementById("municipios").value;
    var xhr = new XMLHttpRequest(); //invocar nueva instancia de XMLHttpRequest
    xhr.onload = exito; // llamar a la funcion exito si exitosa
    xhr.onerror = error;  // llamar a la funcion error si fallida
    xhr.open('GET', 'https://api.copomex.com/query/get_cp_por_municipio/' + municipio + '?token=f1378665-ce1e-451f-b011-2f340b03c6aa'); // Abrir solicitud GET
    xhr.send()    
    // funcion para cuando la llamada es exitosa
    function exito() {
        var datos = JSON.parse(this.responseText); //convertir a JSON
        buildcpInSelect(datos);
    }

    // funcion para la llamada fallida
    function error(err) {
        console.log('Solicitud fallida', err); //los detalles en el objecto "err"
    }
}