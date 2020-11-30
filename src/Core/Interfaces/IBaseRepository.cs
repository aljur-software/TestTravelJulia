using Core.BaseClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetFlatEntities();
        Task<List<T>> GetEntities();
        Task UpdateEntity(T entity);
    }
}
