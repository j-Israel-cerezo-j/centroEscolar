function buildTableQuestionsCategory(json, jsonOnkeyp = true) {
    document.getElementById("containerTableCategorys").innerHTML = "";
    var ban = false;
    var cont = 1;
    var html = `           
                  <div>
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
                            <th class="column-title" style="display: table-cell;">No.</th>
                                    <th class="column-title" style="display: table-cell;">Categoria </th>
                            <th class="column-title no-link last" style="display: table-cell;"><span class="nobr">Editar</span>
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
                `<tr class="even pointer">
                                    <td class="a-center ">
                                        <div class="icheckbox_flat-green" style="position: relative;">
                                            <input type="checkbox" value="${json[i].id}" id="cheksa${json[i].id}" class="flat" name="table_records" style="position: absolute; opacity: 0;">
                                        </div>
                                    </td>
                                    <td class=" ">${cont++}</td>`
            html += ` <td class=" ">${json[i].descripcion}</td>`            
            html += `<td class="last"><button id="${json[i].id}" type="button" onclick="recoverDataa(event)" class="btn btn-success fa fa-pencil" style="height: 40px;width: 40px;"></button></td>`
            html += `
                                </tr> `
        }
    }
    html += `</tbody>
                      </table>
                    </div>													
                  </div>`
    if (ban) {
        document.getElementById("containerTableCategorys").innerHTML = html;
        initChecksTable();
        addEventCheckAll();
    } else if (!jsonOnkeyp) {
        document.getElementById("containerTableCategorys").innerHTML = "<h4 class='text-center'>No se encontro ninguna coincidencia</h4>"
    } else {
        document.getElementById("containerTableCategorys").innerHTML = "<h4 class='text-center'>Aún no hay registros agregados</h4>"
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

