using gm.modularity;
using JetBrains.Annotations;

namespace gm.core
{
    public static class AppFactory
    {
        public static IAppInServiceProvider Create<TStartupModule>(
            [CanBeNull] Action<AppCreationOptions> optionsAction = null)
            where TStartupModule : class, IModule
        { 
            return new AppInServiceProvider(typeof(TStartupModule), optionsAction);
        }
    }
}
