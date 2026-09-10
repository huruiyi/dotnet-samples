/*
 *
 *  Switch (toggle)
 *  
 *  
 */
var dayOfWeek = 1;

switch(dayOfWeek)
{
    case 1:
        alert("OH NO ITS MONDAY");
    case 2:
    case 3:
    case 4:        
    case 5:        
        alert("Working day");
        break;
    case 6:
    case 7:    
        alert("it's weekend");
        break;    
    default:
        alert("This is not a day of week");     
}