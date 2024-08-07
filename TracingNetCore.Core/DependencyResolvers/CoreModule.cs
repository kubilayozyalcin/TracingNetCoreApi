﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TracingNetCore.Core.CrossCuttingConcerns.Caching;
using TracingNetCore.Core.CrossCuttingConcerns.Caching.Microsoft;
using TracingNetCore.Core.Utilities.IoC;

namespace TracingNetCore.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
