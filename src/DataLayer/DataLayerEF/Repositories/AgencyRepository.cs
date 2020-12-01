using Core.Interfaces;
using DataLayerEF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayerEF.Repositories
{
    public class AgencyRepository : IBaseRepository<Agency>
    {
        private readonly AppEFContext _context;

        //[DefaultConstructor]
        public AgencyRepository(AppEFContext context)
        {
            _context = context;
        }
        public async Task<List<Agency>> GetEntities()
        {
            return await _context.Agencies.Include(_ => _.Agents).Include(_ => _.Contacts).ToListAsync<Agency>();
        }

        public async Task<List<Agency>> GetFlatEntities()
        {
            return await _context.Agencies.ToListAsync<Agency>();
        }

        public async Task UpdateEntity(Agency entity)
        {
            _context.Agencies.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
