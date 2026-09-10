/*
    multiplication table
    
 */
var multiplicationTable = "<table>";

for (var i = 1; i <= 15; i++) // i = 2
{
    multiplicationTable += "<tr>";
    
    for (var j = 1; j <= 10; j++) //j =11
        multiplicationTable += "<td>" + i * j + "</td>";
    
    multiplicationTable += "</tr>";
}

multiplicationTable += "</table>";

var result = document.getElementById("result");

result.innerHTML = multiplicationTable;