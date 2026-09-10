/*
 * for/in
 */

person = {
   name: "Arek",
   surname: "Włodarczyk",
   age: "26"
};

var programmingCourses = document.getElementById("programmingCourses").getElementsByTagName("li");

courses = [
    "Compass",
    "C++",
    "SASS",
    "Grunt.JS",
    "Javascript"
];


for (var property in programmingCourses)
{
    if (typeof(programmingCourses[property]) !== "object")
        continue;
    
    alert(programmingCourses[property].innerHTML );
}

