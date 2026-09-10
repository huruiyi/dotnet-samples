/*
        Propagation of events (multiplication) - bubbling
        var e =  e || window.event;
        if (e.stopPropagation)
            e.stopPropagation(); 
        else
            e.cancelBubble = true; 

 */
function doSomething(event, eventObj)
{
    var e =  event || window.event;
    var srcElement = e.target || e.srcElement;
    
    var tmp = document.getElementById("tmp");
    
    tmp.innerHTML = "source of event: " + srcElement.tagName + "<br>event assigned to tag: "+ eventObj.tagName;
  
    
}

window.onload = function()
{
    var result = document.getElementById("result");
    var bolded = document.getElementById("bolded");
    var button = document.getElementById("button");
    
    result.onclick = function(event)
    {    
        alert("result");
        doSomething(event, this);
    };
    
    bolded.onclick = function(event)
    {    
        alert("bolded");

    };
    
    button.onclick = function(event)
    {    
        alert("button");
        var e =  e || window.event;
        if (e.stopPropagation)
            e.stopPropagation(); 
        else
            e.cancelBubble = true; 
    };    


};




