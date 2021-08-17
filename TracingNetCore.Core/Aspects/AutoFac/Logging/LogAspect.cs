using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracingNetCore.Core.CrossCuttingConcerns.Logging;
using TracingNetCore.Core.CrossCuttingConcerns.Logging.Log4Net;
using TracingNetCore.Core.Utilities.Interceptors.AutoFac;
using TracingNetCore.Core.Utilities.Messages;

namespace TracingNetCore.Core.Aspects.AutoFac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new Exception(AspectMessages.WrongLoggerType);
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBeFor(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name

                });
            }
            

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                logParameters = logParameters
            };

            return logDetail;
        }
    }
}
