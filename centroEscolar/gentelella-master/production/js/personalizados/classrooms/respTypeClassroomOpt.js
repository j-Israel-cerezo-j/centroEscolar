function responseOptionTypeClassroom() {
    var id = document.getElementById("filterBySlc").value
    var lblSlcTypeClassroomOptions = $('select[id="filterBySlc"] option:selected').text();
    document.getElementById("lblSlcTypeClassroomOptions").innerText=""
    document.getElementById("lblSlcTypeClassroomOptions").innerText = lblSlcTypeClassroomOptions;
    responseTypeClassroomOptionss(id);
}