namespace 工厂方法模式
{
    /// <summary>
    /// 西红柿炒蛋工厂类
    /// </summary>
    public class TomatoScrambledEggsFactory : Creator
    {
        /// <summary>
        /// 负责创建西红柿炒蛋这道菜
        /// </summary>
        /// <returns></returns>
        public override AbstractFood CreateFoddFactory()
        {
            return new TomatoScrambledEggs();
        }
    }
}