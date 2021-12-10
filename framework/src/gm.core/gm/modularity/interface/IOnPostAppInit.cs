using JetBrains.Annotations; 

namespace gm.modularity
{
    public interface IOnPostAppInit
    {
        void OnPostAppInit([NotNull] AppInitContext context);
    }
}
