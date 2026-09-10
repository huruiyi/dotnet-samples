var videoCourses = [
    "PHP",
    "Mysql",
    "Javascript",
    "PDO",
    "Grunt.JS",
    "SASS",
    "Angular.JS"
];

/*
 *  for(INITILIZATION_OF_VARIABLES; CONDITION; WHAT_HAS_TO_BE_DONE_AFTER_EACH_LOOP
 * 
 */

for(var i = 0; i < videoCourses.length; i++)
{
    document.getElementById("result").innerHTML += videoCourses[i] + "<br>";
        
}