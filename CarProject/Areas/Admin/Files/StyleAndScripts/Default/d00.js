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