function MakeProductPopular(url,id) {
    $.post(url, { "id": id }, function (res) { document.getElementById("popularcountsection").innerHTML = res; });
}