function buildRolesByTypeWotker(json) {
    document.getElementById("containerRolesTypeWorker").innerHTML = "";
    var html = "";
    if (json != "" && json != null) {
        for (var i = 0; i < json.length; i++) {
            html += `
                    <div id="divCheck1" class="checkbox col-lg-3 col-md-12 col-sm-12" style="padding:10px;margin-right:15px">					    
					    <div id="divCheck2" class="icheckbox_flat-green hover" style="position: relative;">
                            <input value=${json[i].idRol}  id="ckech${json[i].idRol}" type="checkbox" name="cheksRolesSelec" class="flat" style="position: absolute; opacity: 0;">
                        </div> ${json[i].rol}
					</div>`
        }
    }
    if (html != "") {
        $("#h6Roles").css('display', 'block');
        document.getElementById("containerRolesTypeWorker").innerHTML = html;
        addEventCkechRoles();
    } else {
        document.getElementById("containerRolesTypeWorker").innerHTML = "<h4> No se ha asignado ningún rol al tipo de trabajador seleccionado</h4>"        
    }
}
function addEventCkechRoles() {
    $('#containerRolesTypeWorker input[type=checkbox]').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        handle: 'checkbox'
    });
}