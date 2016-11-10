using System;

namespace ConsoleAppTest
{
    internal class StringTest
    {
        private static void Main1(string[] args)
        {
            string s = "1";
            Console.WriteLine("1".Equals("1")); ;
            string newPwd = Password.EncryptPassword("abc123456");
            string orgPwd = Password.DecryptPassword(newPwd);
            Console.WriteLine(newPwd + "                 " + orgPwd);

            #region 课上练习4：把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本,输出：

            // 姓名：张三 电话：15001111113

            //string[] lines = File.ReadAllLines("1.csv", Encoding.Default);

            //string[] arr = new string[lines.Length];

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string tmp = lines[i].Replace("\"", "");
            //    string[] array = tmp.Split(',');
            //    if (array.Length == 3)
            //    {
            //        arr[i] = string.Format("{0} {1}", array[0] + array[1], array[2]);
            //    }
            //    else
            //    {
            //        arr[i] = null;
            //    }
            //}

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (!string.IsNullOrEmpty(arr[i]))
            //    {
            //        Console.WriteLine(arr[i]);
            //    }
            //}
            //Console.Read();

            #endregion 课上练习4：把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本,输出：

            Console.Read();
        }

        private static string Reverse(string str)
        {
            //反转字符串
            char[] arr = str.ToCharArray();

            for (int i = 0; i < arr.Length / 2; i++)
            {
                char tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }
            //string s = new string(arr);
            return string.Join("", arr);
        }
    }

    internal class Password
    {
        public static string EncryptPassword(string strPassword)
        {
            //加密密码
            string encryPassword = "";
            int i;

            char[] charFont = strPassword.ToCharArray();
            for (i = 0; i < charFont.Length; i++)
            {
                int intFont = charFont[i] + 64;
                charFont[i] = Convert.ToChar(intFont);
            }

            for (i = 0; i < charFont.Length; i++)
            {
                encryPassword += charFont[i];
            }
            return encryPassword;
        }

        public static string DecryptPassword(string encryPassword)
        {
            //解密密码
            string strPassword = "";
            int i;

            char[] charFont = encryPassword.ToCharArray();
            for (i = 0; i < charFont.Length; i++)
            {
                int intFont = (int)charFont[i] - 64;
                charFont[i] = Convert.ToChar(intFont);
            }
            for (i = 0; i < charFont.Length; i++)
            {
                strPassword += charFont[i];
            }
            return strPassword;
        }
    }
}