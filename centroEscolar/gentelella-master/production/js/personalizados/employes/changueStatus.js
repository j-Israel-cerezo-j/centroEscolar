function updateStatus(event) {
    var status = event.target.dataset.value;
    var idEmploye = event.target.dataset.idEmploye;
    var typeWorker = event.target.dataset.typeWorker;
    var user = event.target.dataset.typeUser;
    updateStatusAndAddCandidate(status, idEmploye, user, typeWorker);

}