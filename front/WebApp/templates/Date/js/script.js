/*

    Manipulation of time using DATE object

    new Date()
    new Date(miliseconds) - you can create Date typing how many miliseconds has passed from 1st January 1970 r
    new Date(year, month, day, hours, minutes, seconds, milliseconds) - only first 3 arguments are required, 
                                                                        we start counting months from ZERO!
    new Date(dateString) where dateString is in format like:
    np. YYYY-MM-DD, YYYY-MM, YYYY
        YYYY/MM/DD, MM/DD/YYYY 
 */
Date.prototype.getMonthInString = function()
{
   var months = ["January", "February", "March", "April", "May", "June", "July",
                  "August", "September", "October", "November", "December"];
   
   return months[this.getMonth()];
};
Date.prototype.getFormattedDate = function()
{
 
};



window.onload = function()
{
  var info = document.getElementById("info");   
  
  var today = new Date();
  
  //var tomorrow = new Date(today.getTime()+ 1000 * 60 * 60 * 24);
  //var tomorrow = new Date(today.getFullYear(), today.getMonth(), today.getDate() + 1);
  var tomorrow = new Date("2015-05-12");
  info.innerHTML = tomorrow;
          //today.getMonthInString() + "/" + today.getDate() + "/" + today.getFullYear();
};






