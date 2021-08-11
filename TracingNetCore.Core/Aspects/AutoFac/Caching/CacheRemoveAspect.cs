using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
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
            _cacheManager = ServiceTool.serviceProvider.GetService<ICacheManager>();    
        }

        protected override void OnSuccess(IInvocation ınvocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
