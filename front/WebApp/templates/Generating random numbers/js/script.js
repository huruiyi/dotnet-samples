/*
    Math.round() - rounds the number to the nerest integer
    Math.ceil() - ceiling is up - so you round always up
    Math.floor() - floor is down - so you round always down
    toFixed(howManyNumbersAfterTheDot);


    Math.random(); - returns random value from 0 to 1 

    Random quotes
    
 */




window.onload = function()
{

    var info = document.getElementById("info");

    var randomNumber = Math.floor(Math.random() * 4) + 3;
    
    info.innerHTML = randomNumber;
   
    
};









