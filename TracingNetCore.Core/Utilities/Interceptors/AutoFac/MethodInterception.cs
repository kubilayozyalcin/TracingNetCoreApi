﻿using Castle.DynamicProxy;
using System;

namespace TracingNetCore.Core.Utilities.Interceptors.AutoFac
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBeFor(IInvocation invocation) { }

        protected virtual void OnAfter(IInvocation invocation) { }

        protected virtual void OnException(IInvocation invocation) { }

        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBeFor(invocation);

            try { invocation.Proceed(); }
            catch (Exception)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally { if (isSuccess) OnSuccess(invocation); }

            OnAfter(invocation);
        }
    }
}