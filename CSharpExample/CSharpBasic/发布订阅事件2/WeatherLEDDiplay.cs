using System;

namespace 发布订阅事件2
{
    internal class WeatherLedDiplay : IWeatherDisplay
    {
        public void Display(WeatherInformation weather)
        {
            Console.WriteLine("LED显示屏为您带来天气信息：{0}", weather.ToString());
        }
    }
}