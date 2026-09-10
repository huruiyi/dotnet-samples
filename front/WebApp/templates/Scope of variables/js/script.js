/*  
 *  Scope of variables within the script / functions
 *  
 *  Scope (range) means where the variable is available
 *  
 */

//var a = 5;


function test(a)
{    
    a = 3;
    alert(a);
}

test();


alert("a: " + a);