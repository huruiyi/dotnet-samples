namespace ConApp.Model
{
    public class DynamicClass
    {
        public dynamic X;
        public dynamic Y { get; set; }

        public dynamic Return(dynamic d)
        {
            if (d is int)
            {
                return "整数加一后的结果是：" + d++;
            }
            else if (d is string)
            {
                return "你输入的参数字符串：" + d;
            }
            else
            {
                return "不是整数不是字符串";
            }
        }
    }
}