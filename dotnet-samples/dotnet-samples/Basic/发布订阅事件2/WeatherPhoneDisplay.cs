using System;

namespace 发布订阅事件2
{
    internal class WeatherPhoneDisplay : IWeatherDisplay
    {
        // 员工姓名
        public string EmplayeeName;

        public WeatherPhoneDisplay(string name)
        {
            EmplayeeName = name;
        }

        public void Display(WeatherInformation information)
        {
            Console.WriteLine(@"{0}员工手机显示天气信息：{1}", EmplayeeName, information.ToString());
        }
    }
}