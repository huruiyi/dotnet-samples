/*    Cookies - cookies are containers that can store
                key=value1;key2=value2;

              values like that are available to us even if the user leave our website
              when the user visits your website again this value is still gonna be there
              because of it we can identify the person visiting us

              path=/
              expires= - when the cookie expires (default when you close the session) (toUTCString() format)
              max-age= - how old can the cookie be in seconds (not supported in ie6-8)

              localstorage - for local              
*/

window.onload = function()
{
  var info = document.getElementById("info");   
  var createCookie = document.getElementById("createCookie");   
  var removeCookie = document.getElementById("removeCookie");   
  
  createCookie.onclick = function()
  {
    var expirationDateOfCookie = new Date();
    expirationDateOfCookie.setTime(expirationDateOfCookie.getTime() + 1000*60*60);
    document.cookie = "name=Arkadiusz;max-age="+60*60*24+";path=/";
    document.cookie = "surname=Wlodarczyk;path=/";
  };
  removeCookie.onclick = function()
  {
    var expirationDateOfCookie = new Date();
  
    document.cookie = "surname=;expires="+expirationDateOfCookie.toUTCString()+";path=/";
  };  


};






