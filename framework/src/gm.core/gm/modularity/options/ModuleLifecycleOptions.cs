
using gm.collection;

namespace gm.modularity
{
    public class ModuleLifecycleOptions
    {
        public ITypeList<IModuleLifecycleContributor> Contributors { get; }

        public ModuleLifecycleOptions()
        {
            Contributors = new TypeList<IModuleLifecycleContributor>();
        }
    }
}
