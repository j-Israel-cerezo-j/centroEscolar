function addStudenCandidatee() {
    
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
        onkeyupNoSelectInSlc('estadosMexico');
        onkeyupNoSelectInSlc('municipios');
        onkeyupNoSelectInSlc('carreras');
        onkeyupNoSelectInSlc('divisiones');
        //var typeWorkerRadio = document.querySelector('input[name="typeWorker"]:checked');
        //onkeyupContainerEmtyy("containerTypeWorker", typeWorkerRadio);
    } else {
        
        /*$('#modalShowConfirmationData').modal('show')*/
        var carreras = document.getElementById("carreras");
        var carreraSelected = carreras.options[carreras.selectedIndex].text;

        var divisiones = document.getElementById("divisiones");
        var divisionSelected = divisiones.options[divisiones.selectedIndex].text;
      

        Swal.fire({
            title: 'Alto \n ¡Confirma tus datos por favor!"',
            text: 
                "Carrera: " + carreraSelected +".\n"+
                "División: " + divisionSelected + ".\n" +
                "Calle: " + document.getElementById('nomCalle').value + ".\n" +
                "Número interior: " + document.getElementById('noInterior').value + ".\n" +
                "Número exterior: " + document.getElementById('noExterior').value + ".\n" +
                "Estado: " + document.getElementById('estadosMexico').value + ".\n" +
                "Municioio: " + document.getElementById('municipios').value + ".\n" +
                "CP: " + document.getElementById('cp').value + ".\n" +
                "Colonia: " + document.getElementById('colonia').value + ".\n" +
                "Nombre(s): " + document.getElementById('nombres').value + ".\n" +
                "Apellido paterno: " + document.getElementById('apellidoP').value + ".\n" +
                "Apellido materno: " + document.getElementById('apellidoM').value + ".\n" +
                "Correo: " + document.getElementById('email').value + ".\n" +
                "Télefono: " + document.getElementById('tel').value,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Estoy seguro',
            cancelButtonText: 'Volver a revisar'
        }).then((result) => {
            if (result.isConfirmed) {
                var formData = new FormData(document.getElementById("form1"));
                addStudentCandidate(formData);
            }
        })        
    }
    form.classList.add('was-validated')
}