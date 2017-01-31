function addJustBottomWithFooter()
{
    $('#Content').css('margin-bottom', (parseInt($('#footerStatusBar').height()) + 10) + "px")
}
addJustBottomWithFooter();
window.addEventListener("resize", addJustBottomWithFooter);


