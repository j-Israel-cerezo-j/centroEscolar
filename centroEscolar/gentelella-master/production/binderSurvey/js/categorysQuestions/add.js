function addCategory() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('descripcion')
    } else {
        var formData = new FormData(document.getElementById("form1"));
        crudCatalogAjax('add', formData)
    }
    form.classList.add('was-validated')
}