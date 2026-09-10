/*
    alert
    confirm
    prompt
   
    \n
              
 */

window.onload = function()
{
    var answer = confirm("Are you sure about deleting your account?");
    
    if (answer)
    {
        var result = prompt("What is your name?");
        
        alert("Goodbye " + result + " :-(");
    }    

};







