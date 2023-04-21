function buildRolesSelected(json) {
    for (var j = 0; j < json.length; j++) {
        var idCheck = "#ckech" + json[j].fkRol
        $(idCheck).iCheck('check');
    }
}
//$("#ckech6").iCheck('check');