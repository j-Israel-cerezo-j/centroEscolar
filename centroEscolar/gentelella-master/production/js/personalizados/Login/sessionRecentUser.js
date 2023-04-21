function deleteSessionRecentUser(userco, event) {
    var id = event.target.attributes.id.value;
    var formData = new FormData(document.getElementById("formLogin"));
    formData.append('cookieUserDelete', userco);
    deleteSessionRecentCard(formData)
}