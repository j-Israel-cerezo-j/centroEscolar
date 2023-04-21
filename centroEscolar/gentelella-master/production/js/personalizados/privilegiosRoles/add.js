function addPR() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()        
        onkeyupNoSelectInSlc('roles');
    } else {
        var formData = new FormData(document.getElementById("form1"));
        catalogosAddUpdateDelete('add', formData)
        document.getElementById("form1").reset();
    }
    form.classList.add('was-validated')      
}