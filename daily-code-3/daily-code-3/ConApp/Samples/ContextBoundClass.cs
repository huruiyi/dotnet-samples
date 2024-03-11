using System;

namespace ConApp.Samples
{
    public class ContextBoundClass : ContextBoundObject
    {
        public string Value = "The Value property.";

        public static void DoAction()
        {
            // Determine whether the types can be hosted in a Context.
            Console.WriteLine("The IsContextful property for the {0} type is {1}.", typeof(Program).Name, typeof(Program).IsContextful);
            Console.WriteLine("The IsContextful property for the {0} type is {1}.", typeof(ContextBoundClass).Name, typeof(ContextBoundClass).IsContextful);

            // Determine whether the types are marshalled by reference.
            Console.WriteLine("The IsMarshalByRef property of {0} is {1}.", typeof(Program).Name, typeof(Program).IsMarshalByRef);
            Console.WriteLine("The IsMarshalByRef property of {0} is {1}.", typeof(ContextBoundClass).Name, typeof(ContextBoundClass).IsMarshalByRef);

            // Determine whether the types are primitive datatypes.
            Console.WriteLine("{0} is a primitive data type: {1}.", typeof(int).Name, typeof(int).IsPrimitive);
            Console.WriteLine("{0} is a primitive data type: {1}.", typeof(string).Name, typeof(string).IsPrimitive);
        }
    }
}