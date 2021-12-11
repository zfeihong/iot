using System.Reflection;

namespace gm.modularity
{
    public class ModuleHelper
    {
        public static List<Type> FindAllModules(Type startupModule)
        {
            var moduleTypes = new List<Type>();
            AddModuleAndRelyResursively(moduleTypes, startupModule);
            return moduleTypes;
        }

        private static void AddModuleAndRelyResursively(List<Type> modules, Type moduleType)
        {
            CheckModuleType(moduleType);

            if (modules.Contains(moduleType))
                return;

            modules.Add(moduleType);

            foreach (var relyModule in FindRelyModules(moduleType))
                AddModuleAndRelyResursively(modules, relyModule);
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

        public static List<Type> FindRelyModules(Type moduleType)
        {
            CheckModuleType(moduleType);

            var rely = new List<Type>();

            var relyDescriptors = moduleType
                .GetCustomAttributes()
                .OfType<IRelyOnProvider>();

            foreach (var descriptor in relyDescriptors)
            {
                foreach (var relyModuleType in descriptor.GetRelyOnTypes())
                {
                    rely.AddIfNotContains(relyModuleType);
                }
            }

            return rely;
        }
    }
}
