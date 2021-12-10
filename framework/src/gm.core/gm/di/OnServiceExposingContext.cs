using JetBrains.Annotations;

namespace gm.di
{
    public class OnServiceExposingContext : IOnServiceExposingContext
    {
        public Type ImplementationType { get; }

        public List<Type> ExposedTypes { get; }

        public OnServiceExposingContext([NotNull] Type implementationType, List<Type> exposedTypes)
        {
            ImplementationType = implementationType;
            ExposedTypes = exposedTypes;
        }
    }
}
