var FadeObjects = Array();

function TogleHide(elm,nrmDisp)
{
	if(nrmDisp == '')
	{	nrmDisp = 'inherit'; }
		
	if(elm.offsetParent === null)
		elm.style.display = nrmDisp;
	else
		elm.style.display = "none";
		
	if(FadeObjects.indexOf(elm) < 0)
	{
		FadeObjects[FadeObjects.length] = elm;
	}
}

function HideTogels()
{	
	for(it in FadeObjects)
		FadeObjects[it].style.display = 'none';
};



/*-------------------------------------------Wizards---------------------------------*/
$(".wizardNav a").click(function (e) {
    e.preventDefault();
    elid = $(this).attr('href').substr(1);
    wizardGoToPage(document.getElementById(elid));
});
var wizardActivePageContainerElm = null;

function wizardNextPage(el) {
    wp = wizardFindAncestor(el);
    if ($(wp).next('.wizardPage').length > 0) {
        wizardGoToPage($(wp).next());



        if ($(".wizardNav a[href='#" + wp.id + "']").length > 0) {
            wizardChangeActiveLink($(".wizardNav a[href='#" + wp.id + "']").first(), wp.id);
        }
    }
}
function wizardPreviousPage(el) {
    wp = wizardFindAncestor(el);
    if ($(wp).prev('.wizardPage').length > 0) {
        wizardGoToPage($(wp).prev());


        if ($(".wizardNav a[href='#" + wp.id + "']").length > 0) {
            wizardChangeActiveLink($(".wizardNav a[href='#" + wp.id + "']").first(), wp.id);
        }
    }
}
function wizardActiveLink(linel, elid) {

}
function wizardGoToPage(el) {
    $(".wizardPage").hide();
    $(el).show();
    if (wizardActivePageContainerElm != null)
        wizardActivePageContainerElm.value = $(el).attr("id");

    $(".wizardNav a.active").removeClass('active');
    $(".wizardNav a[href='#" + $(el).attr('id') + "']").addClass('active');
}
function wizardAssignPostContainer(el)
{
    wizardActivePageContainerElm = el
    if (el.value != '')
        wizardGoToPage(document.getElementById(el.value));
}

function wizardFindAncestor(el) {
    while (el.tagName.toLowerCase() != 'body' && el != null && el != 'undefined') {
        if (el.classList.contains('wizardPage')) {
            return el;
        }
        el = el.parentNode;
    }
}


wizardGoToPage($(".wizardPage").first());
/*-------------------------------------------EndWizards---------------------------------*/

/*---------------------------------------Input Rating Section---------------------*/

$(".input.rating").each(function(index, element) {
    $(".ratingSectionSlider",element).css(
	    "width",
	    (parseFloat($("input",element).attr('value')) * 10) + "%"
	    );
});
$(".input.rating  .ratingSection[data-value]").each(function (index, element) {
    $(".ratingSectionSlider",element).css(
	    "width",
	    (parseFloat($(element).attr('data-value')) * 10) + "%"
	    );
});

function ratint_Onclick(e)
{
	tw = e.target.clientWidth;
	ox = e.offsetX + 3;
	ro = (ox * 100) / tw;
	if(ro > 100)
		ro = 100;
	$("input",e.target.offsetParent).attr("value",parseFloat(ro / 10).toFixed(2));
	$(".ratingSectionSlider",e.target).css("width",ro + "%");
}

function ratint_OnMouseMove(e)
{
	tw = e.target.clientWidth;
	ox = e.offsetX + 3;
	ro = (ox * 100) / tw;
	if(ro > 100)
		ro = 100;
	$(".ratingSectionFakeSlider",e.target).css("width",ro + "%");
}

function Input_ChangeRating(e)
{	
	var v = e.target.value * 10;
	if(v > 100)
		v = 100;
	$(".ratingSectionSlider",e.target.offsetParent).css("width", v + "%");
}

function floatNumber(e)
{
	var arr = ["Backspace","Delete","Home","End",".","Tab","Enter", "F5"];
	return ((e.key >= 0 && e.key <= 9) || arr.indexOf(e.key) >= 0  )
		
}

/*---------------------------------------Input Rating Section---------------------*/



/*---------------------------------TreeView----------------------------------------------*/
$(".treeview a").addClass("gia-left");
$(".treeview a").click(function (e) {
    if ($(this).hasClass('active')) {
        $(this).removeClass('active');

        if ($(this).hasClass('gia-down')) 
            $(this).removeClass('gia-down');
        $(this).addClass("gia-left");
    }
    else {
        $(this).addClass('active');

        if ($(this).hasClass('gia-left'))
            $(this).removeClass('gia-left');
        $(this).addClass("gia-down");
    }
});