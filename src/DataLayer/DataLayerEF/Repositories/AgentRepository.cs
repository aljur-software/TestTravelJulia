using Core.Common;
using Core.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayerEF.Repositories
{
    public class AgentRepository : IBaseRepository<Agent>
    {
        private readonly AppEFContext _context;

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

        public async Task<Agent> GetEntityById(int id)
        {
            var agent = await _context.Agents.FindAsync(id);
            return (agent != null) ? agent : throw new AgentNotFoundException();
        }

        public async Task<Agent> InsertEntity(Agent entity)
        {
            _context.Agents.Add(entity);
            var rowsAffected = await _context.SaveChangesAsync();
            return (rowsAffected > 0) ? entity : throw new AgentWasNotInserted();
        }

        public async Task UpdateEntity(Agent entity)
        {
            _context.Agents.Update(entity);
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected < 1) throw new AgentWasNotUpdated();
        }
    }
}
