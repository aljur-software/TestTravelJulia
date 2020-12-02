using Core.BaseClasses;
using System;

namespace Core.Interfaces
{
    public interface IUnitOfWork: IDisposable 
    {
        public IBaseRepository<T> Repository<T>() where T : BaseEntity;
    }
}
