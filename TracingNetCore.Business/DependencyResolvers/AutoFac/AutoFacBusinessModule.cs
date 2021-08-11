using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using TacingNetCore.DataAccess.Abstractions;
using TacingNetCore.DataAccess.Concrete.EntityFramework;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Business.Concrete;
using TracingNetCore.Core.Utilities.Interceptors;
using TracingNetCore.Core.Utilities.Security.Jwt;

namespace TracingNetCore.Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DeviceManager>().As<IDeviceService>();
            builder.RegisterType<EFDevice>().As<IDeviceDal>();

            builder.RegisterType<RequestManager>().As<IRequestService>();
            builder.RegisterType<EFRequest>().As<IRequestDal>();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>();
            builder.RegisterType<EFEmployee>().As<IEmployeeDal>();

            builder.RegisterType<EmployeeDeviceManager>().As<IEmployeeDeviceService>();
            builder.RegisterType<EFEmployeeDevice>().As<IEmployeeDeviceDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUser>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JsonWebTokenHelper>().As<ITokenHelper>();


            // Autofac Fluent Validation 

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions() { 
                
                Selector = new AspectInterceptorSelector()
                
                }).SingleInstance();
        }
    }
}

