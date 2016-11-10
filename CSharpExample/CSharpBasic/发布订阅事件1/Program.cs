using System;

namespace 发布订阅事件1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Intermediary zhiLian = new Intermediary("智联招聘");
            Intermediary _51Job = new Intermediary("51Job");
            Intermediary xinsj = new Intermediary("新世纪人才网");

            JobSeeker zhangSan = new JobSeeker("张三");
            JobSeeker liSi = new JobSeeker("李四");

            zhangSan.Register(zhiLian);
            zhangSan.Register(_51Job);

            liSi.Register(xinsj);

            zhiLian.ReceiveNewJobMessage("文思海辉招收测试人员");
            xinsj.ReceiveNewJobMessage("NIIT招收DotNet讲师");

            Console.WriteLine("三个月后.....");

            zhangSan.UnRegister(zhiLian);
            zhangSan.UnRegister(_51Job);

            liSi.UnRegister(xinsj);

            zhiLian.ReceiveNewJobMessage("微软中国招收客服人员");

            Console.ReadLine();
        }
    }
}