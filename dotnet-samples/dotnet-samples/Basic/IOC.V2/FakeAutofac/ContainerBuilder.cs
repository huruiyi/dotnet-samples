using System;
using System.Collections.Generic;

namespace IOC.V2.FakeAutofac
{
    public class ContainerBuilder
    {
        //用来保存注册的类型
        private readonly Dictionary<Type, Resolver> _typePool = new Dictionary<Type, Resolver>();

        private Type type;

        public ContainerBuilder RegisterType<T>() where T : class
        {
            type = typeof(T);
            var resolver = new Resolver { RealType = type };
            _typePool[type] = resolver;

            return this;
        }

        public ContainerBuilder AsImplementedInterfaces()
        {
            //以接口为key, 对应Resolver
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                _typePool[@interface] = _typePool[type];
            }
            return this;
        }

        //创建Container
        public IContainer Build()
        {
            var container = new Container(_typePool);

            return container;
        }
    }
}