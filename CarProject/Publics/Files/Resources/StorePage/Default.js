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
                if (cx2 >= nr || cx2 >= cw) {
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
                if (cx2 <= nr || cx2 <= -c2w) {
                    clearInterval(SliderType3GoRight_intvl);
                    SliderType3GoRight_intvl = false;
                }
                $(".sliderItems", $(el).parent(".SliderType3")).css("right", (cx2 - 10) + "px")
            }, 10);
        }


    }
}
/*---------------------------------ENDSliderType3--------------------------------------------*/