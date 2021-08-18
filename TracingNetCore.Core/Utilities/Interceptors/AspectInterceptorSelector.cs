using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
using TracingNetCore.Core.Aspects.AutoFac.Exception;
using TracingNetCore.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using TracingNetCore.Core.Utilities.Interceptors.AutoFac;

namespace TracingNetCore.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttribute = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttribute = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            classAttribute.AddRange(methodAttribute);

            // Log Exception on Project (add all handller)
           classAttribute.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));
           classAttribute.Add(new ExceptionLogAspect(typeof(JsonFileLogger)));

            return classAttribute.OrderBy(x => x.Priority).ToArray();
        }
    }
}
