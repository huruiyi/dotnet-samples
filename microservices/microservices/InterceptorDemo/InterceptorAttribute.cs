using AspectCore.DynamicProxy;
using System;
using System.Threading.Tasks;

namespace InterceptorDemo
{
    internal class InterceptorAttribute : AbstractInterceptorAttribute
    {
        //每个被拦截的方法中执行
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                Console.WriteLine("Before service call");
                await next(context);//执行被拦截的方法
            }
            catch (Exception)
            {
                Console.WriteLine("Service threw an exception!");
                throw;
            }
            finally
            {
                Console.WriteLine("After service call");
            }
        }
    }
}