using JetBrains.Annotations; 

namespace gm.di
{
    public interface IObjectAccessor<out T>
    {
        [CanBeNull]
        T Value { get; }
    }
}
