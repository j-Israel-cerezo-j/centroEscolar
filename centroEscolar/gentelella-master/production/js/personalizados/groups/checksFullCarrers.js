function checkFullCarrers() {

    if ($('#checkFull').prop('checked')) {
        $('#checksCarrers input[type=checkbox]').prop("checked", true);
    } else {
        $('#checksCarrers input[type=checkbox]').prop("checked", false);
    }


}