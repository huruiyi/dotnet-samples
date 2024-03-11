using System;

namespace ConApp.DelegateDemos
{
    internal class DelegateDemo9 : IDelegateDemo
    {
        public delegate void DelLogin(string str1, string str2);

        public DelLogin Login;

        public void LoginMethod(string userName, string userPwd)
        {
            if (userName == "123" && userPwd == "456")
            {
                Console.WriteLine("登陆成功!");
            }
            else
            {
                Console.WriteLine("登录失败!!");
            }
        }

        public void Invoke()
        {
            //Program p = new Program();
            //p.Login = p.LoginMethod;
            //p.Login("userName", "userPwd");

            Login = LoginMethod;

            Console.WriteLine("请输入用户名:");
            string userName = Console.ReadLine();
            Console.WriteLine("请输入密码:");
            string userPwd = Console.ReadLine();

            Login(userName, userPwd);
        }
    }
}