using AspectCore.DynamicProxy;
using Polly;
using Polly.Timeout;
using System;
using System.Threading.Tasks;

namespace hystrixtest2
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HystrixCommandAttribute : AbstractInterceptorAttribute
    {
        public int MaxRetryTimes { get; set; } = 0;
        public int RetryIntervalMilliseconds { get; set; } = 100;
        public bool EnableCircuitBreaker { get; set; } = false;
        public int ExceptionsAllowedBeforeBreaking { get; set; } = 3;
        public int MillisecondsOfBreak { get; set; } = 1000;

        public int TimeOutMilliseconds { get; set; } = 0;

        public int CacheTTLMilliseconds { get; set; } = 0;

        private static readonly Microsoft.Extensions.Caching.Memory.IMemoryCache memoryCache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCacheOptions());

        public HystrixCommandAttribute(string fallBackMethod)
        {
            this.FallBackMethod = fallBackMethod;
        }

        public string FallBackMethod { get; set; }

        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            ISyncPolicy policy = Policy.Handle<Exception>().RetryAsync();
            policy.Execute(() =>
            {
                var fallBackMethod = context.ServiceMethod.DeclaringType.GetMethod(this.FallBackMethod);
                Object fallBackResult = fallBackMethod.Invoke(context.Implementation, context.Parameters);
                context.ReturnValue = fallBackResult;
            });
            if (MaxRetryTimes > 0)
            {
                policy = policy.Wrap(Policy.Handle<Exception>().WaitAndRetry(MaxRetryTimes, i => TimeSpan.FromMilliseconds(RetryIntervalMilliseconds)));
            }
            if (EnableCircuitBreaker)
            {
                policy = policy.Wrap(Policy.Handle<Exception>().CircuitBreaker(ExceptionsAllowedBeforeBreaking, TimeSpan.FromMilliseconds(RetryIntervalMilliseconds)));
            }
            if (TimeOutMilliseconds > 0)
            {
                policy = policy.Wrap(Policy.Timeout(() => TimeSpan.FromMilliseconds(TimeOutMilliseconds), TimeoutStrategy.Pessimistic));
            }
            //Install-Package Microsoft.Extensions.Caching.Memory
            if (CacheTTLMilliseconds > 0)
            {
                //用类名+方法名+参数的下划线连接起来作为缓存key
                string cacheKey = "HystrixMethodCacheManager_Key_" + context.ServiceMethod.DeclaringType
                    + "." + context.ServiceMethod + string.Join("_", context.Parameters);
                Object cacheValue;
                //尝试去缓存中获取
                if (memoryCache.TryGetValue(cacheKey, out cacheValue))
                {
                    context.ReturnValue = cacheValue;
                    await Task.FromResult(0);
                }
                else
                {
                    object returnValue = null;
                    policy.Execute(() =>
                    {
                        //执行实际的方法
                        // returnValue = context.Invoke(next);
                        returnValue = next(context);//执行被拦截的方法
                    });
                    using (var cacheEntry = memoryCache.CreateEntry(cacheKey))
                    {
                        cacheEntry.Value = context.ReturnValue;
                        cacheEntry.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMilliseconds(CacheTTLMilliseconds);
                    }
                    await Task.FromResult(returnValue);
                }
            }
            else//如果没有启用缓存，就直接执行业务方法
            {
                object returnValue = null;
                policy.Execute(() =>
                {
                    returnValue = context.Invoke(next);
                });
                await Task.FromResult(returnValue);
            }
        }
    }
}