

using System.Linq.Expressions;

namespace gm.domain.repositories
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        #region Get
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,bool includeDetails = true,CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetPagedListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            bool includeDetails = false,
            CancellationToken cancellationToken = default);

        #endregion

        Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate,bool autoSave = false,CancellationToken cancellationToken = default);

    }

    public interface IRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);

        Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default); 
         
        Task DeleteManyAsync(IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = default);
    }
}
