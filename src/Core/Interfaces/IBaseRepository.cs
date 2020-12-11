using Core.BaseClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetFlatEntities();
        Task<List<T>> GetEntities();
        Task<T> GetEntityById(int id);
        Task<T> InsertEntity(T entity);
        Task<int> MultipleInsert(List<T> entities);
        Task UpdateEntity(T entity);
    }
}
