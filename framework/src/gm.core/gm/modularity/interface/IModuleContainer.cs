using JetBrains.Annotations;

namespace gm.modularity
{
    public interface IModuleContainer
    {
        [NotNull]
        IReadOnlyList<IModuleDescriptor> Modules { get; }
    }
}
