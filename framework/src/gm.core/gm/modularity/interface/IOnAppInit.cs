using JetBrains.Annotations; 

namespace gm.modularity
{
    public interface IOnAppInit
    {
        void OnAppInit([NotNull] AppInitContext context);
    }
}
