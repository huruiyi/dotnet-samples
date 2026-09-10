/*
    events - things that happens on your website
 
    this
 */

function changeColor()
{
   this.className = "changeColor";
}

function changeColorOut()
{
   this.removeAttribute("class");
}

var result = document.getElementById("result");

result.onmouseover = changeColor;

result.onmouseout = changeColorOut;

