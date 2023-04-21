//rol
function update() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('rol')
    } else {
        var id = $("#save").val();
        var formData = new FormData(document.getElementById("form1"));
        formData.append('id', id)
        catalogosAddUpdateDelete('update', formData);
        document.getElementById("save").value = "";
        document.getElementById("form1").reset();
        document.getElementById("labelMsjAction").innerText = "Agregar rol";
        onkeyupInputEmtyy('rol')
    }    

    form.classList.add('was-validated')
}