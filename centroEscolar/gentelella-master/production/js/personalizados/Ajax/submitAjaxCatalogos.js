function typeRequest(typeR) {
    var formData = new FormData(document.getElementById("form1"));  
    var dataNameTextInput = document.getElementById("divTypeWorker");
    var textNameInput = dataNameTextInput.getAttribute("data-type-worker")
    formData.append('dataNameText', textNameInput)
    catalogosAddUpdateDelete(typeR, formData);
}

function catalogosAddUpdateDelete(typeR, formData,typeWorker="") {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);   
    formData.append('typeSubmit', typeR);
    $.ajax({
        url: "Handlers/submitHandlerCatalogos.aspx?typeWorker=" + typeWorker,
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            swal.close()
            if (resultado.success) {                
                if (resultado.data.type == "add") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Agregado con exito.',
                        showConfirmButton: false,
                        timer: 1500
                    })
                } else if (resultado.data.type == "delete") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Eliminado con exito.',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }   
                else if (resultado.data.type == "update") {                    
                    Swal.fire({
                        icon: 'success',
                        title: 'Registro actualizado.',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    dafaultBtnsDisplay();
                }
                switchTablePahe(resultado.data.table, resultado.data.info, typeWorker)
            }
            else {
                if (resultado.error == undefined) {                    
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        text: resultado.error,
                        footer: resultado.data.footeer
                    })
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        title: 'Oops...',
                        text: resultado.error,
                        footer: resultado.data.footeer
                    })                    
                }
            }
        },
        error: function (xhr, error, code) {
            alert("error");
            Swal.fire({
                icon: 'error',
                confirmButtonColor: '#572364',
                title: 'Oops... ¡ Algo salio mal !',
                text: 'Recargar la pagina por favor.'
            })
        }

    });
}

function switchTablePahe(json, info, typeWorker="") {
    switch (info) {
        case 'roles':
            buildTableRoles(json, true);
            break;
        case 'alumnos':
            const statusUsersPromise = fetch('Handlers/requestDataStatusUserHandler.aspx?User=alumnos');
            statusUsersPromise
                .then((resp) => resp.json())
                .then((resp) => {
                    buildTableStudents(json, resp.data.jsonStatusUsers);
                });
            
            break;
        case 'grupos':
            buildTableGroups(json);
            break;
        case 'carreras':
            buildTableCarrers(json);
            break;
        case 'cuatrimestres':
            buildTableAcademicLev(json);
            break;
        case 'periodos':
            buildTablePeriods(json);
            break;
        case 'materias':
            buildTableSubjects(json);
            break;
        case 'horas':
            buildTableHours(json);
            break;
        case 'divisiones':
            buildTableDivisions(json);
            break;
        case 'edificios':
            buildTableBuildings(json);
            break;
        case 'typesWorkers':
            buildTableTypesWorkers(json);
            break;
        case 'trabajadores':
            recoverTableByTypeWorkerAjax(typeWorker)
            break;
        case 'tiposDeSalon':
            buildTableTypeClassrooms(json);
            break;
        case 'salones':
            buildTableClassrooms(json);
            break;
        case 'privilegiosRoles':
            buildTablePR(json);
            break;
    }

    //$('#tbl-roles input[type=checkbox]').iCheck({
    //    checkboxClass: 'icheckbox_flat-green',
    //    handle: 'checkbox'
    //});
    
}