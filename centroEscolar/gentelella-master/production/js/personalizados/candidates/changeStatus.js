function changeStaatus(event) {
    var status = event.target.dataset.value;
    var idCandidate = event.target.dataset.idCandidate;    
    updateStatusAndAddCandidate(status, idCandidate);

}