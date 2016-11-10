using System;

namespace 发布订阅事件1
{
    // 求职者
    internal class JobSeeker
    {
        public string Name;

        public JobSeeker(string name)
        {
            Name = name;
        }

        public void Register(Intermediary intermediary)
        {
            intermediary.OnNewJobReceive += intermediary_OnNewJobReceive;
            Console.WriteLine("{0}到{1}中介去注册了", Name, intermediary.Name);
        }

        public void UnRegister(Intermediary intermediary)
        {
            intermediary.OnNewJobReceive -= intermediary_OnNewJobReceive;
            Console.WriteLine("{0}从{1}中介退订了", Name, intermediary.Name);
        }

        private void intermediary_OnNewJobReceive(object sender, NewJobMessageEventArgs e)
        {
            Intermediary intermediary = sender as Intermediary;
            Console.WriteLine("{0}求职者从{1}中介获取到了{2}工作信息", Name, intermediary.Name, e.Message);
        }
    }
}