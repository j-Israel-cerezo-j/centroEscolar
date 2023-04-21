//alumnos
function update() {     

    
    var form = document.getElementById("form1");
    document.getElementById("formFile").removeAttribute("required");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
    } else {
        var id = $("#save").val();
        var formData = new FormData(document.getElementById("form1"));
        var saveBtn = document.getElementById("save");       
        var idDomicilie = saveBtn.getAttribute("data-id-domicilie");
        var inputImage = document.getElementById("image");
        var imageUploadAut = inputImage.getAttribute("data-image-uploadAut");
        formData.append('id', id);
        formData.append('idDomicilie', idDomicilie);
        formData.append('imageUploadAut', imageUploadAut);

        catalogosAddUpdateDelete('update', formData);

        document.getElementById("save").value = "";
        document.getElementById("formFile").setAttribute("required", "required");
        document.getElementById("image").setAttribute("src", "");
        document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
        document.getElementById("form1").reset();        
        
        inputImage.setAttribute('data-image-uploadAut', "");        
        saveBtn.setAttribute('data-id-domicilie', "");
        
        var idsInputs = ["nombres", "apellidoP", "apellidoM", "email", "nombres", "apellidoP",
            "apellidoM", "email", "tel", "nomCalle", "noInterior", "noExterior",
            "cp", "colonia", "estadosMexico", "municipios","save"];                
        enabledOrDisabledInputs(idsInputs,true);
        
    }
  
    form.classList.add('was-validated')


}
