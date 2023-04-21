function enabledOrDisabledInputs(arrayIdsInputs, enabled) {
    for (var i = 0; i < arrayIdsInputs.length; i++) { 
        $("#" + arrayIdsInputs[i]).prop('disabled', enabled)
    }
}