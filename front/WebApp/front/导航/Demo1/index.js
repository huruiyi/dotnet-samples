$(function () {
    // 菜单绑定事件
    initMenuListener();
    // 下拉菜单绑定事件
    initSubMenuHover();
    // 下拉菜单颜色改变
    initSubMenuLiHover();
});

/**
 * 头部菜单绑定滑过事件
 */
function initMenuListener() {
    $(".menuli").hover(function () {
        var hideDivId = $(this).attr("id") + "_div";
        // 得到菜单的位置
        var left = $(this).offset().left;
        var top = $(this).offset().top;
        var height = $(this).outerHeight();//outerHeight是获取高度，包括内边距，height是也是获取高度，不过只包括文本高度
        $("#" + hideDivId).show();
        $("#" + hideDivId).css("left", left);
        $("#" + hideDivId).css("top", top + height);
    }, function () {
        // 将原来的菜单隐藏
        $(".display").hide();
    });
}

/**
 * 下拉菜单绑定事件
 */
function initSubMenuHover() {
    $(".display").hover(function () {
        $(this).show();
    }, function () {
        $(this).hide();
    });
}

/**
 *  下拉菜单改变颜色
 */
function initSubMenuLiHover() {
    $(".redli").hover(function () {
        $(this).addClass("redcolor");
    }, function () {
        $(this).removeClass("redcolor");
    });
}