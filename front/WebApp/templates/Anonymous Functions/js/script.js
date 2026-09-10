/*  
 * Function as an expression (as the value of the variable)
 * Anonymous functions
 *  
 */

/*
var x = function(arg1)
{
    alert("sample " + arg1);
};

x(5);

*/
/*
function test(f, arg1)
{    
    f(4 + arg1);
}

test(
    function(x){ 
            alert("sample " + x);
    },
    20
);
*/

var hi = function(type)
{
    if (type === "boss")
        return function(name){
          alert("Hi boss, " + name);  
        };
    else
        return function(name){
           alert("Hi, " + name);  
        };
};

var returnedFunction = hi("boss");

returnedFunction("Arek");