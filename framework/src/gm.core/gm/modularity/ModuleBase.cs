using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace gm.modularity
{
    public abstract class ModuleBase : IModule
    {
        protected internal ServiceCfgContext ServiceCfgContext
        {
            get{ return _srvCfgContext; }
            internal set => _srvCfgContext = value;
        }

        private ServiceCfgContext _srvCfgContext;

        protected internal bool SkipAutoServiceRegistration { get; protected set; }


        public void OnPreAppInit([NotNull] AppInitContext context)
        {

        }

        public void OnAppInit([NotNull] AppInitContext context)
        {

        }

        public void OnPostAppInit([NotNull] AppInitContext context)
        {

        }

        public void PreCfgServices(ServiceCfgContext context)
        {

        }

        public void CfgService(ServiceCfgContext context)
        {

        }
        public void PostCfgServices(ServiceCfgContext context)
        {

        }

        public void OnAppShutdown([NotNull] AppShutdownContext context)
        {

        }


        protected void Configure<TOptions>(Action<TOptions> options)
            where TOptions : class
        {
            ServiceCfgContext.Services.Configure(options);
        }

        protected void Configure<TOptions>(string name, Action<TOptions> options)
            where TOptions : class
        {
            ServiceCfgContext.Services.Configure(name, options);
        }

        protected void PreConfigure<TOptions>(Action<TOptions> options)
            where TOptions : class
        {
            //ServiceCfgContext.Services.PreConfigure(options);
        }

        protected void PostConfigure<TOptions>(Action<TOptions> options)
            where TOptions : class
        {
            ServiceCfgContext.Services.PostConfigure(options);
        }

        protected void PostConfigureAll<TOptions>(Action<TOptions> options)
            where TOptions : class
        {
            ServiceCfgContext.Services.PostConfigureAll(options);
        }
    }
}
