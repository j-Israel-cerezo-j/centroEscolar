function checkFullPrivileges() {
     
    if ($('#checkFull').prop('checked')) {
        $('#checksPrivileges input[type=checkbox]').prop("checked", true);
    } else {
        $('#checksPrivileges input[type=checkbox]').prop("checked", false);
    }

     
}