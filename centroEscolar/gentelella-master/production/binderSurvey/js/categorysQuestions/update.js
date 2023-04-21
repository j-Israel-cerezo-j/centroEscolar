function update() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
    } else {
        var id = $("#save").val();
        var formData = new FormData(document.getElementById("form1"));
        formData.append('id', id)
        crudCatalogAjax('update', formData)

        document.getElementById("save").value = "";
        document.getElementById("form1").reset();
        document.getElementById("labelMsjAction").innerText = "Agregar categoria de preguntas en encuestas";

    }
    onkeyupInputEmtyy('descripcion')
    form.classList.add('was-validated');



}