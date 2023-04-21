var json;
function consumeJsonUniversity() {
    
}

function add(formData) {
    var f = $(this);
    $.ajax({
        url: "Handlers/addUniversityHandler.aspx",
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {           
        },
    });
}

//function buildUniversity() {

   
//    var universitySearch = document.getElementById("seekerUniversitys").value
//    select = document.getElementById('datalistOptionsSerch');
//    selectInnerHtml = document.getElementById('datalistOptionsSerch').innerHTML = "";
//    if (json.includes(universitySearch)) {
//        console.log("hola")
//        //var opt = document.createElement('option');
//        //opt.value = json[i].universidad_nombre;
//        //opt.innerHTML = json[i].universidad_nombre;
//        //select.appendChild(opt);
//    } else {
//        console.log("no hola")
//    }
//    //for (var i = 0; i < json.length; i++) {
//    //    var opt = document.createElement('option');
//    //    opt.value = json[i].universidad_nombre;
//    //    opt.innerHTML = json[i].universidad_nombre;
//    //    select.appendChild(opt);
//    //}    
        
//}