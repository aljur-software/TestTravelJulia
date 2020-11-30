using Core.BaseClasses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerEF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppEFContext _context;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public UnitOfWork(AppEFContext context)
        {
            _context = context;
            repositories = new Dictionary<string, object>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public IBaseRepository<T> Repository<T>() where T : BaseEntity
        {
            var type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repoType = typeof(IBaseRepository<>);
                var repoInstance = Activator.CreateInstance(repoType.MakeGenericType(typeof(T)), _context);
                repositories.Add(type, repoInstance);
            }
            return (IBaseRepository<T>)repositories[type];
        }
    }
}
