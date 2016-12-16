window.onload = function () {
    //    document.write("你好呀");
    //    document.writeln("嗯,你也好");
    //    document.write("换行了<br>");
    //    document.write("<font color:red>tian</font>");
    intervalrId = setInterval(reg, 1000);
}
var intervalrId;
var time = 10
function reg() {
    time--;
    var btn = document.getElementById("btn");
    if (time == 0) {
        btn.value = "注册";

        // btn.removeAttribute("disabled");
        btn.disabled = "";
        clearInterval(intervalrId);
    }
    else {
        btn.value = "请阅读此协议(" + time + "秒)";
    }
}
function checkAll() {
    var ckall = document.getElementById("checkall");

    var ck = document.getElementsByTagName("input");
    for (var i = 0; i < ck.length; i++) {
        if (ck[i].type == "checkbox" && ck[i].id != "checkall") {
            if (ckall.checked) {
                ck[i].checked = true;
            }
            else {
                ck[i].checked = false;
            }
        }
    }
}

function omover(btn) {
    btn.value = "呜呜..";
}
function omout(btn) {
    btn.value = "哈哈~"
}

function Calc() {
    var sub1 = document.getElementById("sub1");
    sub1value = sub1.value;
    if (sub1 == "") {
        alert("值不能为空");
    }
    if (isNaN(sub1value)) {
        alert("sub1value为空");
    }
    var sub1 = parseInt(sub1.value);
    var sub2 = document.getElementById("sub2");
    var sub2 = parseInt(sub2.value);

    var Sum = sub1 + sub2;
    var sum = document.getElementById("sum");
    sum.value = Sum;
}

function AddText() {
    var text = document.createElement("input");
    text.type = "text";
    text.name = "uid";
    text.value = "动态添加的文本框";

    var pc = document.getElementById("pc");
    pc.appendChild(text);
}
function AddLink() {
    var link = document.createElement("a");
    link.href = "http://www.baidu.com";
    link.appendChild(document.createTextNode("百度"));

    var pc = document.getElementById("pc");
    pc.appendChild(link);
}

var proInfo = { "江苏": ["江苏1", "江苏2", "江苏3"], "安徽": ["安徽1", "安徽2", "安徽3"], "河南": ["河南1", "河南2", "河南3"] };

function proChange(pro) {
    var cityNode = document.getElementById("city");
    while (cityNode.childNodes.length > 0) {
        cityNode.removeChild(cityNode.childNodes[0]);
    }

    var citys = proInfo[pro];
    for (var i = 0; i < citys.length; i++) {
        var cityName = citys[i];
        var opt = document.createElement("option");
        opt.value = cityName;
        opt.appendChild(document.createTextNode(cityName));
        cityNode.appendChild(opt);
    }
}

function addWebSite() {
    var siteName = document.getElementById("siteName").value;
    var siteUrl = document.getElementById("siteUrl").value;
    var table = document.getElementById("tblSites");

    var tr = document.createElement("tr");

    var td = document.createElement("td");
    td.appendChild(document.createTextNode(siteName));
    tr.appendChild(td);

    var td = document.createElement("td");
    var link = document.createElement("a");
    link.href = siteUrl;
    link.appendChild(document.createTextNode(siteUrl));
    td.appendChild(link);
    tr.appendChild(td);

    table.appendChild(tr);
}

function onPClick(e) {
    alert("P的事件被执行了.................");
    stopBubble(e);
}

function onDivClick() {
    alert("Div的事件被执行..........");
}

// 停止冒泡
function stopBubble(e) {
    // 对应着非IE浏览器
    if (e && e.stopPropagation) {
        e.stopPropagation();
    }
    else {
        //IE浏览器
        window.event.cancelBubble = true;
    }
}

function LoseSeachFocus(txt) {
    txt.style.color = "gray";
    if (txt.value == "") {
        txt.value = "请输入关键字";
    }
    else {
        txt.style.color = "black";
    }
}

function GetSearchFoucus(txt) {
    if (txt.value == "请输入关键字") {
        txt.value = "";
        txt.style.color = "black";
    }
}