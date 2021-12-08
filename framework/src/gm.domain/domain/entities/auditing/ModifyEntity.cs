
namespace gm.domain.entities.auditing
{
    [Serializable]
    public abstract class ModifyEntity<TUser> : CreationEntity<TUser>
    {
        public virtual DateTime? LastModificationTime { get; set; }

        public virtual Guid? LastModifierId { get; set; }

        public virtual TUser? LastModifier { get; set; }

    }
}
