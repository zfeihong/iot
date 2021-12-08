using gm.core;
using gm.modularity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace gm.system.extentions
{
    internal static class ServiceCollectionExtensions
    {
        internal static void AddMicroSoftServices(this IServiceCollection services, IApp app, AppCreationOptions options)
        {
            services.AddOptions();
            services.AddLogging();
            services.AddLocalization();

            AddGmServices(services, app, options);
        }

        internal static void AddGmServices(this IServiceCollection services,
           IApp app,
           AppCreationOptions options)
        {
            var moduleLoader = new ModuleLoader();
            var assemblyFinder = new AssemblyFinder(app);
            var typeFinder = new TypeFinder(assemblyFinder);

            //if (!services.IsAdded<IConfiguration>())
            //{
            //    services.ReplaceConfiguration(
            //        ConfigurationHelper.BuildConfiguration(
            //            options.Configuration
            //        )
            //    );
            //}

            services.TryAddSingleton<IModuleLoader>(moduleLoader);
            services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
            services.TryAddSingleton<ITypeFinder>(typeFinder);

            //services.AddAssemblyOf<IApp>();

            //services.Configure<AbpModuleLifecycleOptions>(options =>
            //{
            //    options.Contributors.Add<OnPreApplicationInitializationModuleLifecycleContributor>();
            //    options.Contributors.Add<OnApplicationInitializationModuleLifecycleContributor>();
            //    options.Contributors.Add<OnPostApplicationInitializationModuleLifecycleContributor>();
            //    options.Contributors.Add<OnApplicationShutdownModuleLifecycleContributor>();
            //});
        }


    }
}
