function onkeyupInputEmtyy(idInput) {
    var input=document.getElementById(idInput).value;
    if (input.length == 0) {
        document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(220 53 69 / 25%)"
        //window.location = "#" + idInput;
        //$("#" + idInput).focus();
        //buildMsjInValid(msj, idContainer);        
    } else {
        document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(25 135 84 / 25%)" 
        //buildMsjValid(idContainer);        
    }
}

function onkeyupContainerEmtyy(idContainer,value) {
    if (value==null) {
        document.getElementById(idContainer).style.boxShadow = "0 0 0 0.25rem rgb(220 53 69 / 25%)"
    } else {
        document.getElementById(idContainer).style.boxShadow = "0 0 0 0.25rem rgb(25 135 84 / 25%)"
    }
}

function formantCorrectInput(idInput, idContainerMsjEmpty, idContainerMsjFormantIncorrect,character) {
    var input = document.getElementById(idInput).value;
    if (input.length == 0) {
        document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(220 53 69 / 25%)"
        document.getElementById(idContainerMsjEmpty).style.display = "block"
        document.getElementById(idContainerMsjFormantIncorrect).style.display = "none"
    } else {
        if (input.includes(character)) {
            document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(25 135 84 / 25%)"
            document.getElementById(idContainerMsjEmpty).style.display = "none"
            document.getElementById(idContainerMsjFormantIncorrect).style.display = "none"
        } else {
            document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(220 53 69 / 25%)"
            document.getElementById(idContainerMsjFormantIncorrect).style.display = "block"
            document.getElementById(idContainerMsjEmpty).style.display = "none"
        }
    }    
}

function lengthCorrectInput(idInput, idContainerMsjEmpty, idContainerMsjFormantIncorrect, minLength, maxLength) {
    var input = document.getElementById(idInput).value;
    if (input.length == 0) {
        document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(220 53 69 / 25%)"
        document.getElementById(idContainerMsjEmpty).style.display = "block"
        document.getElementById(idContainerMsjFormantIncorrect).style.display = "none"
    } else {
        if (input.length <= maxLength && input.length >= minLength) {
            document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(25 135 84 / 25%)"
            document.getElementById(idContainerMsjEmpty).style.display = "none"
            document.getElementById(idContainerMsjFormantIncorrect).style.display = "none"
        } else {
            document.getElementById(idInput).style.boxShadow = "0 0 0 0.25rem rgb(220 53 69 / 25%)"
            document.getElementById(idContainerMsjFormantIncorrect).style.display = "block"
            document.getElementById(idContainerMsjEmpty).style.display = "none"
        }
    }
}