using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using TracingNetCore.Business.Constants;
using TracingNetCore.Core.Extensions;
using TracingNetCore.Core.Utilities.Interceptors.AutoFac;
using TracingNetCore.Core.Utilities.IoC;

namespace TracingNetCore.Business.BusinessAspect.AutoFac
{
    public class SecuredOperation : MethodInterception
    {
        string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.serviceProvider.GetService<IHttpContextAccessor>();

        }
        protected override void OnBeFor(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                    return;                
            }
            throw new Exception(DataMessages.AuthorizationDenied);
        }
    }
}
