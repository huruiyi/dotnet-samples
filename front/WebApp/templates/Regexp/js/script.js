/*
    REGEXP
    regular expressions - formulas

    stringToSearch.search(formula) - searches and return the index
    stringToSearch.match(formula) - searches and returns an array
    regExpVar.exec(stringToSearch) - same as above but it returns only one result after each execution
    stringToSearch.replace(formula, "forWhat"); - replacing things in formula by "forWhat"
    formula.test(stringToSearch); - testing if something from formula exists in stringToSearch

    g - global - searching through full string
    i - insensitive - case Insensitive 
 */

window.onload = function()
{
   var info = document.getElementById("info");   

   var indexes = "A-565 B-12 K-51 A-53 A#58 S#45 A.51 a-98 a-4124 Aj244";
   
   var result = indexes.match(/A\.[0-9]+/gi);
   
   var telephoneNumber = "22 555 555 554";
   
   result = telephoneNumber.match(/^\d{2}\s[0-9]{3}\s[0-9]{3}\s[0-9]{3}$/);
   
   var testResult = (/^\d{2}\s[0-9]{3}\s[0-9]{3}\s[0-9]{3}$/).test(telephoneNumber);
   
   info.innerHTML = testResult;
   
   
};






