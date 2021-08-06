using Autofac;
using TacingNetCore.DataAccess.Abstractions;
using TacingNetCore.DataAccess.Concrete.EntityFramework;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Business.Concrete;

namespace TracingNetCore.Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DeviceManager>().As<IDeviceService>();
            builder.RegisterType<EFDevice>().As<IDeviceDal>();
        }
    }
}
