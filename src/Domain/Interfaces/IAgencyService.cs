using Domain.Entities;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAgencyService
    {
        Task<bool> AddAgentToAgency(int agencyId, AgentModel agent);
        Task<List<AgencyModel>> GetAgenciesFullInfo();
        Task<ImportResult> ImportAgenciesWithAgents(List<Agency> agencies);
        Task<ImportResult> ImportAgenciesWithAgents(KeyValuePair<string, string> agencies);
    }
}
