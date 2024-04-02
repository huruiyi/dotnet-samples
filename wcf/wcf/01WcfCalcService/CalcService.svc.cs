using System;

namespace _01WcfCalcService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CalcService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CalcService.svc 或 CalcService.svc.cs，然后开始调试。
    public class CalcService : ICalcService
    {
        public string DoWork()
        {
            return "Hello World";
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }

        public int Mult(int a, int b)
        {
            return a * b;
        }

        public int Div(int a, int b)
        {
            return a / b;
        }

        public decimal Add_decimal(string Number1, string Number2, out string error)
        {
            decimal result = 0;
            error = null;
            try
            {
                result = Convert.ToDecimal(Number1) + Convert.ToDecimal(Number2);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return result;
        }
    }
}