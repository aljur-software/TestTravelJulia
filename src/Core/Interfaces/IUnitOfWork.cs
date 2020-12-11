using Core.BaseClasses;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IUnitOfWork: IDisposable 
    {
        public IBaseRepository<T> Repository<T>() where T : BaseEntity;
        public void BulkInsert<T>(List<T> data) where T : BaseEntity;
        public void BulkInsert(string table, string filePath);
    }
}
