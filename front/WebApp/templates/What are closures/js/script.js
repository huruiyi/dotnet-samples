function product(name, price)
{
    var name = name;
    var price = price;
    var id = 0;
    
    function getInfo() //closure
    {
        return name + " " + price + " " + (++id);
    }
    
    return getInfo;
}


window.onload = function()
{
        
    var a = product("video course", 49); 
    
    a();
    a();
    a();
 //   alert(a());

    var b = product("ball", 20);

    //alert(b());
    var clickMe = document.getElementById("clickMe");
    
      
    clickMe.onclick = (function(e)
    {
        var counter = 0;
        
        function closure()
        {
            counter++;
            if (counter === 2)
            {
                counter = 0;
                alert("something");
            }
        }
        return closure;
    })();
    
    
};
