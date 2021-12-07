using JetBrains.Annotations; 

namespace gm.modularity
{
    public interface IPlugIn
    {
        [NotNull]
        Type[] GetPlugIns();
    }
}
