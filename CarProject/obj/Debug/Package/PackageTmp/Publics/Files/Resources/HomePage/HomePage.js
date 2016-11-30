/*----------------SliderShow---------------*/
var SlideCuNum = 0;
var SlideShowTimeOutTime = 4000;
var SlideshowIntervalObj = false;

function InitionHandChange()
{
	doc = document.getElementById("SlideShower");
	var sx =0 ;
	doc.ondragstart = function(e) { e.preventDefault(); return false; };
	doc.addEventListener("mousedown",function(e){ sx = e.clientX; });
	doc.addEventListener("mouseup",function(e)
	{
		if((e.clientX - sx) > 0)
			changeSlideForward()
		else
			changeSlideBackWard();
	});
}

function InitionTouchChange()
{
	doc = document.getElementById("SlideShower");
	var sx =0 ;
	doc.ondragstart = function(e) { e.preventDefault(); return false; };
	doc.ontouchstart = function(e){ sx = e.touches[0].radiusY; };
	doc.ontouchend = function(e)
	{
		alert(sx);
		val = e.changedTouches[0].radiusY - sx;
		document.title = val;
		if(val > 0)
			changeSlideForward()
		if(val < 0) 
			changeSlideBackWard();
	}
}



$("#SlideShower img").each(function(index, element) {
    img = document.createElement("img");
	img.src = $(element).attr("src");
	img.onclick = function(){ ChangeSlideByIndex(index); };
	
	$("#slidesPreview").append(img);
});



function changeSlide(num)
{
	$("#SlideShower .slides.show").removeClass("show");
	$($("#SlideShower .slides")[num]).addClass("show");
	
	$("#slidesPreview img.active").removeClass("active");
	$($("#slidesPreview img")[num]).addClass("active");
}
function changeSlideForward()
{
	changeSlide(SlideCuNum++);
	if(SlideCuNum >= $("#SlideShower .slides").length)
		SlideCuNum = 0;
	
	if(SlideshowIntervalObj)
		clearTimeout(SlideshowIntervalObj);
	SlideshowIntervalObj = setTimeout(function() { changeSlideForward() },SlideShowTimeOutTime);
}
function changeSlideBackWard()
{
	changeSlide(SlideCuNum--);
	if(SlideCuNum <= 0)
		SlideCuNum = $("#SlideShower .slides").length - 1;

	if(SlideshowIntervalObj)
		clearTimeout(SlideshowIntervalObj);
	SlideshowIntervalObj = setTimeout(function() { changeSlideBackWard() },SlideShowTimeOutTime);
}

function ChangeSlideByIndex(num)
{
	if(num <= 0 )
		SlideCuNum = $("#SlideShower .slides").length - 1
	if( num >= $("#SlideShower .slides").length)
		SlideCuNum = 0;
		
	changeSlide(num++);
	
	if(SlideCuNum >= $("#SlideShower .slides").length)
		SlideCuNum = 0;

	if(SlideshowIntervalObj)
		clearTimeout(SlideshowIntervalObj);
	SlideshowIntervalObj = setTimeout(function() { changeSlideBackWard() },SlideShowTimeOutTime);
}


//InitionHandChange();
//InitionTouchChange();
//changeSlide(0);
//SlideshowIntervalObj = setTimeout(function() { changeSlideForward() },SlideShowTimeOutTime);
changeSlideForward();