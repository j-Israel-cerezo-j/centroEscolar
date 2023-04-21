function buildImageNoRecordss(path, idContainerAdd) {
    var html = `<div class="alert alert-info alert-dismissible" id="success-alert">
                   <strong>Sin registros por el momentos.</strong>
                </div>
                <div align="center"><img src="${path}"  width="350" height="350"/></div>`;
    document.getElementById(idContainerAdd).innerHTML = html;
}