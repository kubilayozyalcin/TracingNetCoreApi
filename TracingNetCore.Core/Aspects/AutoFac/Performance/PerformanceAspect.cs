﻿using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TracingNetCore.Core.Utilities.Interceptors.AutoFac;
using TracingNetCore.Core.Utilities.IoC;

namespace TracingNetCore.Core.Aspects.AutoFac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopWatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopWatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBeFor(IInvocation invocation)
        {
            _stopWatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopWatch.Elapsed.TotalSeconds > _interval)
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}" +
                    $".{invocation.Method.Name} --> {_stopWatch.Elapsed.TotalSeconds}");

            _stopWatch.Reset();
        }
    }
}
