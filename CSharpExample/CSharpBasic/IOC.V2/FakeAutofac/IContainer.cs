namespace IOC.V2.FakeAutofac
{
    public interface IContainer
    {
        T Resolve<T>() where T : class;
    }
}