/*------------------------------------SliderType1--------------------------------------------*/
$(".SliderType1 .sliderTitles > *").append("<section class='tile'></section>")
$(".SliderType1 .sliderTitles .tile").each(function (index, element) {
    h = $(element).height();
    $(element).css({ "border-right": h + "px solid #eb4e14" });
    $(element).css({ "border-top": (h / 2) + "px solid transparent" });
    $(element).css({ "border-bottom": (h / 2) + "px solid transparent" });
});

function SliderType1ChangeSlide_byindex(ind) {
    $(".SliderType1 .sliderTitles > *.active").removeClass("active");
    $($(".SliderType1 .sliderTitles > *")[ind]).addClass("active");

    ds = $($(".SliderType1 .sliderTitles > *")[ind]).attr("data-slide");

    $(".SliderType1 .sliderItems .slideItem.active").removeClass('active');
    $(".SliderType1 .sliderItems .slideItem[data-slide=" + ds + "]").addClass("active");
}
function SliderType1ChangeSlide_byelement(el) {
    $(".SliderType1 .sliderTitles > *.active").removeClass("active");
    $(el).addClass("active");

    ds = $(el).attr("data-slide");

    $(".SliderType1 .sliderItems .slideItem.active").removeClass('active');
    $(".SliderType1 .sliderItems .slideItem[data-slide=" + ds + "]").addClass("active");
}

var SLIDER_TYPE_1_CURRENTINDE = 0;
var SLIDER_TYPE_1_TIMEOUT_CONTIANER = false;

function SliderType1_DoSlideChange() {
    SliderType1ChangeSlide_byindex(SLIDER_TYPE_1_CURRENTINDE++)
    if (SLIDER_TYPE_1_CURRENTINDE >= $(".SliderType1 .sliderItems .slideItem").length)
        SLIDER_TYPE_1_CURRENTINDE = 0;

    if(SLIDER_TYPE_1_TIMEOUT_CONTIANER)
        clearTimeout(SLIDER_TYPE_1_TIMEOUT_CONTIANER);
    SLIDER_TYPE_1_TIMEOUT_CONTIANER = setTimeout(function () { SliderType1_DoSlideChange() }, 5000);
}
SliderType1_DoSlideChange();
/*---------------------------------ENDSliderType1--------------------------------------------*/

/*------------------------------------SliderType2--------------------------------------------*/
function SliderType2ChangeSlide_byindex(ind) {
    $(".SliderType2 .sliderTitles > *.active").removeClass("active");
    $($(".SliderType2 .sliderTitles > *")[ind]).addClass("active");

    ds = $($(".SliderType2 .sliderTitles > *")[ind]).attr("data-slide");

    $(".SliderType2 .sliderItems .slideItem.active").removeClass('active');
    $(".SliderType2 .sliderItems .slideItem[data-slide=" + ds + "]").addClass("active");
}
function SliderType2ChangeSlide_byelement(el) {
    $(".SliderType2 .sliderTitles > *.active").removeClass("active");
    $(el).addClass("active");

    ds = $(el).attr("data-slide");

    $(".SliderType2 .sliderItems .slideItem.active").removeClass('active');
    $(".SliderType2 .sliderItems .slideItem[data-slide=" + ds + "]").addClass("active");
}

var SLIDER_TYPE_2_CURRENTINDE = 0;
var SLIDER_TYPE_2_TIMEOUT_CONTIANER = false;

function SliderType2_DoSlideChange() {
    SliderType2ChangeSlide_byindex(SLIDER_TYPE_2_CURRENTINDE++)
    if (SLIDER_TYPE_2_CURRENTINDE >= $(".SliderType2 .sliderItems .slideItem").length)
        SLIDER_TYPE_2_CURRENTINDE = 0;

    if(SLIDER_TYPE_2_TIMEOUT_CONTIANER)
        clearTimeout(SLIDER_TYPE_2_TIMEOUT_CONTIANER);
    SLIDER_TYPE_2_TIMEOUT_CONTIANER = setTimeout(function () { SliderType2_DoSlideChange() }, 5000);
}
SliderType2_DoSlideChange();

/*---------------------------------ENDSliderType2--------------------------------------------*/

/*------------------------------------SliderType3--------------------------------------------*/
$(".SliderType3 .sliderNav.left").click(function (e) {
    SliderType3GoLeft(e.target);
});
$(".SliderType3 .sliderNav.right").click(function (e) {
    SliderType3GoRight(e.target);
});

var SliderType3GoLeft_intvl = false;
function SliderType3GoLeft(el) {
    cw = $(el).parent(".SliderType3").width();
    c2w = $(".sliderItems", $(el).parent(".SliderType3")).width();

    if (c2w >= cw) {
        cx = parseInt($(".sliderItems", $(el).parent(".SliderType3")).css("right"));

        var nr = ((cw) + cx)

        if (nr >= cw)
            return;

        if (!SliderType3GoLeft_intvl) {
            SliderType3GoLeft_intvl = setInterval(function () {
                cx2 = parseInt($(".sliderItems", $(el).parent(".SliderType3")).css("right"));
                if (cx2 >= nr || cx2 >= 0) {
                    clearInterval(SliderType3GoLeft_intvl);
                    SliderType3GoLeft_intvl = false;
                }
                $(".sliderItems", $(el).parent(".SliderType3")).css("right", (cx2 + 10) + "px")
            }, 10);
        }


    }
}
var SliderType3GoRight_intvl = false;
function SliderType3GoRight(el) {
    cw = $(el).parent(".SliderType3").width();
    c2w = $(".sliderItems", $(el).parent(".SliderType3")).width();

    if (c2w > cw) {
        cx = parseInt($(".sliderItems", $(el).parent(".SliderType3")).css("right"));

        var nr = cx - ((cw))

        if (nr <= -c2w)
            return;

        if (!SliderType3GoRight_intvl) {
            SliderType3GoRight_intvl = setInterval(function () {
                cx2 = parseInt($(".sliderItems", $(el).parent(".SliderType3")).css("right"));
                if (cx2 <= nr || cx2 <= (cw - c2w)) {
                    clearInterval(SliderType3GoRight_intvl);
                    SliderType3GoRight_intvl = false;
                }
                $(".sliderItems", $(el).parent(".SliderType3")).css("right", (cx2 - 10) + "px")
            }, 10);
        }


    }
}
/*---------------------------------ENDSliderType3--------------------------------------------*/




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
    $.post('/Store/AddToCart', { 'id': id, 'type': type }, function (res) {
        MessageBoxShow("محصول به سبد خرید اضافه شد");
    });
}
function AddToCart2(id, type, priceflag) {
    $.post('/Store/AddToCart_PriceFlag', { 'id': id, 'type': type, 'PriceFlag': priceflag }, function (res) {
        MessageBoxShow("محصول به سبد خرید اضافه شد");
    });
}
/*----------------------------------[ END Add To CartRequest ]------------------------------*/

/*---------------------------------------Input Rating Section---------------------*/

$(".input.rating").each(function (index, element) {
    $(".ratingSectionSlider", element).css(
	    "width",
	    (parseFloat($("input", element).attr('value')) * 10) + "%"
	    );
});
$(".input.rating  .ratingSection[data-value]").each(function (index, element) {
    $(".ratingSectionSlider", element).css(
	    "width",
	    (parseFloat($(element).attr('data-value')) * 10) + "%"
	    );
});

function ratint_Onclick(e) {
    tw = e.target.clientWidth;
    ox = e.offsetX + 3;
    ro = (ox * 100) / tw;
    if (ro > 100)
        ro = 100;
    $("input", e.target.offsetParent).attr("value", parseFloat(ro / 10).toFixed(2));
    $(".ratingSectionSlider", e.target).css("width", ro + "%");
}

function ratint_OnMouseMove(e) {
    tw = e.target.clientWidth;
    ox = e.offsetX + 3;
    ro = (ox * 100) / tw;
    if (ro > 100)
        ro = 100;
    $(".ratingSectionFakeSlider", e.target).css("width", ro + "%");
}

function Input_ChangeRating(e) {
    var v = e.target.value * 10;
    if (v > 100)
        v = 100;
    $(".ratingSectionSlider", e.target.offsetParent).css("width", v + "%");
}

function floatNumber(e) {
    var arr = ["Backspace", "Delete", "Home", "End", ".", "Tab", "Enter", "F5"];
    return ((e.key >= 0 && e.key <= 9) || arr.indexOf(e.key) >= 0)

}

/*---------------------------------------Input Rating Section---------------------*/




function ReloadCaptcha(id) {
    el = document.getElementById(id);
    el.src = "";
    tim = new Date().getTime();

    el.src = "/default/index/" + tim;
}