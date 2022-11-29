using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

/*
    Specifies that a type, property, field, or method provides a particular export.
    Namespace:   System.ComponentModel.Composition
    Assembly:  System.ComponentModel.Composition (in System.ComponentModel.Composition.dll)
*/

namespace ConApp.OtherDemo
{
    [Export]
    public class MyExport1
    {
        public string data = "Test Data 1.";
    }

    public class MyImporter1
    {
        [Import]
        public MyExport1 importedMember { get; set; }
    }

    public interface MyInterface
    {
    }

    //Specifying the contract type may be important if
    //you want to export a type other then the base type,
    //such as an interface.
    [Export(typeof(MyInterface))]
    public class MyExport2 : MyInterface
    {
        public string data = "Test Data 2.";
    }

    public class MyImporter2
    {
        //The import must match the contract type!
        [Import(typeof(MyInterface))]
        public MyExport2 importedMember { get; set; }
    }

    //Specifying a contract name should only be
    //needed in rare caes. Usually, using metadata
    //is a better approach.
    [Export("MyContractName", typeof(MyInterface))]
    public class MyExport3 : MyInterface
    {
        public string data = "Test Data 3.";
    }

    public class MyImporter3
    {
        //Both contract name and type must match!
        [Import("MyContractName", typeof(MyInterface))]
        public MyExport3 importedMember { get; set; }
    }

    internal class _7Export_Import
    {
        private static void Main7(string[] args)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MyExport1).Assembly));
            CompositionContainer _container = new CompositionContainer(catalog);
            MyImporter1 test1 = new MyImporter1();
            MyImporter2 test2 = new MyImporter2();
            MyImporter3 test3 = new MyImporter3();
            _container.SatisfyImportsOnce(test1);
            _container.SatisfyImportsOnce(test2);
            _container.SatisfyImportsOnce(test3);
            Console.WriteLine(test1.importedMember.data);
            Console.WriteLine(test2.importedMember.data);
            Console.WriteLine(test3.importedMember.data);
            Console.ReadLine();
        }
    }
}