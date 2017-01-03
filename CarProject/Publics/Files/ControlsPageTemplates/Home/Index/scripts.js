var Mainslideshow_ChangeactiveCurrentItem = 0
var Mainslideshow_Changeactive_TimeOut = false;

function Mainslideshow_Changeactive(itemnum) {
    $("#mainslideshow_titles a.active").removeClass("active");
    $($("#mainslideshow_titles a")[itemnum]).addClass("active");

    $("#mainslideshow_bigimage").addClass('out');
    $('#mainslideshow_bigimage').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {

        document.getElementById("mainslideshow_bigimage").src = $($("#mainslideshow_titles a")[itemnum]).attr("data-image");
        document.getElementById("mainslideshow_bigimageLink").href = $($("#mainslideshow_titles a")[itemnum]).attr("data-target");

        $("#mainslideshow_bigimage").removeClass('out').addClass('in');
        $('#mainslideshow_bigimage').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $("#mainslideshow_bigimage").removeClass('in')
        });
    });

    Mainslideshow_Changeactive_TimmingSetup();
}

function Mainslideshow_Changeactive_TimmingSetup() {
    clearTimeout(Mainslideshow_Changeactive_TimeOut);
    Mainslideshow_Changeactive_TimeOut = setTimeout(function () {
        Mainslideshow_ChangeactiveCurrentItem += 1;
        if (Mainslideshow_ChangeactiveCurrentItem >= $("#mainslideshow_titles a").length)
            Mainslideshow_ChangeactiveCurrentItem = 0;
        Mainslideshow_Changeactive(Mainslideshow_ChangeactiveCurrentItem);
    },5000);
}

Mainslideshow_Changeactive(0);



/*------------------------------------------------------------------------------*/
var Mainslideshow2_ChangeactiveCurrentItem = 0
var Mainslideshow2_Changeactive_TimeOut = false;
function Mainslideshow2_Changeactive(itemnum) {
    $("#slideshow2Section_navigation a.active").removeClass("active");
    $($("#slideshow2Section_navigation a")[itemnum]).addClass("active");

    $("#slideshow2Section_bigView").addClass('out');
    $('#slideshow2Section_bigView').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {

        document.getElementById("slideshow2Section_bigView").src = $($("#slideshow2Section_navigation a")[itemnum]).attr("data-image");
        document.getElementById("slideshow2Section_target").href = $($("#slideshow2Section_navigation a")[itemnum]).attr("data-target");

        $("#slideshow2Section_bigView").removeClass('out').addClass('in');
        $('#slideshow2Section_bigView').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $("#slideshow2Section_bigView").removeClass('in')
        });
    });

    Mainslideshow2_Changeactive_TimmingSetup();
}

function Mainslideshow2_Changeactive_TimmingSetup() {
    clearTimeout(Mainslideshow2_Changeactive_TimeOut);
    Mainslideshow2_Changeactive_TimeOut = setTimeout(function () {
        Mainslideshow2_ChangeactiveCurrentItem += 1;
        if (Mainslideshow2_ChangeactiveCurrentItem >= $("#mainslideshow_titles a").length)
            Mainslideshow2_ChangeactiveCurrentItem = 0;
        Mainslideshow2_Changeactive(Mainslideshow_ChangeactiveCurrentItem);
    }, 5000);
}

Mainslideshow2_Changeactive(0);


/*-----------------------------------------------------------------------------------------------------------------*/
function slideterItemShowContianer_leftmove(elm) {
    pw = $(elm).width();
    sw = $(".itemsContainer", elm).width();
    sri = parseInt($(".itemsContainer", elm).css("right"));
    

    if(sw > pw && (sri + sw) > pw)
    {
        $(".itemsContainer", elm).css("right",(sri - 160))
    }
}

function slideterItemShowContianer_rightmove(elm) {
    pw = $(elm).width();
    sw = $(".itemsContainer", elm).width();
    sri = parseInt($(".itemsContainer", elm).css("right"));


    if (sw > pw && (sri) < 0) {
        $(".itemsContainer", elm).css("right", (sri + 160))
    }
}