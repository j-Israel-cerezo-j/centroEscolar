function switchCatalogosRecoverData(json, catalogo,jsonMunicipes="") {
    switch (catalogo) {
        case 'roles':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("rol").value = json[i].rol;                
                document.getElementById("save").value = json[i].idRol;  

                $('#radio' + json[i].fkTypeWorker).prop("checked", true);
                $('#radiosTW input[type=radio]').iCheck({
                    radioClass: 'iradio_flat-green',
                    handle: 'radio'
                });
            }                     
            break;
        case 'alumnos':
            for (var i = 0; i < json.length; i++) {

                if (jsonMunicipes != "") {
                    buildMunicipiosInSelect(jsonMunicipes);
                }                
                document.getElementById("nombres").value = json[i].nombres;
                document.getElementById("apellidoP").value = json[i].apellidoP;
                document.getElementById("apellidoM").value = json[i].apellidoM;                
                document.getElementById("email").value = json[i].correoP;
                document.getElementById("tel").value = json[i].telefono;
                document.getElementById("save").value = json[i].id;
                document.getElementById("nomCalle").value = json[i].calle;
                document.getElementById("noInterior").value = json[i].noExterior;
                document.getElementById("noExterior").value = json[i].noInterior;  

                document.getElementById("estadosMexico").value = json[i].estado;
                document.getElementById("municipios").value = json[i].municipio;
                document.getElementById("cp").value = json[i].cp;
                document.getElementById("colonia").value = json[i].colonia;

                document.getElementById("image").setAttribute("src", json[i].image);
                if (json[i].image == "") {
                    document.getElementById("msjImagenCargadaAutomatica").innerHTML = "<h4><b><i>Alumno sin fotografía.</i></b></h4>"
                } else {
                    document.getElementById("msjImagenCargadaAutomatica").innerHTML = "<h4><b><i>Imagen cargada automaticamente.</i></b></h4>"
                }
                
                var inputImage = document.getElementById("image");
                var path = json[i].image == "" ? "..." : json[i].image
                inputImage.setAttribute('data-image-uploadAut', path);

                 var saveBtn = document.getElementById("save");
                saveBtn.setAttribute('data-id-domicilie', json[i].idDomicilio);
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
        case 'typesWorkers':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("typeWorker").value = json[i].descripcion;
                document.getElementById("save").value = json[i].typeWorker; 
            }
            break;
        case 'trabajadores':
            for (var i = 0; i < json.length; i++) {

                if (jsonMunicipes != "") {
                    buildMunicipiosInSelect(jsonMunicipes);
                }
                document.getElementById("nombres").value = json[i].nombres;
                document.getElementById("apellidoP").value = json[i].apellidoP;
                document.getElementById("apellidoM").value = json[i].apellidoM;
                document.getElementById("curp").value = json[i].curp;
                document.getElementById("email").value = json[i].correoP;
                document.getElementById("tel").value = json[i].telefono;
                document.getElementById("save").value = json[i].id;
                document.getElementById("nomCalle").value = json[i].calle;
                document.getElementById("noInterior").value = json[i].noExterior;
                document.getElementById("noExterior").value = json[i].noInterior;
                
               
                $("#fechaNac").val(json[i].fechaNac);

                document.getElementById("estadosMexico").value = json[i].estado;
                document.getElementById("municipios").value = json[i].municipio;
                document.getElementById("cp").value = json[i].cp;

                document.getElementById("colonia").value = json[i].colonia;
                document.getElementById("image").setAttribute("src", json[i].image);
                document.getElementById("msjImagenCargadaAutomatica").innerHTML = "<h4><b><i>Imagen cargada automaticamente.</i></b></h4>"
                var inputImage = document.getElementById("image");
                var path = json[i].image == "" ? "..." : json[i].image
                inputImage.setAttribute('data-image-uploadAut', path);

                var saveBtn = document.getElementById("save");
                saveBtn.setAttribute('data-id-domicilie', json[i].idDomicilio);
                saveBtn.setAttribute('data-ant-typeWorker', json[i].idTypeWorker);

                var idInputTypeWorker = "radio" + json[i].idTypeWorker;
                document.getElementById(idInputTypeWorker).checked = true
                recoverRolesByTypeWorkerr(undefined, idInputTypeWorker)
                recoverRolesSelectedByEmploye(json[i].id, json[i].idTypeWorker);
                if (json[i].idTypeWorker == "Divisional") {
                    recoverDivisionsSelectedByEmploye(json[i].id);
                }
                break;
            }
            break;
        case 'edificios':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("edificio").value = json[i].nombre;
                document.getElementById("carreras").value = json[i].fkCarrera;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'tiposDeSalon':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("typeClassroom").value = json[i].nombre;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'salones':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("clave").value = json[i].clave;
                document.getElementById("cupo").value = json[i].cupo;
                document.getElementById("tipo").value = json[i].fkTipoSalon;
                document.getElementById("edificios").value = json[i].fkEdificio;
                document.getElementById("tipo").value = json[i].fkTipoSalon;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'privilegiosRoles':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("save").value = json[i].fkRol;
                document.getElementById("roles").value = json[i].fkRol;
                for (var j = 0; j < json.length; j++) {
                    var idInputPrivilege = "#ckechPrivilege" + json[j].fkidPrivilege;
                    $(idInputPrivilege).iCheck('check');
                }

                var saveBtn = document.getElementById("save");                
                saveBtn.setAttribute('data-id-AntRol', json[i].fkRol);
                console.log(saveBtn);
                break;                
            }
            break;
    }
}

