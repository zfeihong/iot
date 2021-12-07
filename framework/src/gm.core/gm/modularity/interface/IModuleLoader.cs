using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace gm.modularity
{
    public interface IModuleLoader
    {
        [NotNull]
        IModuleDescriptor[] LoadModules(
            [NotNull] IServiceCollection services,
            [NotNull] Type startupModule,
            [NotNull] PlugInList plugInList
        );
    }
}
