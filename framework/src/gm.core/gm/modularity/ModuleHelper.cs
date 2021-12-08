using System.Reflection;

namespace gm.modularity
{
    public class ModuleHelper
    {
        public static List<Type> FindAllModules(Type startupModule)
        {
            var moduleTypes = new List<Type>();
            AddModuleAndDependenciesResursively(moduleTypes, startupModule);
            return moduleTypes;
        }

        private static void AddModuleAndDependenciesResursively(List<Type> modules, Type moduleType)
        {
            CheckModuleType(moduleType);

            if (modules.Contains(moduleType))
                return;

            modules.Add(moduleType);

            foreach (var dependedModule in FindDependedModules(moduleType))
                AddModuleAndDependenciesResursively(modules, dependedModule);
        }

        internal static void CheckModuleType(Type module)
        {
            if (!IsModule(module))
            {
                throw new ArgumentException("Given type is not an Gm module: " + module.AssemblyQualifiedName);
            }
        }

        internal static bool IsModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(IModule).GetTypeInfo().IsAssignableFrom(type);
        }

        public static List<Type> FindDependedModules(Type moduleType)
        {
            CheckModuleType(moduleType);

            var dependencies = new List<Type>();

            var dependencyDescriptors = moduleType
                .GetCustomAttributes()
                .OfType<IDependedProvider>();

            foreach (var descriptor in dependencyDescriptors)
            {
                foreach (var dependedModuleType in descriptor.GetDependeds())
                {
                    dependencies.AddIfNotContains(dependedModuleType);
                }
            }

            return dependencies;
        }
    }
}
