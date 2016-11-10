function AddComment()
{
    //获取评论内容
    var txtarea = document.getElementById("txtarea");
    var commentText = txtarea.value
    if (commentText.length == 0 || !commentText.trim())
    {
        alert("评论内容不能为空!");
        return;
    }

    var table = document.getElementById("comment");

    //添加tr
    var tr = document.createElement("tr");
    table.appendChild(tr);

    //添加td
    var td = document.createElement("td");
    tr.appendChild(td);

    //为td添加值
    td.appendChild(document.createTextNode(commentText));
}

var IsCanSubmin = false;
function validateUserName(userName)
{
    var userNameAttention = document.getElementById("userNameAttention");
    if (userName.length == 0)
    {
        userNameAttention.innerHTML = " <font size='2' color='green'>用户名不能为空</font>";
        IsCanSubmin = false;
        return;
    }
    if (userName.length <= 3)
    {
        userNameAttention.innerHTML = "<font size='2' color='red'>用户名长度必须大于3</font>";
        IsCanSubmin = false;
        return;
    }
    userNameAttention.innerHTML = "";
    IsCanSubmin = true;
}
function ValidatePwdLength(pwd)
{
    var pwdA = document.getElementById("pwdAttention");
    if (pwd.length <= 2)
    {
        pwdA.innerHTML = "<font size='2' color='red'>密码长度不能小于3</font>";
        IsCanSubmin = false;
        return;
    }
    pwdA.innerHTML = "";
    IsCanSubmin = true;
}
function validateUsePwd(rePwd)
{
    var password = document.getElementById("UserPwdId").value;
    var labAtten = document.getElementById("passwordAttention");

    if (rePwd != password)
    {
        labAtten.innerHTML = "<font size='2' color='red'>密码不一致</font>";
        IsCanSubmin = false;
        return;
    }
    labAtten.innerHTML = "";
    IsCanSubmin = true;
}
function ValidateEmail(email)
{
    var EmailAttention = document.getElementById("EmailAttention");
    var Email = email;
    var reg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    if (!Email.match(reg))
    {
        EmailAttention.innerHTML = "<font size='2' color='red'>不是一个合法的邮箱</font>";
        IsCanSubmin = false;
        return;
    }
    EmailAttention.innerHTML = "";
    IsCanSubmin = true;
}

function ValidatePhone(phone)
{
    var Phone = phone;
    var PhoneAttention = document.getElementById("PhoneAttention");
    var IsNum = (Phone.match(/\D/) == null);
    if (Phone.length != 11 || IsNum == false)
    {
        PhoneAttention.innerHTML = "<font size='2' color='red'>号码位数或格式错误</font>";
        IsCanSubmin = false;
        return;
    }
    PhoneAttention.innerHTML = "";
    IsCanSubmin = true;
}
function IsSubmit()
{
    if (IsCanSubmin == false)
    {
        alert("aaaaa");
        return;
    }
}