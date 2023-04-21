function switchCatalogosRecoverData(json, catalogo) {
    switch (catalogo) {        
        case 'questions':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("save").value = json[i].idQuestion              
                document.getElementById("slcCategorys").value = json[i].fkCategoryQuestion;
                document.getElementById("question").value = json[i].questions;

                for (var j = 0; j < json.length; j++) {
                    var idInputPrivilege = "#checksResponse" + json[j].fkResponse;
                    $(idInputPrivilege).iCheck('check');
                }
                break;
            }
            break;
        case 'questionsCategory':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("save").value = json[i].id;
                document.getElementById("descripcion").value = json[i].descripcion;
                break;
            }
            break;
        case 'questionsAnswer':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("save").value = json[i].idResponse;
                document.getElementById("descripcion").value = json[i].descripcion;
                break;
            }
            break;
    }
}

