using gm.di;
using JetBrains.Annotations;

namespace gm.modularity
{
    public interface IModuleLifecycleContributor : ITransientDependency
    {
        void Initialize([NotNull] AppInitContext context, [NotNull] IModule module);

        void Shutdown([NotNull] AppShutdownContext context, [NotNull] IModule module);
    }
}
