/*
    onmouseover - when the cursor is over (enters) the element
    onmouseout - when the cursor is leaving the element
    onmousemove - when the cursors is moving on element
    onclick = when the element is clicked
    ondblclick = when the element is fast double clicked
    
    onclick is a connection of this events:

    onmousedown - when we have button of mouse down
    onmouseup - when we release the mouse button

    when you release the button onclick event happens
 */

function movingImage(e, objToMove)
{              
    objToMove.style.left = e.clientX - objToMove.width / 2 + "px";
    objToMove.style.top = e.clientY - objToMove.height / 2 + "px";        
}
window.onload = function()
{
    var sample = document.getElementById("sample");
  
    sample.onmousedown = function()
    {
        var self = this;
        document.onmousemove = function(e)
        {
             movingImage(e, self);  
        };
    };
    
    sample.onmouseup = function()
    {
        document.onmousemove = null;
    };
    
    sample.ondragstart = function(e)
    {
        e.preventDefault();  
    };
};





