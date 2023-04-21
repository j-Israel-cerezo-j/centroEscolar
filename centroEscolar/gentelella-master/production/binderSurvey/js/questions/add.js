function addQuestion() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation
        onkeyupInputEmtyy('question')
        onkeyupNoSelectInSlc('slcCategorys');
    } else {
        var formData = new FormData(document.getElementById("form1"));
        crudCatalogAjax('add', formData)
    }
    form.classList.add('was-validated')
}


