using gm.modularity;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace gm.core
{
    public class AppCreationOptions
    {
        [NotNull]
        public IServiceCollection Services { get; }

        [NotNull]
        public PlugInList PlugInList { get; }
 
        public AppCreationOptions([NotNull] IServiceCollection services)
        {
            Services = services;
            PlugInList = new PlugInList();
        }
    }
}
