function onkeyupSearchh() {
    var typeWorker = document.getElementById("typeWorkerSlc").value
    var formData = new FormData(document.getElementById("formOnkeyup"));
    formData.append('typeWorkerSlc', typeWorker)
    OnkeyupSerchCatalogos("trabajadores", formData, typeWorker)
}