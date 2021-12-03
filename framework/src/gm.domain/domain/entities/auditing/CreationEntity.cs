using gm.domain.entities;
 

namespace gm.domain.entities.auditing
{
    [Serializable]
    public abstract class CreationEntity<TUser> : Entity
    {
        public virtual DateTime CreationTime { get; set; }

        public virtual Guid? CreatorId { get; set; }

        public virtual TUser? Creator { get; set; }

    }
}
