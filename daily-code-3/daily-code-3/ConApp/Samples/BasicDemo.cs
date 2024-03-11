using System;
using System.Collections;

namespace ConApp.Samples
{
    public class BasicDemo
    {
        private static void Demo1()
        {
            int U1 = 1112;										//声明整型变量U1
            int U2 = 927;										//声明整型变量U2
            bool result;										//声明bool型变量result
            result = U1 < U2;                                   //使result等于U1和U2进行小于运算的返回值
            Console.WriteLine(result);                          //输出结果

            int F1 = 18;										//声明整型变量F1
            int F2 = 8;											//声明整型变量F2
            bool resultF;                                       //声明bool型变量resultF
                                                                //使result等于F1和F2进行大于运算的返回值
            resultF = F1 > F2;
            Console.WriteLine(resultF);                         //输出结果

            int X1 = 12;										//声明整型变量X1
            int X2 = 9;											//声明整型变量X2
            bool resultX;											//声明bool型变量resultX
            //使result等于X1和X2进行小于或等于运算的返回值
            resultX = X2 <= X1;
            Console.WriteLine(resultX);                             //输出结果

            int num1 = 1;										//声明一个整型的变量num1  00000001
            int num2 = 85;                                      //声明一个整型的变量num2  01010101
                                                                //                        00000001
            bool iseven;										//声明一个bool类型的变量iseven
            iseven = (num1 & num2) == 0;				    	//获取两个变量“与”运算后的返回值
            Console.WriteLine(iseven);							//输出结果
        }

        public static void Demo2()
        {
            int i = Convert.ToInt32(DateTime.Today.DayOfWeek);		//获取当前日期的数值
            switch (i)										        //调用switch语句
            {
                case 1: Console.WriteLine("今天是星期一"); break;		//如果i是1，则输出今天是星期一
                case 2: Console.WriteLine("今天是星期二"); break;		//如果i是2，则输出今天是星期二
                case 3: Console.WriteLine("今天是星期三"); break;		//如果i是3，则输出今天是星期三
                case 4: Console.WriteLine("今天是星期四"); break;		//如果i是4，则输出今天是星期四
                case 5: Console.WriteLine("今天是星期五"); break;		//如果i是5，则输出今天是星期五
                case 6: Console.WriteLine("今天是星期六"); break;		//如果i是6，则输出今天是星期六
                case 7: Console.WriteLine("今天是星期日"); break;		//如果i是7，则输出今天是星期日
            }
        }

        public static void Demo3()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ArrayList List = new ArrayList(arr);			//使用声明的一维数组实例化一个ArrayList对象
            Console.WriteLine("原ArrayList集合：");
            foreach (int i in List)						//遍历ArrayList集合中的元素并输出
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
            List.RemoveRange(0, 5);					//从ArrayList集合中移除指定下标位置的元素
            Console.WriteLine("删除元素后的ArrayList集合：");
            foreach (int i in List)						//遍历删除元素后的ArrayList集合并输出其元素
            {
                Console.Write(i.ToString() + " ");
            }
        }

        public static void Demo4()
        {
            string StrA = "用^一生#下载,你";
            char[] separator = { '^', '#', ',' };
            String[] splitstrings = new String[100];
            splitstrings = StrA.Split(separator);							//分割字符串
            for (int i = 0; i < splitstrings.Length; i++)
            {
                Console.WriteLine("item{0}:{1}", i, splitstrings[i]);
            }

            string str1 = "*^__^*";
            //声明一个字符串变量str2，并使用PadLeft方法在str1的左侧填充字符“(”
            string str2 = str1.PadLeft(7, '(');
            //声明一个字符串变量str3，并使用PadRight方法在str2右侧填充字符“)”
            string str3 = str2.PadRight(8, ')');
            Console.WriteLine("补充字符串之前：" + str1);
            Console.WriteLine("补充字符串之后：" + str3);

            string str4 = "用一生下载你";

            string str5 = str4.Remove(3);
            //声明一个字符串变量str6，并使用Remove方法从字符串str1的索引1处开始删除两个字符
            string str6 = str1.Remove(1, 2);
            Console.WriteLine(str5);
            Console.WriteLine(str6);
        }

        public static void Demo5()
        {
            for (int i = 0; i < 4; i++)					    	//调用for语句
            {
                Console.Write("\n第{0}次循环：", i);	    	//输出提示是第几次循环
                for (int j = 0; j < 200; j++)					//调用for语句
                {
                    if (j == 12)					        	//如果j的值等于12
                        break;						            //终止循环
                    Console.Write(j + " ");				    	//输出j
                }
            }

            for (int i = 0; i < 4; i++)					    	//调用for循环
            {
                Console.Write("\n第{0}次循环：", i);		    //输出提示第几次循环
                for (int j = 0; j < 20; j++)					//调用for循环
                {
                    if (j % 2 == 0)						        //调用if语句判断j是否是偶数
                        continue;						        //如果是偶数则使用continue语句继续下一循环
                    Console.Write(j + " ");					    //输出j
                }
                Console.WriteLine();
            }
        }

        public static void Demo6()
        {
            ArrayList list = new ArrayList();				//实例化一个ArrayList对象
            list.Add("TM");							        //向ArrayList集合中添加元素
            list.Add("C# 3.5 从入门到应用开发");
            foreach (string str in list)					//遍历ArrayList集合中的元素并输出
            {
                Console.WriteLine(str);
            }
        }

        public static void Demo7()
        {
            string str1 = "下载";					        	//声明字符串变量str1并赋值为“下载”
            string str2;							        	//声明字符串变量str2
            str2 = str1.Insert(0, "用一生");					//使用Insert方法向字符串str1中插入字符串
            string str3 = str2.Insert(5, "你");			    	//使用Insert方法向字符串str2中插入字符串
            Console.WriteLine(str3);						    //输出字符串变量str3
        }

        public static void Demo8()
        {
            Hashtable hashtable = new Hashtable();				//实例化Hashtable对象
            hashtable.Add("id", "BH0001");					    //向Hashtable哈希表中添加元素
            hashtable.Add("name", "TM");
            hashtable.Add("sex", "男");
            hashtable.Remove("sex");						//移除Hashtable哈希表中的指定元素
            Console.WriteLine(hashtable.Count);				    //获得Hashtable哈希表中的元素个数
        }

        public static void Demo9()
        {
            Console.WriteLine("请输入要查找的文字：");				//输出提示信息
            string inputstr = Console.ReadLine();					//获取输入值
            string[] mystr = new string[5];							//创建一个字符串数组
            mystr[0] = "用一生下载你";							    //向数组中添加第一个元素
            mystr[1] = "芸烨湘枫";								    //向数组中添加第二个元素
            mystr[2] = "一生所爱";								    //向数组中添加第三个元素
            mystr[3] = "情茧";									    //向数组中添加第四个元素
            mystr[4] = "风华绝代";								    //向数组中添加第五个元素
            for (int i = 0; i < mystr.Length; i++)					//调用for循环语句
            {
                //通过if语句判断是否存在输入的字符串
                if (mystr[i].Equals(inputstr))
                {
                    goto Found; 							    	//调用goto语句跳转到Found
                }
            }
            Console.WriteLine("您查找的{0}不存在！", inputstr);		//输出信息
            goto Finish;                                            //调用goto语句跳转到Finish
            Found:
            Console.WriteLine("您查找的{0}存在！", inputstr);       //输出信息，提示存在输入的字符串
            Finish:
            Console.WriteLine("查找完毕！");						//输出信息，提示查找完毕
            Console.ReadLine();
        }

        public static string MyStr(string str)
        {
            string OutStr;								//声明一个字符串变量
            OutStr = "您输入的数据是：" + str;				//为字符串变量赋值
            return OutStr;							//使用return语句返回字符串变量
        }

        public static void Demo10()
        {
            Console.WriteLine("请您输入内容：");			//输出提示信息
            string inputstr = Console.ReadLine();			//获取输入的数据
            Console.WriteLine(MyStr(inputstr));				//调用MyStr方法并将结果显示出来
        }
    }
}