namespace 单一职责原则SRP2
{
    public class ElectricSource
    {
    }

    public interface IMobilePhoneBaseFunc
    {
        //手机充电接口
        void Charging(ElectricSource oElectricsource);

        //打电话
        void RingUp();

        //接电话
        void ReceiveUp();
    }

    public interface IMobilePhoneBaseProperty
    {
        //运行内存
        string Ram { get; set; }

        //手机存储内存
        string Rom { get; set; }

        //CPU主频
        string Cpu { get; set; }

        //屏幕大小
        int Size { get; set; }
    }

    public interface IMobilePhoneExtentionFunc
    {
        //上网
        void SurfInternet();

        //移动办公
        void MobileOa();

        //玩游戏
        void PlayGame();
    }

    public interface IMobilePhoneExtentionProperty
    {
        //摄像头像素
        string Pixel { get; set; }
    }

    public class MobilePhoneBaseFunc : IMobilePhoneBaseFunc
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
    }

    public class MobilePhoneBaseProperty : IMobilePhoneBaseProperty
    {
        public string Ram { get; set; }

        public string Rom { get; set; }

        public string Cpu { get; set; }

        public int Size { get; set; }
    }

    public class MobilePhoneExtentionFunc : IMobilePhoneExtentionFunc
    {
        public void SurfInternet()
        {
        }

        public void MobileOa()
        {
        }

        public void PlayGame()
        {
        }
    }

    public class MobilePhoneExtentionProperty : IMobilePhoneExtentionProperty
    {
        public string Pixel { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }
}