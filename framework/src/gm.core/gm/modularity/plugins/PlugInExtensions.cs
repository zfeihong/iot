using JetBrains.Annotations;

namespace gm.modularity
{
    public static class PlugInExtensions
    {
        [NotNull]
        public static Type[] GetPluginWithAllDependencies([NotNull] this IPlugIn plugIn)
        {
            return plugIn
                .GetPlugIns()
                .SelectMany(ModuleHelper.FindAllModules)
                .Distinct()
                .ToArray();
        }
    }
}
