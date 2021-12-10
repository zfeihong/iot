using JetBrains.Annotations; 

namespace gm.modularity
{
    public interface IOnAppShutdown
    {
        void OnAppShutdown([NotNull] AppShutdownContext context);
    }
}
