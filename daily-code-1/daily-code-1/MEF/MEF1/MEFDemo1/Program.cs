using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Reflection;

namespace MEFDemo1
{
    public interface IBookService
    {
        string BookName { get; set; }

        string GetBookName();
    }

    [Export("MusicBook")]
    public class MusicBook : IBookService
    {
        //导出私有属性
        [Export(typeof(string))]
        private string _privateBookName = "Private Music BookName";

        //导出公有属性
        [Export(typeof(string))]
        public string PublicBookName = "Public Music BookName";

        public string BookName { get; set; }

        //导出公有方法
        [Export(typeof(Func<string>))]
        public string GetBookName()
        {
            Debug.Write(_privateBookName);
            Debug.Write(PublicBookName);

            return "MusicBook";
        }

        //导出私有方法
        [Export(typeof(Func<int, string>))]
        private string GetBookPrice(int price)
        {
            return "$" + price;
        }
    }

    [Export("MathBook", typeof(IBookService))]
    public class MathBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "MathBook";
        }
    }

    [Export("HistoryBook", typeof(IBookService))]
    public class HistoryBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "HistoryBook";
        }
    }

    internal class Program
    {
        [ImportMany("MathBook")]
        public IEnumerable<object> Services { get; set; }

        //导入属性，这里不区分public还是private
        [ImportMany]
        public List<string> InputString { get; set; }

        //导入无参数方法
        [Import]
        public Func<string> MethodWithoutPara { get; set; }

        //导入有参数方法
        [Import]
        public Func<int, string> MethodWithPara { get; set; }

        private static void Main()
        {
            Program pro = new Program
            {
                MethodWithoutPara = () => "",
                MethodWithPara = a => a.ToString()
            };
            pro.Compose();
            if (pro.Services != null)
            {
                foreach (var s in pro.Services)
                {
                    IBookService ss = (IBookService)s;
                    Console.WriteLine(ss.GetBookName());
                }
            }
            foreach (var str in pro.InputString)
            {
                Console.WriteLine(str);
            }

            //调用无参数方法
            if (pro.MethodWithoutPara != null)
            {
                Console.WriteLine(pro.MethodWithoutPara());
            }
            //调用有参数方法
            if (pro.MethodWithPara != null)
            {
                Console.WriteLine(pro.MethodWithPara(3000));
            }

            Console.Read();
        }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}