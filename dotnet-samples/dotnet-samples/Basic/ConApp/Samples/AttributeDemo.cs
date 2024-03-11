using ConApp.Model;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConApp
{
    public interface ISay
    {
        string Say();
    }

    [Block(Level.Yes)]
    public class GovermentSay : ISay
    {
        public string Say()
        {
            return "Our country is the most democratic country";
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class BlockAttribute : Attribute
    {
        public Level Level { get; set; }

        public BlockAttribute(Level level)
        {
            Level = level;
        }
    }

    [Block(Level.NO)]
    public class PeopleSay : ISay
    {
        public string Say()
        {
            return "We need human rights";
        }
    }

    public enum Level { NO, Yes }

    public class ThePress
    {
        public static void Print(ISay say)
        {
            System.Reflection.MemberInfo info = say.GetType();
            BlockAttribute att = (BlockAttribute)Attribute.GetCustomAttribute(info, typeof(BlockAttribute));
            if (att.Level == Level.Yes)
            {
                Console.WriteLine(say.GetType() + ": " + say.Say());
            }
            else
            {
                Console.WriteLine(say.GetType() + ": " + "I Love the contry!");
            }
        }
    }

    [Block(Level.NO)]
    public class AttributeDemo
    {
        /// <summary>
        /// 通过反射取自定义属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private static void DisplaySelfAttribute<T>() where T : class, new()
        {
            string tableName = string.Empty;
            List<string> listColumnName = new List<string>();
            Type objType = typeof(T);
            //取属性上的自定义特性
            foreach (PropertyInfo propInfo in objType.GetProperties())
            {
                object[] objAttrs = propInfo.GetCustomAttributes(typeof(EnitityMappingAttribute), true);
                if (objAttrs.Length > 0)
                {
                    EnitityMappingAttribute attr = objAttrs[0] as EnitityMappingAttribute;
                    if (attr != null)
                    {
                        listColumnName.Add(attr.ColumnName); //列名
                    }
                }
            }
            //取类上的自定义特性
            object[] objs = objType.GetCustomAttributes(typeof(EnitityMappingAttribute), true);
            foreach (object obj in objs)
            {
                EnitityMappingAttribute attr = obj as EnitityMappingAttribute;
                if (attr != null)
                {
                    tableName = attr.TableName;//表名只有获取一次
                    break;
                }
            }
            if (string.IsNullOrEmpty(tableName))
            {
                tableName = objType.Name;
            }
            Console.WriteLine(string.Format("The tablename of the entity is:{0} ", tableName));
            if (listColumnName.Count > 0)
            {
                Console.WriteLine("The columns of the table are as follows:");
                foreach (string item in listColumnName)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void Demo()
        {
            ISay sayPeople = new PeopleSay();
            ISay say = new GovermentSay();
            ThePress.Print(sayPeople);
            ThePress.Print(say);

            DisplaySelfAttribute<Member>(); //显示结果
        }
    }
}