/*
   setTimeout(javascript function, milliseconds); - function will be run once
   setInterval(javascript function, milliseconds); - function will be run many times in intervals (pierod between two events)

   clearTimeout - it will stop the function that was gonna be executed by setTimeout
   clearInterval - its gonna stop interval
 */
var timeOutRefId;
function stopwatchStart(stopwachHandler, startingValue)
{
    stopwachHandler.innerHTML = --startingValue;
    if (startingValue <= 0)
        return;
    
    timeOutRefId = setTimeout(function()
    {
        stopwatchStart(stopwachHandler, startingValue);
    }, 1000);
}
window.onload = function()
{
   
   var buttonStart = document.getElementById("buttonStart");
   var buttonStop = document.getElementById("buttonStop");
   
   var stopwachHandler = document.getElementById("stopwachHandler");
   var intervalRefId;
   /*
   buttonStart.onclick = function()
   {
       if (intervalRefId)
           clearInterval(intervalRefId);
       var startingValue = document.getElementById("startingValue").value;
       
       stopwachHandler.innerHTML = startingValue;
       
       intervalRefId = setInterval(function(){
           if (startingValue <= 0)
           {
               clearInterval(intervalRefId);
               return;
           }
           
           stopwachHandler.innerHTML = --startingValue;
       },1000);
   };
   buttonStop.onclick = function()
   {
       clearInterval(intervalRefId);
   };
   */
   buttonStart.onclick = function()
   {
       var startingValue = document.getElementById("startingValue").value;
       if (timeOutRefId)
           clearTimeout(timeOutRefId);
       
       stopwachHandler.innerHTML = startingValue;   
       
       setTimeout(function(){
           stopwatchStart(stopwachHandler, startingValue);
       }, 1000);
   };
    
};






