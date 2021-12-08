using gm.di;
using gm.modularity;
using gm.system.extentions;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace gm.core
{
    /// <summary>
    /// app product
    /// </summary>
    public abstract class AppBase : IApp
    {
        [NotNull]
        public Type StartupModule { get; }

        public IServiceProvider ServiceProvider { get; private set; }
        public IServiceCollection Services { get; }
        public IReadOnlyList<IModuleDescriptor> Modules { get; }

        internal AppBase(
           [NotNull] Type startupModule,
           [NotNull] IServiceCollection services,
           [CanBeNull] Action<AppCreationOptions> action)
        {
            StartupModule = startupModule;
            Services = services;

            //services.TryAddObjectAccessor<IServiceProvider>();

            var options = new AppCreationOptions(services);
            action?.Invoke(options);

            services.AddSingleton<IApp>(this);
            services.AddSingleton<IModuleContainer>(this);

            services.AddMicroSoftServices(this, options);

            Modules = LoadModules(services, options);
            ConfigureServices();

        }

        protected virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>().Value = ServiceProvider;
        }

        protected virtual void InitializeModules()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .InitModules(new AppInitContext(scope.ServiceProvider));
            }
        }

        protected virtual IReadOnlyList<IModuleDescriptor> LoadModules(IServiceCollection services, AppCreationOptions options)
        {
            return services
                .GetSingletonInstance<IModuleLoader>()
                .LoadModules(
                    services,
                    StartupModule,
                    options.PlugInList
                );
        }


        public virtual void Dispose()
        {
        }

        public void Shutdown()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .ShutdownModules(new AppShutdownContext(scope.ServiceProvider));
            }
        }

        protected virtual void ConfigureServices()
        {
            var context = new ServiceCfgContext(Services);
            Services.AddSingleton(context);

            foreach (var module in Modules)
            {
                if (module.Instance is ModuleBaba ModuleBaba) ModuleBaba.ServiceCfgContext = context;
            }

            //PreConfigureServices
            foreach (var module in Modules.Where(m => m.Instance is IPreConfigureServices))
            {
                ((IPreConfigureServices)module.Instance).PreConfigureServices(context);
            }

            //ConfigureServices
            //foreach (var module in Modules)
            //{
            //    if (module.Instance is ModuleBaba ModuleBaba)
            //    {
            //        if (!ModuleBaba.SkipAutoServiceRegistration) Services.AddAssembly(module.Type.Assembly);
            //    }

            //    module.Instance.ConfigureServices(context);
            //}

            //PostConfigureServices
            foreach (var module in Modules.Where(m => m.Instance is IPostConfigureServices))
            {
                ((IPostConfigureServices)module.Instance).PostConfigureServices(context);
            }

            foreach (var module in Modules)
            {
                if (module.Instance is ModuleBaba ModuleBaba)
                {
                    ModuleBaba.ServiceCfgContext = null;
                }
            }
        }
    }
}
