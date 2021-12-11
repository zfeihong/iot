using JetBrains.Annotations;

namespace gm.modularity
{
    public interface IRelyOnProvider
    {
        [NotNull]
        Type[] GetRelyOnTypes();
    }
}
