using Core.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Converters;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Core.Common;

namespace Domain.MainLogicServices
{
    public class AgencyService : IAgencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AgencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddAgentToAgency(int agencyId, AgentModel agent)
        {
            try
            {
                var agentEntity = ModelToEFConverters.AgentModelToEF(agent);
                var agency = await _unitOfWork.Repository<Agency>().GetEntityById(agencyId);
                if (agency == null) throw new AgecyNotFoundException();
                agency.Agents.Add(agentEntity);
                await _unitOfWork.Repository<Agency>().UpdateEntity(agency);
                return true;
            }
            catch (Exception ex)
            {
                throw new AgencyWasNotUpdated(String.Format("agencyId = {0}", agencyId), ex);
            }

        }

        public async Task<List<AgencyModel>> GetAgenciesFullInfo()
        {
            var agencies = await _unitOfWork.Repository<Agency>().GetEntities();
            var agencyModels = agencies.Select(_ => EFToModelConverters.AgencyEFToModel(_)).ToList();
            return agencyModels;
        }

        public async Task<ImportResult> ImportAgenciesWithAgents(List<AgencyModel> agencies)
        {
            throw new NotImplementedException();
        }
    }
}
