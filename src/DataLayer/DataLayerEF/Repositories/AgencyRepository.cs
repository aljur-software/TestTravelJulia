using Core.Common;
using Core.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayerEF.Repositories
{
    public class AgencyRepository : IBaseRepository<Agency>
    {
        private readonly AppEFContext _context;

        public AgencyRepository(AppEFContext context)
        {
            _context = context;
        }
        public async Task<List<Agency>> GetEntities()
        {
            return await _context.Agencies.Include(_ => _.Contacts).Include(_ => _.Agents).ThenInclude(a => a.Contacts).ToListAsync<Agency>();
        }

        public async Task<List<Agency>> GetFlatEntities()
        {
            return await _context.Agencies.ToListAsync<Agency>();
        }

        public async Task<Agency> GetEntityById(int id)
        {
            var agency = await _context.Agencies.FindAsync(id);
            return (agency != null) ? agency : throw new AgecyNotFoundException(); 
        }

        public async Task<Agency> InsertEntity(Agency entity)
        {
            _context.Agencies.Add(entity);
            var rowsAffected = await _context.SaveChangesAsync();
            return (rowsAffected > 0) ? entity : throw new AgencyWasNotInserted();            
        }

        public async Task UpdateEntity(Agency entity)
        {
            _context.Agencies.Update(entity);
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected < 1) throw new AgencyWasNotUpdated();
        }
    }
}
