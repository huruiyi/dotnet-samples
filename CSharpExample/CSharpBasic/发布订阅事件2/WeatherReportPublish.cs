using System.Collections.Generic;

namespace 发布订阅事件2
{
    // 天气预报发布者
    internal class WeatherReportPublish
    {
        // 一系列的天气预报显示器
        public List<IWeatherDisplay> Displayers;

        // 添加天气预报显示器
        public void AddDisplayer(IWeatherDisplay displayer)
        {
            if (Displayers == null)
            {
                Displayers = new List<IWeatherDisplay>();
            }
            Displayers.Add(displayer);
        }

        // 去除天气预报显示器
        public void RemoveDisplayer(IWeatherDisplay displayer)
        {
            if (Displayers != null)
            {
                Displayers.Remove(displayer);
            }
        }

        public WeatherReportPublish()
        {
        }

        // 发布新的天气信息
        public void PublishNewWeatherInformation(int t, int ws, string message)
        {
            WeatherInformation information = new WeatherInformation(t, ws, message);
            if (Displayers != null)
            {
                foreach (IWeatherDisplay displayer in Displayers)
                {
                    displayer.Display(information);
                }
            }
        }
    }
}