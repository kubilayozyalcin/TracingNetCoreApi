using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracingNetCore.Core.Utilities.Interceptors.AutoFac;
using TracingNetCore.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace TracingNetCore.Core.Aspects.AutoFac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopWatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopWatch = ServiceTool.serviceProvider.GetService<Stopwatch>();   
        }

        protected override void OnBeFor(IInvocation invocation)
        {
            _stopWatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopWatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.Name} -- > {_stopWatch.Elapsed.TotalSeconds}");
            }
            _stopWatch.Reset();
        }
    }
}
