using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Fairy.ConApp.Test;
using Fairy.ConApp.Utils;

namespace Fairy.ConApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Code128 code128 = new Code128
            {
                ValueFont = new Font("宋体", 20)
            };
            Bitmap imgTemp = code128.GetCodeImage("T26200-1900-123-1-0900", Code128.Encode.Code128A);
            imgTemp.Save(AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCode.gif", System.Drawing.Imaging.ImageFormat.Gif);


            SerializerTest.Test2();

            Console.ReadKey();
        }

        static void Test1()
        {

            string hobbies = "A;B;C;D;E;F";
            List<string> hobbyList = new List<string>();
            foreach (string hobby in hobbies.Split(';'))
            {
                hobbyList.Add(hobby);
            }
            hobbyList.AddRange(hobbies.Split(';').Select(hobby => "|" + hobby + "|"));

            string hobbies2 = string.Empty;
            foreach (string hobby in hobbyList)
            {
                hobbies2 += hobby + ",";
            }

            Console.WriteLine(hobbies2);

            string hobbies3 = hobbyList.Aggregate(string.Empty, (current, item) => current + item + ",");
            Console.WriteLine(hobbies3);
        }
    }
}