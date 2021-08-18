using Microsoft.Extensions.DependencyInjection;

namespace TracingNetCore.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
