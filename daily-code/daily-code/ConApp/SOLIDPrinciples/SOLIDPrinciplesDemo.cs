using System;

namespace ConApp.SOLIDPrinciples
{
    public class SOLIDPrinciplesDemo
    {
        public static void Demo()
        {
            //1. Single Responsibility Principle
            //Console.WriteLine("\n\nSingle Responsibility Principle Demo ");
            //SingleResponsibilityDemo.DataAccess.InsertData();
            //SingleResponsibilityDemo.Logger.WriteLog();

            ////2. Open Close Principle
            //OpenClosePrincipleDemo.OSPDemo();

            ////3. Liskov Substitution Principle
            //LiskovSubstitutionPrincipleDemo.LSPDemo();
            ////4. Interface Segregation Principle
            //InterfaceSegregationPrincipleDemo.ISPDemo();

            //5. Dependency Inversion Principle
            DependencyInversionPrincipleDemo.DIPDemo();

            Console.ReadLine();
        }
    }
}
