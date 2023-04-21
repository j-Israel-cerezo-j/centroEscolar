function addSurveys() {  
    var formData = new FormData(document.getElementById("form1"));    
    crudCatalogAjax('add', formData)
}