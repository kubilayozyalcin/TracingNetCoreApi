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

            builder.RegisterType<RegionManager>().As<IRegionService>();
            builder.RegisterType<EFRegion>().As<IRegionDal>();

            builder.RegisterType<AlarmManager>().As<IAlarmService>();
            builder.RegisterType<EFAlarm>().As<IAlarmDal>();

            builder.RegisterType<DeviceTypeManager>().As<IDeviceTypeService>();
            builder.RegisterType<EFDeviceType>().As<IDeviceTypeDal>();

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
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {

                    Selector = new AspectInterceptorSelector()

                }).SingleInstance();
        }
    }
}

