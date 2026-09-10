/*
 * arguments Object
 * 
 */

function addNumbers()
{
    var sum = 0;
    /*for (var property in arguments)
    {
        sum += arguments[property];
    }*/
    
    for (var i = 0; i < arguments.length; i++)
    {
        sum += arguments[i];
    }
    
    return sum;
}

var sum = addNumbers(3,7,6,4,9);

alert(sum);