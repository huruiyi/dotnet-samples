namespace 发布订阅事件2
{
    // 天气信息
    internal class WeatherInformation
    {
        // 温度
        public int Temperature;

        // 风速
        public int WindSpeed;

        // 天气状况
        public string Message;

        // 构造函数
        public WeatherInformation(int t, int ws, string message)
        {
            Temperature = t;
            WindSpeed = ws;
            Message = message;
        }

        public override string ToString()
        {
            return string.Format("温度：{0}，风速：{1}，天气状况：{2}", Temperature, WindSpeed, Message);
        }
    }
}