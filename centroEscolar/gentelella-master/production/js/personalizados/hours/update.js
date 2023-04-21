function update() {
    var id = $("#save").val();
    var formData = new FormData(document.getElementById("form1"));
    formData.append('id', id)
    catalogosAddUpdateDelete('update', formData)
    document.getElementById("save").value = "";
}