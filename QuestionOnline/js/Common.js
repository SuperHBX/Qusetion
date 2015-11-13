﻿
function SearchQuestion(keyword,page) {
    window.location.href = "/Question/SearchKeyword?Keyword=" + keyword + "&page=" + page;
}
//tijiao
//时间戳转化成时间
function dateparse(jsonDate, istime) {
    try {
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        var seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
        var milliseconds = date.getMilliseconds();
        if (istime) {
            return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds
        } else {
            return date.getFullYear() + "-" + month + "-" + day;//+ " " + hours + ":" + minutes + ":" + seconds + "." + milliseconds;
        }
    } catch (ex) {
        return "";
    }
}

//超过13长度的字符串转换
function maxtext25(str) {

    //alert(str);
    str = str.replace(/<img(.*)src=\"([^\"]+)\"[^>]+>/gi, '[图片]').replace(/<p>/gi, '').replace(/<\/p>/gi, '').replace(/\<a\s.+\<\/a\>/gi, '[文件]');
    str = str.replace(/<[^>]+>/g, "");
    //str = str.replace(/<[^>]+>/g, "");
        //replace(/<\s?img[^>]*>/gi, '3').replace(/<p>/gi, '1').replace(/<\/p>/gi, '2').replace(/\<a\s.+\<\/a\>/gi, '5');
    if (str.length > 25) {
        str = str.substring(1, 25);
        str += "...";
        return str;
    }
    else {
  return str;
    }
}
function maxtext13(str) {

    if (str == null)
        return;
    if (str.length > 13) {
        str = str.substring(1, 13);
        str += "...";
        return str;
    }
    else {
        return str;
    }
}
