using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace gm.modularity
{
    public class ServiceCfgContext
    {
        public IServiceCollection Services { get; }
        public IDictionary<string, object> Items { get; }

        public object this[string key]
        {
            get { return Items[key]; }
            set { Items[key] = value; }
        }
        public ServiceCfgContext([NotNull] IServiceCollection services)
        {
            Services = services;
            Items = new Dictionary<string, object>();
        }
    }
}
