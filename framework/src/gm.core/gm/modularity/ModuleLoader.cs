using gm.system.extentions;
using Microsoft.Extensions.DependencyInjection;

namespace gm.modularity
{
    public class ModuleLoader : IModuleLoader
    {
        public IModuleDescriptor[] LoadModules(
            IServiceCollection services,
            Type startupModule,
            PlugInList plugInList)
        { 
            var modules = GetDescriptors(services, startupModule, plugInList);

            modules = SortByDependency(modules, startupModule);

            return modules.ToArray();
        }

        private List<IModuleDescriptor> GetDescriptors(
            IServiceCollection services,
            Type startupModule,
            PlugInList plugInList)
        {
            var modules = new List<ModuleDescriptor>();

            FillModules(modules, services, startupModule, plugInList);
            SetDependencies(modules);

            return modules.Cast<IModuleDescriptor>().ToList();
        }

        protected virtual void FillModules(
            List<ModuleDescriptor> modules,
            IServiceCollection services,
            Type startupModuleType,
            PlugInList plugInList)
        {
            foreach (var moduleType in ModuleHelper.FindAllModules(startupModuleType))
            {
                modules.Add(CreateModuleDescriptor(services, moduleType));
            }

            foreach (var moduleType in plugInList.GetAllModules())
            {
                if (modules.Any(m => m.Type == moduleType))
                    continue;

                modules.Add(CreateModuleDescriptor(services, moduleType, isLoadedAsPlugIn: true));
            }
        }

        protected virtual void SetDependencies(List<ModuleDescriptor> modules)
        {
            foreach (var module in modules)
            {
                SetDependencies(modules, module);
            }
        }

        protected virtual List<IModuleDescriptor> SortByDependency(List<IModuleDescriptor> modules, Type startupModuleType)
        {
            var sortedModules = modules.SortByDependencies(m => m.Dependencies);
            sortedModules.MoveItem(m => m.Type == startupModuleType, modules.Count - 1);
            return sortedModules;
        }

        protected virtual ModuleDescriptor CreateModuleDescriptor(IServiceCollection services, Type moduleType, bool isLoadedAsPlugIn = false)
        {
            return new ModuleDescriptor(moduleType, CreateAndRegisterModule(services, moduleType), isLoadedAsPlugIn);
        }

        protected virtual IModule CreateAndRegisterModule(IServiceCollection services, Type moduleType)
        {
            var module = (IModule)Activator.CreateInstance(moduleType);

            if (module == null)
                throw new Exception("Could not find a depended module");

            services.AddSingleton(moduleType, module);
            return module;
        }

        protected virtual void SetDependencies(List<ModuleDescriptor> modules, ModuleDescriptor descriptors)
        {
            foreach (var dependedModule in ModuleHelper.FindDependedModules(descriptors.Type))
            {
                var module = modules.FirstOrDefault(m => m.Type == dependedModule);
                if (module == null)
                    throw new Exception("Could not find a depended module " + dependedModule.AssemblyQualifiedName + " for " + module.Type.AssemblyQualifiedName);

                descriptors.AddDependency(module);
            }
        }
    }
}
