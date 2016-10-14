/*------------------------------------SliderType1--------------------------------------------*/
	$(".SliderType1 .sliderTitles > *").append("<section class='tile'></section>")
	$(".SliderType1 .sliderTitles .tile").each(function(index, element) {
        h = $(element).height();
		$(element).css({"border-right": h+"px solid #eb4e14"});
		$(element).css({"border-top": (h/2)+"px solid transparent"});
		$(element).css({"border-bottom": (h/2)+"px solid transparent"});
    });
	
	function SliderType1ChangeSlide_byindex(ind)
	{
		$(".SliderType1 .sliderTitles > *.active").removeClass("active");
		$($(".SliderType1 .sliderTitles > *")[ind]).addClass("active");
		
		ds = $($(".SliderType1 .sliderTitles > *")[ind]).attr("data-slide");
		
		$(".SliderType1 .sliderItems .slideItem.active").removeClass('active');
		$(".SliderType1 .sliderItems .slideItem[data-slide="+ ds +"]").addClass("active");
	}
	function SliderType1ChangeSlide_byelement(el)
	{
		$(".SliderType1 .sliderTitles > *.active").removeClass("active");
		$(el).addClass("active");
		
		ds = $(el).attr("data-slide");
		
		$(".SliderType1 .sliderItems .slideItem.active").removeClass('active');
		$(".SliderType1 .sliderItems .slideItem[data-slide="+ ds +"]").addClass("active");
	}
/*---------------------------------ENDSliderType1--------------------------------------------*/
	
/*------------------------------------SliderType2--------------------------------------------*/
	function SliderType2ChangeSlide_byindex(ind)
	{
		$(".SliderType2 .sliderTitles > *.active").removeClass("active");
		$($(".SliderType2 .sliderTitles > *")[ind]).addClass("active");
		
		ds = $($(".SliderType2 .sliderTitles > *")[ind]).attr("data-slide");
		
		$(".SliderType2 .sliderItems .slideItem.active").removeClass('active');
		$(".SliderType2 .sliderItems .slideItem[data-slide="+ ds +"]").addClass("active");
	}
	function SliderType2ChangeSlide_byelement(el)
	{
		$(".SliderType2 .sliderTitles > *.active").removeClass("active");
		$(el).addClass("active");
		
		ds = $(el).attr("data-slide");
		
		$(".SliderType2 .sliderItems .slideItem.active").removeClass('active');
		$(".SliderType2 .sliderItems .slideItem[data-slide="+ ds +"]").addClass("active");
	}
/*---------------------------------ENDSliderType2--------------------------------------------*/