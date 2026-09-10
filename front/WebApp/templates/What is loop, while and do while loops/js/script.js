var videoCourses = [
    "PHP",
    "Mysql",
    "Javascript",
    "PDO",
    "Grunt.JS",
    "SASS",
    "Angular.JS"
];

var result = document.getElementById("result");
/*
var i = 0;

while(i < videoCourses.length)
{   
    if (videoCourses[i] === "Mysql")
        result.innerHTML += "helllooo: ";
    
    result.innerHTML += videoCourses[i] + "<br>";
    
    i++;
}
*/

function printCourses(idOfUlList)
{
    var courses = document.getElementById(idOfUlList).getElementsByTagName("li");

    var i = 0;
   
    while(i < courses.length)
    {
        if (courses[i].innerHTML === "PHP" || courses[i].innerHTML === "Java" )
            result.innerHTML += "THIS IS MY LANGUAGE: ";
            
        result.innerHTML += courses[i].innerHTML +"<br>";
        i++;
    }    
}

printCourses("webDevelopmentCourses");
printCourses("programmingCourses");