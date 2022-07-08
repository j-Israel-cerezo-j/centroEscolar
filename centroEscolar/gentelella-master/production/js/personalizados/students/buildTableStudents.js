﻿function buildTableStudents(json) {
    document.getElementById("containerTableStudents").innerHTML = "";
    var ban = false;
    var cont = 1;
    var html = `           
                  <div class="x_title">
                    <h2>Alumnos<small></small></h2>
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
                            <th class="column-title no-link last" style="display: table-cell;"><span class="nobr">Modificar</span>
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
                            <th class="column-title" style="display: table-cell;">División</th>
                            <th class="column-title" style="display: table-cell;">Carrera</th>
                            </th>
                            <th class="bulk-actions" colspan="7" style="display: none;">
                              <a class="antoo" style="color:#fff; font-weight:500;">Bulk Actions ( <span class="action-cnt">1 Records Selected</span> ) <i class="fa fa-chevron-down"></i></a>
                            </th>
                          </tr>
                        </thead>
                        <tbody>`;
    for (var i = 0; i < json.length; i++) {
        ban = true;
        html +=
            `<tr class="even pointer">
                <td class="last"> <button id="${json[i].idAlumno}" type="button" onclick="recoverDataa(event)" class="btn btn-success">Recuperar datos</button></td >
                <td class="a-center ">
                    <div class="icheckbox_flat-green" style="position: relative;">
                        <input type="checkbox" value="${json[i].idAlumno}" id="cheksa${json[i].idAlumno}" class="flat" name="table_records" style="position: absolute; opacity: 0;">
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
        html += ` <td class=" ">${json[i].carrera}</td>`
        html += `
                                </tr> `
    }
    html += `</tbody>
                      </table>
                    </div>													
                  </div>`
    if (ban) {
        document.getElementById("containerTableStudents").innerHTML = html;
    } else {
        document.getElementById("containerTableStudents").innerHTML = "<h4 class='text-center'>Aún no hay registros agregados</h4>"
    }

}

function addEventCheckAll() {
    var checkAll = document.getElementById('check-all');
    checkAll.nextElementSibling.setAttribute('onclick', 'toggleSelectAll()');
}