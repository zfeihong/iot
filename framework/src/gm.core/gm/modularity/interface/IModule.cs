using gm.modularity;
using JetBrains.Annotations;

namespace gm.modularity
{
    public interface IModule
    {
        void OnPreAppInit([NotNull] AppInitContext context);
        void OnAppInit([NotNull] AppInitContext context);
        void OnPostAppInit([NotNull] AppInitContext context);

        void PreCfgServices(ServiceCfgContext context);
        void CfgService(ServiceCfgContext context);
        void PostCfgServices(ServiceCfgContext context);

        void OnAppShutdown([NotNull] AppShutdownContext context);

    }
}
