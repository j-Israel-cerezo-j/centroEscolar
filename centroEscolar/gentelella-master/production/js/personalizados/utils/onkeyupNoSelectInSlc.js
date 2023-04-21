function onkeyupNoSelectInSlc(idInput) {
    var input = document.getElementById(idInput).value;
    if (input.length == "") {

        document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(220 53 69 / 25%)"
        //window.location = "#" + idInput;
        //$("#" + idInput).focus();
        //buildMsjInValid(msj, idContainer);        
    } else {
        document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(25 135 84 / 25%)"
        //buildMsjValid(idContainer);        
    }
}