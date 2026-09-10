/*  
 *  Functions - Function is simply a block of code which can be invoked (executed) 
 *              as many times as we want in different places in our code by us or even other people.
 *  
 *  
 */
//getValueFrmForm(formId)
function add(x, y)
{
    return x + y;
}
function divide(x, y)
{
    if (y === 0)       
        return "you can't divide by 0";
    
    
    return x / y;
}

var result = divide(10,5);

alert(result);