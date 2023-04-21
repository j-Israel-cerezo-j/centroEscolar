function addClassroom() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('clave')
        onkeyupInputEmtyy('cupo')
        onkeyupNoSelectInSlc('edificios');
        onkeyupNoSelectInSlc('tipo');
    } else {
        var formData = new FormData(document.getElementById("form1"));
        catalogosAddUpdateDelete('add', formData)
    }
    form.classList.add('was-validated')  
} 