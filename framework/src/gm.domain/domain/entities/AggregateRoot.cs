

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace gm.domain.entities
{
    [Serializable]
    public abstract class AggregateRoot : Entity,
       IAggregateRoot,
       IDomainEvents,
       IConcurrencyStamp
    {
        public virtual Dictionary<string, object> ExtraProperties { get; protected set; }
        public virtual string ConcurrencyStamp { get; set; }

        private readonly ICollection<object> _localEvents = new Collection<object>();
        private readonly ICollection<object> _distributedEvents = new Collection<object>();

        protected AggregateRoot()
        {
            ConcurrencyStamp = Guid.NewGuid().ToString("N");
            ExtraProperties = new Dictionary<string, object>();
        }

        #region Event
        protected virtual void AddLocalEvent(object eventData)
        {
            _localEvents.Add(eventData);
        }

        protected virtual void AddDistributedEvent(object eventData)
        {
            _distributedEvents.Add(eventData);
        }

        public virtual IEnumerable<object> GetLocalEvents()
        {
            return _localEvents;
        }

        public virtual IEnumerable<object> GetDistributedEvents()
        {
            return _distributedEvents;
        }

        public virtual void ClearLocalEvents()
        {
            _localEvents.Clear();
        }

        public virtual void ClearDistributedEvents()
        {
            _distributedEvents.Clear();
        }
        #endregion
    }

    [Serializable]
    public abstract class AggregateRoot<TKey> : Entity<TKey>,
        IAggregateRoot<TKey>,
        IDomainEvents,
        IConcurrencyStamp
    {
        public virtual Dictionary<string, object> ExtraProperties { get; protected set; }
        public virtual string ConcurrencyStamp { get; set; }

        private readonly ICollection<object> _localEvents = new Collection<object>();
        private readonly ICollection<object> _distributedEvents = new Collection<object>();

        protected AggregateRoot(TKey id)
            : base(id)
        {
            ConcurrencyStamp = Guid.NewGuid().ToString("N");
            ExtraProperties = new Dictionary<string, object>();
        }

        #region Event

        protected virtual void AddLocalEvent(object eventData)
        {
            _localEvents.Add(eventData);
        }

        protected virtual void AddDistributedEvent(object eventData)
        {
            _distributedEvents.Add(eventData);
        }

        public virtual IEnumerable<object> GetLocalEvents()
        {
            return _localEvents;
        }

        public virtual IEnumerable<object> GetDistributedEvents()
        {
            return _distributedEvents;
        }

        public virtual void ClearLocalEvents()
        {
            _localEvents.Clear();
        }

        public virtual void ClearDistributedEvents()
        {
            _distributedEvents.Clear();
        }

        #endregion
    }
}
