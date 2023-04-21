function styleBoxShadowGreen(arrayIdsInputs) {
    for (var i = 0; i < arrayIdsInputs.length; i++) {
        document.getElementById(arrayIdsInputs[i]).style.boxShadow = "0 0 0 0.25rem rgb(25 135 84 / 25%)";
    }
}