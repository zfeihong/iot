
namespace gm.domain.entities
{
    [Serializable]
    public abstract class Entity : IEntity
    {
        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Keys = {GetKeys().JoinAsString(", ")}";
        }

        public abstract object[] GetKeys();
    }


    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }

        protected Entity(TKey id)
        {
            Id = id;
        }

        public object[] GetKeys()
        {
            return new object[] { Id };
        }

        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Id = {Id}";
        }
    }
}
