using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace gm.modularity
{
    /// <summary>
    /// module root
    /// </summary>
    public abstract class ModuleBaba : IModule
    {
        protected internal ServiceCfgContext ServiceCfgContext
        {
            get{ return _srvCfgContext; }
            internal set => _srvCfgContext = value;
        }

        private ServiceCfgContext _srvCfgContext;

        protected internal bool SkipAutoServiceRegistration { get; protected set; }


        public virtual void OnPreAppInit([NotNull] AppInitContext context)
        {

        }

        public virtual void OnAppInit([NotNull] AppInitContext context)
        {

        }

        public virtual void OnPostAppInit([NotNull] AppInitContext context)
        {

        }

        public virtual void PreCfgServices(ServiceCfgContext context)
        {

        }

        public virtual void CfgService(ServiceCfgContext context)
        {

        }
        public virtual void PostCfgServices(ServiceCfgContext context)
        {

        }

        public virtual void OnAppShutdown([NotNull] AppShutdownContext context)
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
