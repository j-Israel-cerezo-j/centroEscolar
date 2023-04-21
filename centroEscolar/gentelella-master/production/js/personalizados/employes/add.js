function addE() {

    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
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
        onkeyupInputEmtyy('formFile')
        onkeyupNoSelectInSlc('estadosMexico');
        onkeyupNoSelectInSlc('municipios');
        //var typeWorkerRadio = document.querySelector('input[name="typeWorker"]:checked');
        //onkeyupContainerEmtyy("containerTypeWorker", typeWorkerRadio);
    } else {
        var formData = new FormData(document.getElementById("form1"));
        var typeWorkerRadio = document.querySelector('input[name="typeWorker"]:checked');
        var valueTypeWorkerRadio = "";
        if (typeWorkerRadio != null) {
            valueTypeWorkerRadio = typeWorkerRadio.value
        }
        catalogosAddUpdateDelete('add', formData, valueTypeWorkerRadio)
        document.getElementById("containerRolesTypeWorker").innerHTML = ""    
        $("#containerCarreras").css('display', 'none');
    }
    form.classList.add('was-validated')
}