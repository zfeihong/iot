
namespace gm.domain.entities
{
    public interface IAggregateRoot : IEntity
    {

    }

    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
    {

    }
}
