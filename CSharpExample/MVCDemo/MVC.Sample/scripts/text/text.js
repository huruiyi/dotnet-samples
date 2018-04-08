$(function () {
    $('input[type=text]').bind("keypress", function (e) { //可以根据需要将 bind 改成 live
        var input = $(e.target);
        var value = e.target.value;
        var cl = input.attr("class");  //为了演示简单，假定文本框只有一个class
        if (cl == 'string') return true;
        if (cl == 'uint' || cl == 'date' || cl == 'rmb') {
            //允许数字
            if (e.keyCode >= 48 && e.keyCode <= 57) return true;
            //允许一个小数点
            if (cl == 'rmb')
                if (e.keyCode == 46 && value.match(/[.]/) == null) return true;
            if (cl == 'date')
                if (e.keyCode == 45) return true;
            return false;
        }
        return true;
    });
});