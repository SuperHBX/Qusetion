/// <reference path="jquery-1.8.2.js" />

$.fn.extend({
    showCover: function () {
        var width = $(window).width();
        var height = $(document).height();

        var div = $("<div class='mycover'></div>");
        $("body").append(div);

        div.css({ "left": "0px", "top": "0px", "width": width, "height": height, "display": "block" });


		var $coverholder = $(this);
        var x = (width - $coverholder.width()) / 2;

        var y = ($(window).height() - $coverholder.height()) / 2 ;

        $(this).css({ "display": "block", "left": x, "top": y });

        $(window).resize(function () {
            $coverholder.closeCover();
            $coverholder.showCover();
        })
    },
    closeCover: function () {
		 $(window).unbind("resize");
        $(this).css("display", "none");
        var div = $(".mycover");
        if (div.length > 0) {
            div.remove();
        }
    },
    showDivCover: function () {
        //if ($("#loadingField").length == 0) {
        //    $(this).append("<div id='loadingField'><center>加载中……请稍候……<br/><img src='/Content/loading.gif' /></center></div>");
        //}
        var width = $(this).width();
        var height = $(this).height();

        var div = $("<div id='" + ($(this).attr("id")+"-cover") + "' class='mycover'><img src='/Content/loading.gif' style='margin-left:" + (width / 2 - 20) + "px;margin-top:" + (height / 2 - 20) + "px' /></div>");
        $(this).append(div);

        div.css({
            //"left": $(this).offset().left,
            //"top": $(this).offset().top,
            "width": width, "height": height, "display": "block"
        });
        div.offset($(this).offset());

        //var $coverholder = $("#loadingField");
        //var x = ($(window).width() - $coverholder.width()) / 2;

        //var y = ($(window).height() - $coverholder.height()) / 2;

        //$coverholder.css({ "display": "block", "left": x, "top": y });

        $(window).resize(function () {
            $(this).closeDivCover();
            $(this).showDivCover();
        })
    },
    closeDivCover: function () {
        $(window).unbind("resize");
        var div = $("#" + ($(this).attr("id") + "-cover"));
        if (div.length > 0) {
            div.remove();
        }
    }
})

$(function () {


})
function ShowMessage(msg) {
    //alert(ShowMessage.arguments.length);
    if (ShowMessage.arguments.length == 1) {
        $("body").append("<div id='messageField'><center>" + ShowMessage.arguments[0] + "<br/><img src='/image/loading.gif' /></center></div>");
    }
    else {
        $("body").append("<div id='messageField'><center>提交中……请稍候……<br/><img src='/image/loading.gif' /></center></div>");
    }
    $("#messageField").showCover();
}

function CloseMessage() {
    $("#messageField").closeCover();
}

function ShowLoading() {
    if ($("#loadingField").length == 0) {
        $("body").append("<div id='loadingField'><center>加载中……请稍候……<br/><img src='/image/loading.gif' /></center></div>");
    }
    $("#loadingField").showCover();
}

function CloseLoading() {
    $("#loadingField").closeCover();
}


//function ClickHandler() {
//    event
//}

//$(function () {
//    $("body").append("<div id='dialog' title='提示'></div>");
//    $("body").append("<div id='confirm' title='请求确认'></div>");

//    $("#dialog").dialog({
//        autoOpen: false,
//        show: "fold",
//        hide: "fold",
//        modal: true,
//        buttons: {
//            确定: function () {
//                //ClickHandler();
//                $(this).dialog("close");
//            }
//        }
//    });

//});


function ShowDialog(msg) {
    $("#dialog").html(msg);    
    $("#dialog").dialog("open");
    waitForClick(document.getElementById("CeShi"));
}

function ShowConfirm(msg) {
    var result = false;
    $("#confirm").dialog({
        autoOpen: false,
        show: "fold",
        hide: "fold",
        modal: true,
        buttons: {
            取消: function () {
                $(this).dialog("close");
            },
            确定: function () {
                result = true;
                $(this).dialog("close");
            }
        }

    });
    $("#confirm").html(msg);
    
    $("#confirm").dialog("open");
    return result;
}


//window.alert = function (msg) {
//    ShowDialog(msg);
//}
//window.confirm = function (msg) {
//    ShowConfirm(msg);
//}



