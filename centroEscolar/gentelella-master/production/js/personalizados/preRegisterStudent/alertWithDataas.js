function alertWithDatas(json) {   

    Swal.fire({
        title: 'Bien hecho',
        text: 'Registro exitoso. \n' +
            'Espera el dia de tu examen.\n' +
            'Tus nuevos datos son. \n' +
            'Matricula: ' +
            json.matricula + '. \n' +
            'Correo institucional: \n'+
            json.correoIns + '. \n' +
            'Contraseña: '+ 
            'Tu fecha de nacimiento en formato '+ 
            'AAAA/ M / D.\n' +
            'NOTA: '+ 
            'Podras loguearte una vez ' +
            'que hayas sido aceptado.',
        icon: 'success',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = "Login.aspx";
        }
    })   
}