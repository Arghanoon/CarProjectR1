function RearrengCarInformation() {
    arr = [];

    $('.carinfo').each(function (index, element) {
        arr[$(element).attr('data-index')] = element

    });

    alert($(arr[1]).attr('data-index'));
}


$("#CarDetailsInformation > div > div > h3").click(function (e) {
    $(e.target.offsetParent).toggleClass('hide');
});
