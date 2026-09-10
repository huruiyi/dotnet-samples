/*  
 * Prototype - prelimanary model
 * 
 */

var div = document.getElementById("test");

div.innerHTML = "this is new text";

function person(name, surname, age)
{
    this.name = name;
    this.surname = surname;
    this.age = age;
    this.isAdult = function()
    {
        if (this.age < 18)
            return false;
        
        return true;
    };
    this.toString = function()
    {      
        return this.name + " " + this.surname + " AGE: " + this.age;
    };
}

var x = new person("Arek", "Wlodarczyk", "39");
var y = new person("Viola", "Wlodarczyk", "51");
var z = new person("Agness", "Wlodarczyk", "22");

//x.somethingNew = 5;

person.prototype.somethingNew = 1512;

div.innerHTML = x.somethingNew + "<br>" + y.somethingNew + "<br>" + z.somethingNew; //["age"]