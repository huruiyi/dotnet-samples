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
function createCookie(name, value, days) {
    var expirationDate = "";
    if (days) {
        var expirationDateOfCookie = new Date();
        expirationDateOfCookie.setDate(expirationDateOfCookie.getDate() + days);
        expirationDate = ";expires=" + expirationDateOfCookie.toUTCString();
    }
    document.cookie = name + "=" + encodeURIComponent(value) + expirationDate + ";path=/";
}

function removeCookie(name) {
    var expirationDateOfCookie = new Date();
    document.cookie = name + "=;expires=" + expirationDateOfCookie.toUTCString() + ";path=/";
}

function getCookieByKeyName(name) {
    var cookies = document.cookie.split("; ");

    for (var i = 0; i < cookies.length; i++) {
        var splittedCookie = cookies[i].split("=");
        var cookieKeyName = splittedCookie[0];

        if (name === cookieKeyName) {
            var cookieValue = splittedCookie[1];
            return decodeURIComponent(cookieValue);
        }
    }
}

window.onload = function () {
    var info = document.getElementById("info");
    var createCookieButton = document.getElementById("createCookie");
    var removeCookieButton = document.getElementById("removeCookie");

    info.innerHTML = getCookieByKeyName("surname");
    createCookieButton.onclick = function () {

        createCookie("age", 26);
        createCookie("surname", "Wlodarczyk;sdgsadgsdg", 20);
        createCookie("name", "Arkadiusz", 20);
    };
    removeCookieButton.onclick = function () {
        removeCookie("age");
    };


};







