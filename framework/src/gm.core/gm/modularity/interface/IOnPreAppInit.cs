using JetBrains.Annotations; 

namespace gm.modularity
{
    public interface IOnPreAppInit
    {
        void OnPreAppInit([NotNull] AppInitContext context);
    }
}
