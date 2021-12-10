using gm.di;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace gm.system.extentions
{
    public static class CfgRegistrationExtensions
    {
        public static IServiceCollection AddAssemblyOf<T>(this IServiceCollection services)
        {
            return services.AddAssembly(typeof(T).GetTypeInfo().Assembly);
        }

        public static IServiceCollection AddAssembly(this IServiceCollection services, Assembly assembly)
        {
            foreach (var registrar in services.GetCfgRegistrars())
            {
                registrar.AddAssembly(services, assembly);
            }

            return services;
        }

        public static List<ICfgRegistrar> GetCfgRegistrars(this IServiceCollection services)
        {
            return GetOrCreateRegistrarList(services);
        }

        private static CfgRegistrarList GetOrCreateRegistrarList(IServiceCollection services)
        {
            var cfgRegistrars = services.GetSingletonInstanceOrNull<IObjectAccessor<CfgRegistrarList>>()?.Value;
            if (cfgRegistrars == null)
            {
                cfgRegistrars = new CfgRegistrarList { new DefaultCfgRegistrar() };
                services.AddObjectAccessor(cfgRegistrars);
            }

            return cfgRegistrars;
        }

        public static ServiceExposingActionList GetExposingActionList(this IServiceCollection services)
        {
            return GetOrCreateExposingList(services);
        }

        private static ServiceExposingActionList GetOrCreateExposingList(IServiceCollection services)
        {
            var actionList = services.GetSingletonInstanceOrNull<IObjectAccessor<ServiceExposingActionList>>()?.Value;
            if (actionList == null)
            {
                actionList = new ServiceExposingActionList();
                services.AddObjectAccessor(actionList);
            }

            return actionList;
        }

    }
}
