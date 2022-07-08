function switchCatalogosRecoverData(json, catalogo) {
    switch (catalogo) {
        case 'roles':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("rol").value = json[i].rol;
                document.getElementById("save").value = json[i].idRol;  
            }                     
            break;
        case 'alumnos':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("nombres").value = json[i].nombres;
                document.getElementById("apellidoP").value = json[i].apellidoP;
                document.getElementById("apellidoM").value = json[i].apellidoM;                
                document.getElementById("email").value = json[i].correoP;
                document.getElementById("tel").value = json[i].telefono;
                document.getElementById("save").value = json[i].idAlumno;

                document.getElementById("idDomicilie").value = json[i].idDomicilio;
                document.getElementById("nomCalle").value = json[i].calle;
                document.getElementById("noInterior").value = json[i].noExterior;
                document.getElementById("noExterior").value = json[i].noInterior;                
            }
            break;
        case 'grupos':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("grupo").value = json[i].nombre;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'carreras':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("carrera").value = json[i].nombre;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'cuatrimestres':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("cuatrimestre").value = json[i].nombre;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'periodos':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("periodo").value = json[i].nombre;
                document.getElementById("save").value = json[i].id;                
                document.getElementById("fechaInicio").value = json[i].fechaInicio;
                document.getElementById("fechaFinal").value = json[i].fechaTermino;
            }
            break;
        case 'materias':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("materia").value = json[i].nombre;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'horas':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("horaInicio").value = json[i].horaInicio;
                document.getElementById("horaTermino").value = json[i].horaTermino;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'divisiones':
            for (var i = 0; i < json.length; i++) {                
                document.getElementById("division").value = json[i].nombre;
                document.getElementById("carreras").value = json[i].fkCarrera;
                document.getElementById("save").value = json[i].id;
            }
            break;

    }
}

