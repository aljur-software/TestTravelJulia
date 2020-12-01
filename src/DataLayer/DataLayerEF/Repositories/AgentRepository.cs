using Core.Interfaces;
using DataLayerEF.Entities;
using Microsoft.EntityFrameworkCore;
//using StructureMap;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayerEF.Repositories
{
    public class AgentRepository : IBaseRepository<Agent>
    {
        private readonly AppEFContext _context;

        //[DefaultConstructor]
        public AgentRepository(AppEFContext context)
        {
            _context = context;
        }
        public async Task<List<Agent>> GetEntities()
        {
            return await _context.Agents.Include(_ => _.Agencies).Include(_ => _.Contacts).ToListAsync<Agent>();
        }

        public async Task<List<Agent>> GetFlatEntities()
        {
            return await _context.Agents.ToListAsync<Agent>();
        }

        public async Task UpdateEntity(Agent entity)
        {
            _context.Agents.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
