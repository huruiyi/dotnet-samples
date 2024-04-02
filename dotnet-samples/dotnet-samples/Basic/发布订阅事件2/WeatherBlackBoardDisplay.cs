using System;

namespace 发布订阅事件2
{
    internal class WeatherBlackBoardDisplay : IWeatherDisplay
    {
        public void Display(WeatherInformation information)
        {
            Console.WriteLine(@"小黑板为您带来天气信息：{0}", information.ToString());
        }
    }
}