using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gm.modularity
{
    public class ModuleDescriptor : IModuleDescriptor
    {
        public Type Type { get; }

        public Assembly Assembly { get; }

        public IModule Instance { get; }

        public bool IsPlugIn { get; }

        private readonly List<IModuleDescriptor> _dependencies;
        public IReadOnlyList<IModuleDescriptor> Dependencies
        {
            get { return _dependencies.ToImmutableList(); }
        }

        public ModuleDescriptor(
        [NotNull] Type type,
        [NotNull] IModule instance,
        bool isPlugIn)
        {

            if (!type.GetTypeInfo().IsAssignableFrom(instance.GetType()))
            {
                throw new ArgumentException($"Given module instance ({instance.GetType().AssemblyQualifiedName}) is not an instance of given module type: {type.AssemblyQualifiedName}");
            }

            Type = type;
            Assembly = type.Assembly;
            Instance = instance;
            IsPlugIn = isPlugIn;

            _dependencies = new List<IModuleDescriptor>();
        }

        public void AddDependency(IModuleDescriptor descriptor)
        {
            _dependencies.AddIfNotContains(descriptor);
        }

        public override string ToString()
        {
            return $"[ModuleDescriptor {Type.FullName}]";
        }
    }
}
