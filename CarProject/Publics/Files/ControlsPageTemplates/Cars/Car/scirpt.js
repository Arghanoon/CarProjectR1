function RearrengCarInformation() {
    arr = [];

    $('.carinfo').each(function (index, element) {
        arr[$(element).attr('data-index')] = element

    });

    alert($(arr[1]).attr('data-index'));
}


$("#CarDetailsInformation > div > div > h3").click(function (e) {
    $(e.target.offsetParent).toggleClass('hide');
});


function LikeCurrentCar(car) {
    $.post('/Cars/Car_MakePopular', { "id": car }, function (res) {
        if (res != -1) {
            document.getElementById('likecountersection').innerHTML = res;
        }
    });
}


function CommentMessageReply(mid,uname) {
    window.scroll(0, document.getElementById('usersCommentsSection').offsetTop);
    document.getElementById('responsecommentid').value = mid;
    document.getElementById('usernameCommentReply').value = uname;

    if (!$("#replayComment").hasClass('show')) {
        $('#replayComment').addClass('show');
    }
}