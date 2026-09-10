var videoCourses = [
    "PHP",
    "Mysql",
    "Javascript",
    "PDO",
    "Grunt.JS",
    "SASS"
];
var numbers = [
  4, -54, 24, 12, 12, 55  
];

/*
 * join - is used to join elements by sent argument
 * concat - concatanate - connecting two arrays
 * length - returning the length of an array
 * pop - popping (removing) the last element
 * push - add an element to the end of array and return the new size of an array
 * shift - removing the first element 
 * unshift - moving all elements in the array by 1 and adding a new element at the beginning
 * 
 * sort is sorting alphabetically an array |||||||| function(a, b){return b - a;} - this is used to sort an array descending way
 * reverse - is reversing the order of an array
 * slice - it is slicing elements from <1,3]  < - without the 1, ] - with 3
 * splice - arg1 - from which place we want to start removing elements, arg2 - how many elements i want to remove, [optional arguments] - elements that you want to add after the position in arg1
 */

document.getElementById("result").innerHTML = videoCourses.splice(1,3, "somethingNew", 5125, "lalala", "hehehe");


document.getElementById("result").innerHTML += "<br>--------------------------<br>";

document.getElementById("result").innerHTML += videoCourses;
