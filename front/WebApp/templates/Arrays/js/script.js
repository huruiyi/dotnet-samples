/*  
 * Arrays - series of values that are next to each other
 * 
 * TAB
 * ------------------------------------------------
 *   [0]  |  [1]  |  [2]  |  [3]  |  [4]  |  [5]  |
 * ------------------------------------------------
 *   
 *          associative arays       
 */

var products = [
    "XHTML", //0
    "PHP", //1
    "MySQL"  //2 
    
];


products[products.length] = "Javascript";

products.push("Grunt.JS");

        //alert(products);


var person = [];

person["name"] = "Arek";
person["surname"] = "Włodarczyk";

//person.name

alert(person["surname"]);

var programmingCourses = document.getElementById("programmingCourses").getElementsByTagName("li");

alert(programmingCourses[programmingCourses.length-1].innerHTML);