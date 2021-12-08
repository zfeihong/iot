using JetBrains.Annotations;

namespace gm.modularity
{
    public class AppInitContext
    {
        public IServiceProvider ServiceProvider { get; set; }

        public AppInitContext([NotNull] IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
