using Core.BaseClasses;
using Core.Interfaces;
using DataLayerEF.Entities;
using DataLayerEF.Repositories;
using System;
using System.Collections.Generic;

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
                if (typeof(T) == typeof(Agency))
                {
                    repositories.Add(type, new AgencyRepository(_context));
                }
                else if (typeof(T) == typeof(Agent))
                {
                    repositories.Add(type, new AgentRepository(_context));
                }
            }
            return (IBaseRepository<T>)repositories[type]; 
            /*
            var type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repoType = typeof(IBaseRepository<T>);
                var repoInstance = Activator.CreateInstance(repoType.MakeGenericType(typeof(T)), _context);
                repositories.Add(type, repoInstance);
            }
            return (IBaseRepository<T>)repositories[type];
            */
        }
    }
}
