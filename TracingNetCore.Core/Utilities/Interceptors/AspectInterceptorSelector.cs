﻿using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
using TracingNetCore.Core.Utilities.Interceptors.AutoFac;

namespace TracingNetCore.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttribute = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttribute = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            classAttribute.AddRange(methodAttribute);

            return classAttribute.OrderBy(x =>x.Priority).ToArray();
        }
    }
}
