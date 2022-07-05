function alertWithDatas(json) {
    var s = json.matricula;
    var a = json.correoInstitucional;
    var f = json.password;
    Swal.fire({
        icon: 'success',
        title: 'Registro exitoso, espera el dia de tu examen. Tus nuevos datos son: ' +
            'Matricula: ' + json.matricula + ', Correo institucional: ' + json.correoInstitucional +
            ', Contraseña: ' + json.password+'. NOTA:Podras loguearte una vez que hayas sido aceptad...',
        showConfirmButton: false        
    })
}