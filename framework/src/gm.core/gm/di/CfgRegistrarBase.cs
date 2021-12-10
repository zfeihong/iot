using gm.modularity;
using gm.system.extentions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace gm.di
{
    public abstract class CfgRegistrarBase : ICfgRegistrar
    {
        public virtual void AddAssembly(IServiceCollection services, Assembly assembly)
        {
            var types = AssemblyHelper
                .GetAllTypes(assembly)
                .Where(
                    type => type != null &&
                            type.IsClass &&
                            !type.IsAbstract &&
                            !type.IsGenericType
                ).ToArray();

            AddTypes(services, types);
        }

        public virtual void AddTypes(IServiceCollection services, params Type[] types)
        {
            foreach (var type in types)
                AddType(services, type);
        }

        public abstract void AddType(IServiceCollection services, Type type);

        protected virtual bool IsCfgRegistrationDisabled(Type type)
        {
            return type.IsDefined(typeof(DisableCfgRegistrationAttribute), true);
        }

        protected virtual void TriggerServiceExposing(IServiceCollection services, Type implementationType, List<Type> serviceTypes)
        {
            var exposeActions = services.GetExposingActionList();
            if (exposeActions.Any())
            {
                var args = new OnServiceExposingContext(implementationType, serviceTypes);
                foreach (var action in exposeActions)
                    action(args);
            }
        }
    }
}
