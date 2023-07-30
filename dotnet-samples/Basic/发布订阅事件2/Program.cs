using System;

namespace 发布订阅事件2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WeatherLedDiplay displayer = new WeatherLedDiplay();
            WeatherBlackBoardDisplay wbbDisplayer = new WeatherBlackBoardDisplay();
            WeatherPhoneDisplay zhangSan = new WeatherPhoneDisplay("张三");
            WeatherPhoneDisplay liSi = new WeatherPhoneDisplay("李四");
            WeatherPhoneDisplay zhaoEr = new WeatherPhoneDisplay("赵二");
            WeatherReportPublish publisher = new WeatherReportPublish();
            publisher.AddDisplayer(displayer);
            publisher.AddDisplayer(wbbDisplayer);
            publisher.AddDisplayer(zhangSan);
            publisher.AddDisplayer(liSi);
            publisher.AddDisplayer(zhaoEr);
            publisher.PublishNewWeatherInformation(38, 2, "晴");
            Console.WriteLine("两个小时后：");
            publisher.PublishNewWeatherInformation(39, 1, "晴");
            Console.WriteLine("一个月后,李四离职了：");
            publisher.RemoveDisplayer(liSi);
            publisher.PublishNewWeatherInformation(29, 4, "多云");
            Console.Read();
        }
    }
}