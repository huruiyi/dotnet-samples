namespace ConApp.ReflectionDemo.Model
{
    public class MyTester4
    {
        public string Name { get; set; }

        //[ValidateAge(MaxAge = 40)]
        [ValidateAgeComplex(50, "")]
        public int Age { get; set; }
    }
}