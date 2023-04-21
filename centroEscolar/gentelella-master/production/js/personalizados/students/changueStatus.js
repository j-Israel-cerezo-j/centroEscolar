function updateStatus(event) {
    var status = event.target.dataset.statusValue;
    var idUser = event.target.dataset.idAlumno;
    var user = event.target.dataset.typeUser;
    updateStatusAjax(status, idUser, user);

}