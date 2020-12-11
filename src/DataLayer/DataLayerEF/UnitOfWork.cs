using Core.BaseClasses;
using Core.Interfaces;
using DataLayerEF.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
        }

        public void BulkInsert<T>(List<T> data) where T: BaseEntity
        {           
            _context.Database.ExecuteSqlRaw("");
        }

        public void BulkInsert(string table_name, string pathToFile) 
        {
            _context.Database.ExecuteSqlRaw($"COPY \"{table_name}\" FROM '{pathToFile}' DELIMITER ',' CSV HEADER;");
        }

        /*private string PrepateQueryToBulkImport<T>(List<T> data) where T : BaseEntity
        { 

        }*/
    }
}
