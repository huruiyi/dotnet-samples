/*
    PREVENT - STOP
    var e = e || window.event;
    if (e.preventDefault)
        e.preventDefault();
    else
        e.returnValue = false;
 */

window.onload = function()
{
    var email = document.getElementById("email");
    var submitFormButton = document.querySelector("#newsletter input[type='submit']");
    
    
    submitFormButton.onclick = function(e)
    {
        var e = e || window.event;
        if (e.preventDefault)
            e.preventDefault();
        else
            e.returnValue = false;

        var newsletter = document.getElementById("newsletter");
        var tmp = document.getElementById("tmp");
        if (email.value === "fasdfasf@com")      
            newsletter.submit();
        else
            tmp.innerHTML = "THE EMAIL IS WRONG!!!";
    };
    submitFormButton.oncontextmenu = function(e)
    {
         var e = e || window.event;
        if (e.preventDefault)
            e.preventDefault();
        else
            e.returnValue = false;       
    };
 
};




