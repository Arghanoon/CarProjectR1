/*-----------------------------------------------------------------------------------------------------------------*/
function slideterItemShowContianer_leftmove(elm) {
    pw = $(elm).width();
    sw = $(".itemsContainer", elm).width();
    sri = parseInt($(".itemsContainer", elm).css("right"));


    if (sw > pw && (sri + sw) > pw) {
        $(".itemsContainer", elm).css("right", (sri - 110))
    }
}

function slideterItemShowContianer_rightmove(elm) {
    pw = $(elm).width();
    sw = $(".itemsContainer", elm).width();
    sri = parseInt($(".itemsContainer", elm).css("right"));


    if (sw > pw && (sri) < 0) {
        $(".itemsContainer", elm).css("right", (sri + 110))
    }
}