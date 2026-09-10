/*
   Handling a sequence of characters using String methods

   charAt(index) - what character is at index
   substring/slice (from, to) - cut
   substr(from, howMany) - cut
   split - splitting string into an array
   join - joining (connecting) an array into a string
   replace(whatToReplace, forWhat) - replacing content of string for
   trim - removing spaces before and after the string
   lastIndexOf("value") - the last place where the "value" is in string
   indexOf - the first place where the "value" is in string
   search - the same as above but can use regexp
   []
 */

window.onload = function()
{
   var info = document.getElementById("info");
   
   var tmp = "arkadiusz";
   
   var link = "http://video-courses-online.com/video-course-cpp.html"; //window.location
   
   
   var tmpString = " XHTML PHP COMPASS SASS GRUNT.JS  ";
   
   tmpString = tmpString.replace('XHTML', 'HTML 5');
   
   var tmpArray = tmpString.split(" ");
   tmpArray[2] = "CSS";
   
   var newString = tmpArray.join(", "); 
   
   
   
   info.innerHTML = tmp.charAt(0).toUpperCase() + tmp.substr(1);
           
            
            //link.substring(link.lastIndexOf("/") + 1);
           
            
            //
};






