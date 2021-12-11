
namespace gm.domain.entities.auditing
{
    [Serializable]
    public abstract class DeleteEntity<TUser> : ModifyEntity<TUser>
    {
        public virtual bool IsDeleted { get; set; }

        public virtual Guid? DeleterId { get; set; }

        public virtual DateTime? DeletionTime { get; set; }

        public virtual TUser? Deleter { get; set; }

    }
}
