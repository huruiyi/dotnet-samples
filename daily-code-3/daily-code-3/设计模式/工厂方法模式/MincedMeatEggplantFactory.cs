namespace 工厂方法模式
{
    /// <summary>
    /// 肉末茄子工厂类，负责创建肉末茄子这道菜
    /// </summary>
    public class MincedMeatEggplantFactory : Creator
    {
        /// <summary>
        /// 负责创建肉末茄子这道菜
        /// </summary>
        /// <returns></returns>
        public override AbstractFood CreateFoddFactory()
        {
            return new MincedMeatEggplant();
        }
    }
}