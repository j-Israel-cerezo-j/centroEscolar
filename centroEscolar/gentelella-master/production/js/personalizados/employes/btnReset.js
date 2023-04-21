function buttonReset() {
    document.getElementById("image").setAttribute("src", "");
    document.getElementById("containerRolesTypeWorker").innerHTML = ""    
    document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
    $("#containerCarreras").css('display', 'none');
    document.getElementById("form1").reset();
    document.getElementById('fechaNac').value = currentDate(document.getElementById("fechaNac").value);
}