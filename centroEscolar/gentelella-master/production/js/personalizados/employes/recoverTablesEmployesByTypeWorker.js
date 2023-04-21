function recoverTablesByTyperWorker() {
    var typeWorker = document.getElementById("typeWorkerSlc").value;
    var seekerEmployesInput = document.getElementById("seekerEmployes");
    seekerEmployesInput.placeholder = "Buscar por tipo de trabajador " + typeWorker+"...";
    recoverTableByTypeWorkerAjax(typeWorker);//<-AJAX
}