/*
    events - things that happens on your website
    
 */
var result = document.getElementById("result");

function sample(arg)
{
    alert(arg + "dsfasdf");
}
result.onmouseover = function()
{
    sample("asfdasf");
};