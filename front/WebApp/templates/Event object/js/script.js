/*
    altKey, ctrlKey, shiftKey - was a key alt, ctrl, shift pressed during the event?
    button - which mouse button was clicked (doesn't work during all events)
    clientX, clientY - in what place is mouse when mouse event was invoked
    keyCode - what key was pressed in number, String.fromCharCode(e.keyCode) will return the key in character
    target.tagName - the tagName of the element that invoked the function, supported in all browsers but IE 6-8 
                     use srcElement for IE. You can write var srcElement = e.target ? e.target : e.srcElement or var srcElement = e.target || e.srcElement 

 */
function doSomething(event)
{
    var e = event || window.event; 
    var srcElement = e.target || e.srcElement;
    
    var tmp = document.getElementById("tmp");
    
    tmp.innerHTML = e + " " + srcElement.tagName;
    
    var tooltip = document.getElementById("tooltip");
    /*tooltip.style.display = "block";
    
    tooltip.style.left = e.clientX + 10 + "px";
    tooltip.style.top = e.clientY + 10 + "px";*/
}

window.onload = function()
{
    var result = document.getElementById("result");
    
    result.onmousemove = function(event)
    {        
        doSomething(event);
    };
};
