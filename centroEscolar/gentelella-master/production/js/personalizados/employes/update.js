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
        var antTypeWorker = saveBtn.getAttribute("data-ant-typeWorker");
        var inputImage = document.getElementById("image");
        var imageUploadAut = inputImage.getAttribute("data-image-uploadAut");
        var typeWorkerRadio = document.querySelector('input[name="typeWorker"]:checked');
        var typeWorkerRadioValue = typeWorkerRadio.attributes.value.value;
        formData.append('id', id)
        formData.append('idDomicilie', idDomicilie)
        formData.append('imageUploadAut', imageUploadAut)
        formData.append('antTypeWorker', antTypeWorker)

        catalogosAddUpdateDelete('update', formData, typeWorkerRadioValue);

        document.getElementById("containerRolesTypeWorker").innerHTML = ""
        $("#containerCarreras").css('display', 'none');

        inputImage.setAttribute('data-image-uploadAut', "");
        saveBtn.setAttribute('data-id-domicilie', "");
        antTypeWorker.setAttribute('data-id-domicilie', "");

        document.getElementById("save").value = "";
        document.getElementById("formFile").setAttribute("required", "required");
        document.getElementById("image").setAttribute("src", "");
        document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""                     
        document.getElementById("form1").reset();
        document.getElementById('fechaNac').value = currentDate(document.getElementById("fechaNac").value);    
    }
    onkeyupInputEmtyy('nombres')
    onkeyupInputEmtyy('apellidoP')
    onkeyupInputEmtyy('apellidoM')
    onkeyupInputEmtyy('curp')
    onkeyupInputEmtyy('email')
    onkeyupInputEmtyy('tel')
    onkeyupInputEmtyy('nomCalle')
    onkeyupInputEmtyy('noInterior')
    onkeyupInputEmtyy('noExterior')
    onkeyupInputEmtyy('cp')
    onkeyupInputEmtyy('colonia')
    onkeyupNoSelectInSlc('estadosMexico');
    onkeyupNoSelectInSlc('municipios');
    onkeyupInputEmtyy('formFile')
    //onkeyupContainerEmtyy("containerTypeWorker", typeWorkerRadio);
    form.classList.add('was-validated')
}