using Castle.DynamicProxy;
using System;

namespace TracingNetCore.Core.Utilities.Interceptors.AutoFac
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBeFor(IInvocation invocation) { }

        protected virtual void OnAfter(IInvocation invocation) { }

        protected virtual void OnException(IInvocation invocation, Exception e) { }

        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBeFor(invocation);

            try { invocation.Proceed(); }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally { if (isSuccess) OnSuccess(invocation); }

            OnAfter(invocation);
        }
    }
}
