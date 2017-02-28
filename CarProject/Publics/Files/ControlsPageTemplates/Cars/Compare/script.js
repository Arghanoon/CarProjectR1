function changeCarBrands(bid, seletargetid) {
    selectElement = document.getElementById(seletargetid);
    selectElement.innerHTML = '';

    $.post(URL+'/'+bid, {}, function (r) {
        r.forEach(function (elm, ind) {
            op = document.createElement('OPTION');
            op.appendChild(document.createTextNode(elm.name));
            op.setAttribute('value', elm.id);
            selectElement.appendChild(op);
        });
    });
}