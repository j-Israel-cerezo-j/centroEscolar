function XMLHttpRequestStatesMexico() {
    var xhr = new XMLHttpRequest(); //invocar nueva instancia de XMLHttpRequest
    xhr.onload = exito; // llamar a la funcion exito si exitosa
    xhr.onerror = error;  // llamar a la funcion error si fallida
    xhr.open('GET', 'https://apisgratis.com/cp/entidades/'); // Abrir solicitud GET
    xhr.send()

    // funcion para cuando la llamada es exitosa
    function exito() {
        var datos = JSON.parse(this.responseText); //convertir a JSON
        buildMexicoStatesInSelect(datos);
    }

    // funcion para la llamada fallida
    function error(err) {
        console.log('Solicitud fallida', err); //los detalles en el objecto "err"
    }

}