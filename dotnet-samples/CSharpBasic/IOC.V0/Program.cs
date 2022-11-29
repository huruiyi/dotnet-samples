using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOC.V0
{
    public class Program
    {
        public static void Main()
        {
            var assemblies = GetAllAssemblies();

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterDependency(assemblies, DependencyLifeTimeScope.Singleton);
            builder.RegisterGenericDependency(assemblies, DependencyLifeTimeScope.Singleton);

            builder.RegisterDependency(assemblies, DependencyLifeTimeScope.Indepentdent);
            builder.RegisterGenericDependency(assemblies, DependencyLifeTimeScope.Indepentdent);

            builder.RegisterDependency(assemblies, DependencyLifeTimeScope.Request);
            builder.RegisterGenericDependency(assemblies, DependencyLifeTimeScope.Request);

            var container = builder.Build();

            var strRepo = container.Resolve<IRepository<string>>();
            var intRepo = container.Resolve<IRepository<int>>();
            var strGeneric = container.Resolve<IGenericInterface<long>>();
            var normal = container.Resolve<INomalInterface>();

            Console.WriteLine(strRepo.GetEntityType());
            Console.WriteLine(intRepo.GetEntityType());
            Console.WriteLine(strGeneric.GetGenericType());
            Console.WriteLine(normal.GetType());

            var hashCode1 = container.Resolve<IRepository<User>>().GetHashCode();
            var hashCode2 = container.Resolve<IRepository<User>>().GetHashCode();
            var hashCode3 = container.Resolve<IIndependentRepository<User>>().GetHashCode();
            var hashCode4 = container.Resolve<IIndependentRepository<User>>().GetHashCode();
            var hashCode5 = container.Resolve<ISingletonRepository<User>>().GetHashCode();
            var hashCode6 = container.Resolve<ISingletonRepository<User>>().GetHashCode();
            var userService = container.Resolve<IUserService>();

            Console.WriteLine(hashCode1);
            Console.WriteLine(hashCode2);
            Console.WriteLine(hashCode3);
            Console.WriteLine(hashCode4);
            Console.WriteLine(hashCode5);
            Console.WriteLine(hashCode6);
            Console.WriteLine(userService.GetRepositoryType());

            Console.ReadLine();
        }

        /// <summary>
        /// 获取 当前运行 和 程序根文件夹里 的程序集
        /// </summary>
        /// <returns></returns>
        private static Assembly[] GetAllAssemblies()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Assembly executingAssmbly = Assembly.GetExecutingAssembly();
            return Directory.GetFiles(path, "*.dll").Select(Assembly.LoadFrom).Concat(new[] { executingAssmbly }).Distinct().ToArray();
        }
    }

    public static class AutofacExtension
    {
        public static void RegisterDependency(this ContainerBuilder builder, Assembly[] assemblies, DependencyLifeTimeScope lifeTimeScope)
        {
            Type baseType = GetBaseType(lifeTimeScope);
            switch (lifeTimeScope)
            {
                case DependencyLifeTimeScope.Singleton:
                    builder.RegisterAssemblyTypes(assemblies)
                        .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                        .AsSelf().AsImplementedInterfaces()
                        .PropertiesAutowired().SingleInstance();
                    break;

                case DependencyLifeTimeScope.Indepentdent:
                    builder.RegisterAssemblyTypes(assemblies)
                        .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                        .AsSelf().AsImplementedInterfaces()
                        .PropertiesAutowired().InstancePerDependency();
                    break;

                case DependencyLifeTimeScope.Request:
                    builder.RegisterAssemblyTypes(assemblies)
                        .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                        .AsSelf().AsImplementedInterfaces()
                        .PropertiesAutowired().InstancePerLifetimeScope();
                    break;
            }
        }

        public static void RegisterGenericDependency(this ContainerBuilder builder, Assembly[] assemblies, DependencyLifeTimeScope lifeTimeScope)
        {
            List<Type> types = null;
            foreach (var assembly in assemblies)
            {
                var assemblyTypes = assembly.GetTypes().ToList();
                if (types == null)
                    types = assemblyTypes;
                types = types.Concat(assemblyTypes).ToList();
            }

            if (types == null)
                return;

            Type baseType = GetBaseType(lifeTimeScope);
            types = types.Where(baseType.IsAssignableFrom).ToList();

            var genericTypeIntefaces = types.Where(type => type.IsGenericType && type.IsInterface).ToList();
            var genericTypeInstances = types.Where(type => type.IsGenericType && !type.IsAbstract).ToList();

            Dictionary<Type, Type> genericTypeDic = new Dictionary<Type, Type>();

            foreach (Type gInterface in genericTypeIntefaces)
            {
                foreach (Type gInstance in genericTypeInstances)
                {
                    if (gInterface.Name.Contains(gInstance.Name))
                    {
                        genericTypeDic.Add(gInterface, gInstance);
                    }
                }
            }

            foreach (var generic in genericTypeDic)
            {
                switch (lifeTimeScope)
                {
                    case DependencyLifeTimeScope.Singleton:
                        builder.RegisterGeneric(generic.Value).As(generic.Key).SingleInstance();
                        break;

                    case DependencyLifeTimeScope.Indepentdent:
                        builder.RegisterGeneric(generic.Value).As(generic.Key).InstancePerDependency();
                        break;

                    case DependencyLifeTimeScope.Request:
                        builder.RegisterGeneric(generic.Value).As(generic.Key).InstancePerLifetimeScope();
                        break;
                }
            }
        }

        private static Type GetBaseType(DependencyLifeTimeScope lifeTimeScope)
        {
            switch (lifeTimeScope)
            {
                case DependencyLifeTimeScope.Indepentdent:
                    return typeof(IIndependentDependency);

                case DependencyLifeTimeScope.Request:
                    return typeof(IRequestDenpendency);

                case DependencyLifeTimeScope.Singleton:
                    return typeof(ISingletonDependency);

                default:
                    return null;
            }
        }
    }

    public interface IUserService : IRequestDenpendency
    {
        Type GetRepositoryType();
    }

    public class UserService : IUserService
    {
        public IRepository<User> User { get; set; }

        public UserService(IRepository<User> user)
        {
            User = user;
        }

        public Type GetRepositoryType()
        {
            return User.GetEntityType();
        }
    }

    public enum DependencyLifeTimeScope
    {
        Singleton,
        Indepentdent,
        Request,
    }

    /// <summary>
    /// 单一实例生命周期注入(全局唯一)
    /// </summary>
    public interface ISingletonDependency
    {
    }

    /// <summary>
    /// 独立生命周期注入(每次注入不同)
    /// </summary>
    public interface IIndependentDependency
    {
    }

    /// <summary>
    /// 请求周期注入(同一次Http请求内实例相同)
    /// </summary>
    public interface IRequestDenpendency
    {
    }

    public interface IRepository<TEntity> : IRequestDenpendency
    {
        Type GetEntityType();
    }

    public interface IIndependentRepository<TEntity> : IIndependentDependency
    {
    }

    public interface ISingletonRepository<TEntity> : ISingletonDependency
    {
    }

    public class Repository<TEntity> : IRepository<TEntity>, IIndependentRepository<TEntity>, ISingletonRepository<TEntity>
    {
        public Type GetEntityType()
        {
            return typeof(TEntity);
        }
    }

    public interface IGenericInterface<T> : ISingletonDependency
    {
        Type GetGenericType();
    }

    public class GenericInterface<T> : IGenericInterface<T>
    {
        public Type GetGenericType()
        {
            return typeof(T);
        }
    }

    public interface INomalInterface : ISingletonDependency
    {
    }

    public class NomalInterface : INomalInterface
    {
    }

    public class User : Entity
    {
    }

    public class Entity<TKey>
    {
        public TKey Id { get; set; }
    }

    public class Entity : Entity<Guid>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}