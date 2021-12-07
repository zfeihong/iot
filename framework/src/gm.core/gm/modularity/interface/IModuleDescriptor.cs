using System.Reflection;

namespace gm.modularity
{
    public interface IModuleDescriptor
    {
        Type Type { get; }

        Assembly Assembly { get; }

        IModule Instance { get; }

        bool IsPlugIn { get; }

        IReadOnlyList<IModuleDescriptor> Dependencies { get; }
    }
}
