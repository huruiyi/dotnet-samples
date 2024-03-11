namespace 工厂方法模式
{
    /// <summary>
    /// 土豆肉丝工厂类
    /// </summary>
    public class ShreddedPorkWithPotatoesFactory : Creator
    {
        /// <summary>
        /// 负责创建土豆肉丝这道菜
        /// </summary>
        /// <returns></returns>
        public override AbstractFood CreateFoddFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }
}