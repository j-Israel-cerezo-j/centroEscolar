function buildTableEmploysDivisionales(json, jsonStatusUsers,jsonOnkeyp = true) {
    document.getElementById("containerTableEmploysFull").innerHTML = "";
    var ban = false;
    var cont = 1;
    var html = `           
                  <div class="x_title">
                    <h2>Trabajadores divisionales<small></small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>                      
                      <li><a class="close-link"><i class="fa fa-close"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <div class="table-responsive">
                      <table class="table table-striped jambo_table bulk_action" id="tbl-roles">
                        <thead>
                          <tr class="headings">
                            <th class="column-title no-link last" style="display: table-cell;"><span class="nobr">Editar</span>
                            <th class="column-title" style="display: table-cell;">Acción </th>
                            <th class="column-title" style="display: table-cell;">Estatus </th>
                            <th>
                              <div class="icheckbox_flat-green" style="position: relative;">
                                <input type="checkbox" id="check-all" class="flat" style="position: absolute; opacity: 0;">
                              </div>
                            </th>
                            <th class="column-title" style="display: table-cell;">No. </th>
                            <th class="column-title" style="display: table-cell;">Matricula</th>
                            <th class="column-title" style="display: table-cell;">Nombre(s)</th>
                            <th class="column-title" style="display: table-cell;">Apellidos</th>
                            <th class="column-title" style="display: table-cell;">Curp</th>
                            <th class="column-title" style="display: table-cell;">Correo personal</th>
                            <th class="column-title" style="display: table-cell;">Correo institucional.</th>
                            <th class="column-title" style="display: table-cell;">Teléfono</th>                            
                            <th class="column-title" style="display: table-cell;">División(es)</th>
                            <th class="column-title" style="display: table-cell;">Rol(es)</th>
                            <th class="column-title" style="display: table-cell;">Tipo de trabajador</th>
                            </th>
                            <th class="bulk-actions" colspan="7" style="display: none;">
                              <a class="antoo" style="color:#fff; font-weight:500;">Bulk Actions ( <span class="action-cnt">1 Records Selected</span> ) <i class="fa fa-chevron-down"></i></a>
                            </th>
                          </tr>
                        </thead>
                        <tbody>`;
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {                       
            ban = true;
            html +=
                `
        <tr class="even pointer">
            <td class="last">
                <button id="${json[i].id}" data-id-typeWorker="${json[i].idTypeWorker}" type="button" onclick="recoverDataa(event)" class="btn btn-success fa fa-pencil" style="height: 40px;width: 40px;"></button>
            </td >
            <td class="last">
                <div class="input-group-btn show">
                    <button type="button" class="btn btn-secondary dropdown-toggle" data-toggle="dropdown" aria-expanded="true">Action <span class="caret"></span></button>
                    <ul class="dropdown-menu">`
            for (var j = 0; j < jsonStatusUsers.length; j++) {
                html += `<li id = "status${jsonStatusUsers[j].id}" data-id-employe="${json[i].id}" data-type-user="trabajadores" data-type-worker="${json[i].typeWorker}" data-value="${jsonStatusUsers[j].id}" onclick="updateStatus(event)" class="dropdown-item" >${jsonStatusUsers[j].descripcion}</li>`
            }
            html += `</ul>
                </div>
            </td>`
            html += `
            <td class=" "> ${json[i].statusDescripcion }</td>
            <td class="a-center">
                <div class="icheckbox_flat-green" style="position: relative;">
                    <input type="checkbox" value="${json[i].id}" id="cheksa${json[i].id}" class="flat" name="table_records" style="position: absolute; opacity: 0;">
                </div>
            </td>
            <td class=" ">${cont++}</td>`
            html += ` <td class=" ">${json[i].matricula}</td>`
            html += ` <td class=" ">${json[i].nombres}</td>`
            html += ` <td class=" ">${json[i].apellidoP} ${json[i].apellidoM}</td>`
            html += ` <td class=" ">${json[i].curp}</td>`
            html += ` <td class=" ">${json[i].correoP}</td>`
            html += ` <td class=" ">${json[i].correoIns}</td>`
            html += ` <td class=" ">${json[i].telefono}</td>`
            html += ` <td class=" ">${json[i].division}</td>`
            html += ` <td id="tdRol" class=" ">${json[i].roles}</td>`
            html += ` <td class=" ">${json[i].typeWorker}</td>`
            html += `
                            </tr> `
        }
    }
    html += `</tbody>
                      </table>
                    </div>													
                  </div>`
    if (ban) {
        document.getElementById("containerTableEmploysFull").innerHTML = html;
        initChecksTable();
        addEventCheckAll();
    } else if (!jsonOnkeyp) {
        document.getElementById("containerTableEmploysFull").innerHTML = "<h4 class='text-center'>No se encontro ninguna coincidencia</h4>"
    } else {
        document.getElementById("containerTableEmploysFull").innerHTML = "<h4 class='text-center'>Aún no hay registros agregados</h4>"
    }

}

function addEventCheckAll() {
    var checkAll = document.getElementById('check-all');
    checkAll.nextElementSibling.setAttribute('onclick', 'toggleSelectAll()');
}
function initChecksTable() {
    $('#tbl-roles input[type=checkbox]').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        handle: 'checkbox'
    });
}