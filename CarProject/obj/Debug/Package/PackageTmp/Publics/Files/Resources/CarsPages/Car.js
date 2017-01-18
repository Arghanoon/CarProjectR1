function MakeProductPopular(url, id) {
    $.post(url, { "id": id }, function (res) {
        document.getElementById("popularSectionCounter").innerHTML = res;
        $("#popularSectionCounter").addClass("animated pulse")
            .one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                $("#popularSectionCounter").removeClass("animated pulse")
            });
    });
}