/*
 * break and continue;
 * 
 */
/*
for (var i = 0; i < 5; i++)
{
    if (i === 2)
        continue; //continue is working like a break but after breaking once the loop it still continues...
    
    alert(i);
}
*/

var programmingCourses = document.getElementById("programmingCourses").getElementsByTagName("li");

for (var i = 0; i < programmingCourses.length; i++)
{
    if (i % 2 !== 0)
        programmingCourses[i].innerHTML = "even " + programmingCourses[i].innerHTML;
    else
        continue;
    
    /*
     * 
     * 
     * 
     * LOTS OF INSTRUCTIONS
     */
    
    alert(i);
}