using Core.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork: IDisposable 
    {
        public IBaseRepository<T> Repository<T>() where T : BaseEntity;
    }
}
