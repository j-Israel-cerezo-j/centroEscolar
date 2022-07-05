function typeRequest(typeR) {
    var formData = new FormData(document.getElementById("form1"));    
    catalogosAddUpdateDelete(typeR, formData);
}

function catalogosAddUpdateDelete(typeR, formData) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);   
    formData.append('typeSubmit', typeR);
    $.ajax({
        url: "Handlers/submitHandlerCatalogos.aspx",
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
                switchTablePahe(resultado.data.table, resultado.data.info)
            }
            else {
                if (resultado.error == undefined) {                    
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        title: 'Oops... ¡ Algo salio mal !',
                        text: i
                    })
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        title: 'Oops...',
                        text: resultado.error
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

function switchTablePahe(json, info) {
    switch (info) {
        case 'roles':
            buildTableRoles(json, true);
            break;
        case 'alumnos':
            buildTableStudents(json);
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
    }

    $('#tbl-roles input[type=checkbox]').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        handle: 'checkbox'
    });
    addEventCheckAll();
}