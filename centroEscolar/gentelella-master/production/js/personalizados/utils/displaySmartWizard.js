function displaySmartWizarddstep2Block(idStep1, idStep2, idStep3 = "", idStep4 = "") {
    $(idStep2).css('display', 'block');
    $(idStep1).css('display', 'none');

    if (idStep3 != "") {
        $(idStep3).css('display', 'none');
    } if (idStep4 != "") {
        $(idStep4).css('display', 'none');
    }
}
function displaySmartWizarddstep1Block(idStep1, idStep2, idStep3 = "", idStep4="") {
    $(idStep2).css('display', 'none');
    $(idStep1).css('display', 'block');
    if (idStep3 != "") {
        $(idStep3).css('display', 'none');
    }
    if (idStep4 != "") {
        $(idStep4).css('display', 'none');
    }

}
function displaySmartWizarddstep3Block(idStep1, idStep2, idStep3 = "", idStep4 = "") {
    $(idStep2).css('display', 'none');
    $(idStep1).css('display', 'none');
    if (idStep3 != "") {
        $(idStep3).css('display', 'block');
    } if (idStep4 != "") {
        $(idStep4).css('display', 'none');
    } 
}
function displaySmartWizarddstep4Block(idStep1, idStep2, idStep3 = "", idStep4 = "") {
    $(idStep2).css('display', 'none');
    $(idStep1).css('display', 'none');
    if (idStep3 != "") {
        $(idStep3).css('display', 'none');
    } if (idStep4 != "") {
        $(idStep4).css('display', 'block');
    }
}