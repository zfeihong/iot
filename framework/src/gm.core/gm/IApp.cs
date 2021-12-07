using gm.modularity;
using Microsoft.Extensions.DependencyInjection;
 
namespace gm.core
{
    public interface IApp : IModuleContainer, IDisposable
    {
        Type StartupModule { get; }

        IServiceCollection Services { get; }

        IServiceProvider ServiceProvider { get; }

        void Shutdown();
    }
}
