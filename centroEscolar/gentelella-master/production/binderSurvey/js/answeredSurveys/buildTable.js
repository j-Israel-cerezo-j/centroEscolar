function buildTable(json) {
    document.getElementById("containerTable").innerHTML = "";
    var ban = false;
    var cont = 1;
    var html = `                  
                         <table class="table" id="tableQuestionsAnswer">
                            <thead class="table-dark">
                                <tr>                                    
                                    <th class="column-title" style="display: table-cell;">No.</th>
                                    <th class="column-title" style="display: table-cell;">Nombre(s) </th>
                                    <th class="column-title" style="display: table-cell;">Universidad </th>
                                </tr>
                             </thead>
                             <tbody>`;
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;
            html +=
                                `<tr class="">                                       
                                    <td class=" ">${cont++}</td>
                                    <td class=" " > ${json[i].nombres}</td>
                                    <td class=" " > ${json[i].universidad_nombre}</td>
                                </tr> `
        }
    }
    html += `</tbody>
                         </table>`
    if (ban) {
        document.getElementById("containerTable").innerHTML = html;
    } else {
        document.getElementById("containerTable").innerHTML = "<h4 class=''>Aún no hay registros agregados</h4>"
    }

}