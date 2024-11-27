using System.Linq.Expressions;

namespace HotelManagementSystem.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        Task<TType> GetByIdAsync(TId id);

        Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate);

        Task<IEnumerable<TType>> GetAllAsync();

        IQueryable<TType> GetAllAttached();

        Task AddAsync(TType item);

        Task AddRangeAsync(TType[] items);

        Task<bool> DeleteAsync(TType entity);

        Task<bool> UpdateAsync(TType item);
    }
}
