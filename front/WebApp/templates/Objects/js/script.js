/*  
 * Objects - containers for storing variables (properties) and functions (called methods) 
 *          thematically related to each other for easier re-using
 *           
 */

var div = document.getElementById("test");

div.innerHTML = "this is new text";

var person = {
    name: "Arek", 
    surname: "Wlodarczyk",
    age: 15,
    isAdult: function()
    {
        if (this.age < 18)
            return false;
        
        return true;
    },
    toString: function()
    {
        return this.name + " " + this.surname;
    }
};
/*
var person = new Object({
    name: "Arek", 
    surname: "Wlodarczyk",
    age: 15,
    isAdult: function()
    {
        if (this.age < 18)
            return false;
        
        return true;
    },
    toString: function()
    {
        return this.name + " " + this.surname;
    }
});
*/

div.innerHTML = person.isAdult();