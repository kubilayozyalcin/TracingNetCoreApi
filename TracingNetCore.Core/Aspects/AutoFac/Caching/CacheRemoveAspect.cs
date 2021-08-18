﻿using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using TracingNetCore.Core.CrossCuttingConcerns.Caching;
using TracingNetCore.Core.Utilities.Interceptors.AutoFac;
using TracingNetCore.Core.Utilities.IoC;

namespace TracingNetCore.Core.Aspects.AutoFac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
