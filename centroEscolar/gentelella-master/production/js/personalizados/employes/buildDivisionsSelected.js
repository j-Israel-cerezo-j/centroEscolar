function buildDivisionsSelected(json) {
    for (var j = 0; j < json.length; j++) {
        var idCheck = "#checkDivision" + json[j].fkIdDivision
        $(idCheck).iCheck('check');
    }
}