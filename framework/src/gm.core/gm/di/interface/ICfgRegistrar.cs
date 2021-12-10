using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace gm.di
{
    public interface ICfgRegistrar
    {
        void AddAssembly(IServiceCollection services, Assembly assembly);

        void AddTypes(IServiceCollection services, params Type[] types);

        void AddType(IServiceCollection services, Type type);
    }
}
