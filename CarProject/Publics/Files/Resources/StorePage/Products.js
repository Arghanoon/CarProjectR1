function MakeProductPopular(url,id) {
    $.post(url, { "id": id }, function (res) {
        document.getElementById("popularcountsection").innerHTML = res;
        $("#popularcountsection").addClass("animated pulse")
            .one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                $("#popularcountsection").removeClass("animated pulse")
            });
    });
}