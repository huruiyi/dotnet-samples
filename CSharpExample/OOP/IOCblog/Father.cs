using System;

namespace IOCblog
{
    //调用者实现类
    public class Father
    {
        private readonly IPerson _iperson;

        private readonly Container _container = new Container();

        public Father(string typeName)
        {
            _iperson = _container.GetApplication(typeName);
        }

        public void Operation()
        {
            _iperson.Operation();
        }
    }
}