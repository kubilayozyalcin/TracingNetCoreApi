using Castle.DynamicProxy;
using System;
using System.Transactions;
using TracingNetCore.Core.Utilities.Interceptors.AutoFac;

namespace TracingNetCore.Core.Aspects.AutoFac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
