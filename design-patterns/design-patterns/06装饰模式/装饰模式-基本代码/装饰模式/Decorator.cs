namespace 装饰模式
{
    internal abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            component?.Operation();
        }
    }
}