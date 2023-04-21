function hideshow(idInputPass, idInputIcon, idInputIcon2) {
    var password = document.getElementById(idInputPass);
    var slash = document.getElementById(idInputIcon);
    var eye = document.getElementById(idInputIcon2);

    if (password.type === 'password') {
        password.type = "text";
        slash.style.display = "none";
        eye.style.display = "block";
    }
    else {
        password.type = "password";
        slash.style.display = "block";
        eye.style.display = "none";
    }

}
function hideshowConfirm() {
    var password = document.getElementById("confirmPassword");
    var slash = document.getElementById("slashConfirm");
    var eye = document.getElementById("eyeConfirm");

    if (password.type === 'password') {
        password.type = "text";
        slash.style.display = "block";
        eye.style.display = "none";
    }
    else {
        password.type = "password";
        slash.style.display = "none";
        eye.style.display = "block";
    }

}