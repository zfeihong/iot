
namespace gm.di
{
    public interface IOnServiceExposingContext
    {
        Type ImplementationType { get; }

        List<Type> ExposedTypes { get; }
    }
}
