function buildTablePeriods(json) {
    document.getElementById("containerTablePeriods").innerHTML = "";
    var ban = false;
    var cont = 1;
    var html = `           
                  <div class="x_title">
                    <h2>Periodos<small></small></h2>
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
                            <th>
                              <div class="icheckbox_flat-green" style="position: relative;">
                                <input type="checkbox" id="check-all" class="flat" style="position: absolute; opacity: 0;">
                              </div>
                            </th>
                            <th class="column-title" style="display: table-cell;">No. </th>
                            <th class="column-title" style="display: table-cell;">Periodo</th>
                            <th class="column-title" style="display: table-cell;">Fecha de início</th>
                            <th class="column-title" style="display: table-cell;">Fecha de término</th>
                            <th class="column-title no-link last" style="display: table-cell;"><span class="nobr">Modificar</span>
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
                                    <td class="a-center ">
                                        <div class="icheckbox_flat-green" style="position: relative;">
                                            <input type="checkbox" value="${json[i].id}" id="cheksa${json[i].id}" class="flat" name="table_records" style="position: absolute; opacity: 0;">
                                        </div>
                                    </td>
                                    <td class=" ">${cont++}</td>`
        html += ` <td class=" ">${json[i].nombre}</td>`
        html += ` <td class=" ">${json[i].fechaInicio}</td>`
        html += ` <td class=" ">${json[i].fechaTermino}</td>`
        html += `<td class="last"><button id="${json[i].id}" type="button" onclick="recoverDataa(event)" class="btn btn-success">Modificar</button></td>`
        html += `
                                </tr> `
    }
    html += `</tbody>
                      </table>
                    </div>													
                  </div>`
    if (ban) {
        document.getElementById("containerTablePeriods").innerHTML = html;
    } else {
        document.getElementById("containerTablePeriods").innerHTML = "<h4 class='text-center'>Aún no hay registros agregados</h4>"
    }

}

function addEventCheckAll() {
    var checkAll = document.getElementById('check-all');
    checkAll.nextElementSibling.setAttribute('onclick', 'toggleSelectAll()');
}