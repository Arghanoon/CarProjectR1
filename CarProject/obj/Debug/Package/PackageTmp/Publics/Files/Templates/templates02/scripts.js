/*--------------[ RequstShowMessage ]--------------------------*/
function MessageBoxShow(content) {

    $(document.body).append(
                        '<div class="message">' +
                            '<div class="action" onclick="$(\'.message\').remove()">' +
                                '<a href="" >&times;</a>' +
                            '</div>' +
                            '<div class="content">' +
                                content +
                            '</div>' +
                        '</div>'
                        );

    setTimeout(function () { $('.message').remove(); }, 5000);
}
/*--------------[ End RequstShowMessage ]----------------------*/

/*----------------------------------[ Add To CartRequest ]----------------------------------*/
function AddToCart(id, type) {
    $.post('/Store/AddToCart', { 'id': id, 'type': type }, function (res) { MessageBoxShow("محصول به سبد خرید اضافه شد"); });
}
function AddToCart2(id, type, priceflag) {
    $.post('/Store/AddToCart_PriceFlag', { 'id': id, 'type': type, 'PriceFlag': priceflag }, function (res) { MessageBoxShow("محصول به سبد خرید اضافه شد"); });
}
/*----------------------------------[ END Add To CartRequest ]------------------------------*/