﻿function buildPdfOfTablee() {

    var doc = new jsPDF();
    var elementHTML = $('#containerTableCategorys').html();
    var specialElementHandlers = {
        '#elementH': function (element, renderer) {
            return true;
        }
    };
    doc.fromHTML(elementHTML, 15, 15, {
        'width': 170,
        'elementHandlers': specialElementHandlers
    });

    // Save the PDF
    doc.save('sample-document.pdf');
}