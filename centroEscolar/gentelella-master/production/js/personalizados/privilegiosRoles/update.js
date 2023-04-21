function update() {


    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
    } else {
        var id = $("#save").val();
        var saveBtn = document.getElementById("save");
        var formData = new FormData(document.getElementById("form1"));
        var antidRol = saveBtn.getAttribute("data-id-AntRol");
        formData.append('id', id)
        formData.append('antidRol', antidRol)
        catalogosAddUpdateDelete('update', formData)

        document.getElementById("save").value = "";
        document.getElementById("form1").reset();
        document.getElementById("labelMsjAction").innerText = "Agregar privilegios a roles"; 

    }   
    onkeyupNoSelectInSlc('roles');
    form.classList.add('was-validated');


   
}