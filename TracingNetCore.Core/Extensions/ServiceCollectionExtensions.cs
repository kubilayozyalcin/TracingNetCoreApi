using Microsoft.Extensions.DependencyInjection;
using TracingNetCore.Core.Utilities.IoC;

namespace TracingNetCore.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,
            ICoreModule[] coreModules)
        {
            foreach (var module in coreModules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
