function SwitchTableOnkeyup(catalogo, json, jsonOnkeyp = true, typeWorker) {
    switch (catalogo) {
        case 'roles':
            buildTableRoles(json, jsonOnkeyp);
            break;
        case 'alumnos':

            const promiseStatusUser = fetch('Handlers/requestDataStatusUserHandler.aspx?User=alumnos')
            promiseStatusUser
                .then((resp) => resp.json())
                .then((resp) => {
                    buildTableStudents(json, resp.data.jsonStatusUsers, jsonOnkeyp);
                });
            break;
        case 'grupos':
            buildTableGroups(json, jsonOnkeyp);
            break;
        case 'carreras':
            buildTableCarrers(json, jsonOnkeyp);
            break;
        case 'cuatrimestres':
            buildTableAcademicLev(json, jsonOnkeyp);
            break;
        case 'periodos':
            buildTablePeriods(json, jsonOnkeyp);
            break;
        case 'materias':
            buildTableSubjects(json, jsonOnkeyp);
            break;
        case 'horas':
            buildTableHours(json, jsonOnkeyp);
            break;
        case 'divisiones':
            buildTableDivisions(json, jsonOnkeyp);
            break;
        case 'edificios':
            buildTableBuildings(json, jsonOnkeyp);
            break;
        case 'studentCandidates':
            requestStatusCandidates(json, jsonOnkeyp)            
            break;
        case 'typesWorkers':
            buildTableTypesWorkers(json, jsonOnkeyp)
            break; 
        case 'trabajadores':

            const statusUsersPromise = fetch('Handlers/requestDataStatusUserHandler.aspx?User=trabajadores');
            statusUsersPromise
                .then((resp) => resp.json())
                .then((resp) => {
                    if (typeWorker == "Divisional") {
                        buildTableEmploysDivisionales(json, resp.data.jsonStatusUsers, jsonOnkeyp)
                    } else if (typeWorker == "General") {
                        buildTableEmploysGenerales(json, resp.data.jsonStatusUsers, jsonOnkeyp);
                    }
                });
            break; 
        case 'tiposDeSalon':
            buildTableTypeClassrooms(json, jsonOnkeyp)
            break; 
        case 'salones':
            buildTableClassrooms(json, jsonOnkeyp)
            break; 
        case 'privilegiosRoles':
            buildTablePR(json, jsonOnkeyp)
            break; 
    }
}