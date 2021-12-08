using JetBrains.Annotations;

namespace gm.modularity
{
    public class PlugInList : List<IPlugIn>
    {
        [NotNull]
        internal Type[] GetAllModules()
        {
            return this
                 .SelectMany(plugin => plugin.GetPluginWithAllDependencies())
                 .Distinct()
                 .ToArray();
        }
    }
}
