using JetBrains.Annotations; 

namespace gm.modularity
{
    public interface IModuleManager
    {
        void InitModules([NotNull] AppInitContext context);

        void ShutdownModules([NotNull] AppShutdownContext context);
    }
}
