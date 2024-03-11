namespace 单一职责原则SRP1
{
    public class ElectricSource
    {
    }

    public class HuaweiMobile
    {
        private IMobilePhoneProperty _mProperty;
        private IMobilePhoneFunction _mFunc;

        public HuaweiMobile(IMobilePhoneProperty oProperty, IMobilePhoneFunction oFunc)
        {
            _mProperty = oProperty;
            _mFunc = oFunc;
        }
    }

    public interface IMobilePhoneFunction
    {
        //手机充电接口
        void Charging(ElectricSource oElectricsource);

        //打电话
        void RingUp();

        //接电话
        void ReceiveUp();

        //上网
        void SurfInternet();

        //移动办公
        void MobileOa();
    }

    public interface IMobilePhoneProperty
    {
        //运行内存
        string Ram { get; set; }

        //手机存储内存
        string Rom { get; set; }

        //CPU主频
        string Cpu { get; set; }

        //屏幕大小
        int Size { get; set; }

        //摄像头像素
        string Pixel { get; set; }
    }

    public class MobileFunction : IMobilePhoneFunction
    {
        public void Charging(ElectricSource oElectricsource)
        {
        }

        public void RingUp()
        {
        }

        public void ReceiveUp()
        {
        }

        public void SurfInternet()
        {
        }

        public void MobileOa()
        {
        }
    }

    public class MobileProperty : IMobilePhoneProperty
    {
        public string Ram { get; set; }

        public string Rom { get; set; }

        public string Cpu { get; set; }

        public int Size { get; set; }

        public string Pixel { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }
}