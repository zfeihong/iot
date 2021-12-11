using gm.core;
using gm.modularity;
using gm.system.configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace gm.system.extentions
{
    internal static class AppBaseExtensions
    {
        internal static void AddCoreServices(this IServiceCollection services,
           IApp app,
           AppCreationOptions options)
        {
            //Microsoft
            services.AddOptions();
            services.AddLogging();
            services.AddLocalization();

            //Gm
            var moduleLoader = new ModuleLoader();
            var assemblyFinder = new AssemblyFinder(app);
            var typeFinder = new TypeFinder(assemblyFinder);

            if (!services.IsAdded<IConfiguration>())
                services.ReplaceConfiguration(CfgHelper.BuildConfiguration(options.Configuration));

            services.TryAddSingleton<IModuleLoader>(moduleLoader);
            services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
            services.TryAddSingleton<ITypeFinder>(typeFinder);

            services.AddAssemblyOf<IApp>();

            //services.Configure<ModuleLifecycleOptions>(options =>
            //{
            //    //options.Contributors.Add<OnPreAppInitModuleLifecycleContributor>();
            //    //options.Contributors.Add<OnAppInitModuleLifecycleContributor>();
            //    //options.Contributors.Add<OnPostAppInitModuleLifecycleContributor>();
            //    //options.Contributors.Add<OnAppShutdownModuleLifecycleContributor>();
            //});
        }


    }
}
