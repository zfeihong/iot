namespace gm.domain.entities
{
    public interface IDomainEvents
    {
        IEnumerable<object> GetLocalEvents();

        IEnumerable<object> GetDistributedEvents();

        void ClearLocalEvents();

        void ClearDistributedEvents();
    }
}
