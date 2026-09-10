/*
    .options - an array with possible options to choose
    .length - how many elements are inside combo box
    .text - text of option

    .value; - value of value attribute or text value if there is no value attribute

    .selectedIndex - index of chosen element
    .add - a function adding new option for example var newOption = document.createElement("option");  newOption.text = "Compass";
    .remove(index) - a function removing option on position (index)

    videoCourses.options[videoCourses.selectedIndex].value - what was chosen by the user
 */

window.onload = function()
{
   var myForm = document.getElementById("myForm");
   
   var info = document.getElementById("info");
   
   var videoCourses = myForm.videoCourses;
   
   var newOption = document.createElement("option");
   newOption.text = "COMPASS";
   videoCourses.add(newOption, 0);
   videoCourses.selectedIndex = 0;
   
   videoCourses.onchange = function()
   {
      
       info.innerHTML = this.value;
   };
   
   
 
    
    
 
};






