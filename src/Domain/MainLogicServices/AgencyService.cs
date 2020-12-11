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
                var agentEntity = ModelToEntityConverters.AgentModelToEntity(agent);
                var agency = await _unitOfWork.Repository<Agency>().GetEntityById(agencyId);
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
            var agencyModels = agencies.Select(_ => EntityToModelConverters.AgencyEntityToModel(_)).ToList();
            return agencyModels;
        }

        public async Task<ImportResult> ImportAgenciesWithAgents(List<Agency> agencies)
        {
            //throw new NotImplementedException();

            _unitOfWork.BulkInsert<Agency>(agencies);
            return new ImportResult();
        }

        public async Task<ImportResult> ImportAgenciesWithAgents(KeyValuePair<string, string> pair)
        {
            //_unitOfWork.BulkInsert<Agency>(agencies);
            switch (pair.Key)
            {
                case "agencyCSVFilePath":
                    _unitOfWork.BulkInsert("Agency", pair.Value);
                    break;
                case "agencyContactCSVFilePath":
                    _unitOfWork.BulkInsert("Contact", pair.Value);
                    break;
                case "agentsCSVFilePath":
                    _unitOfWork.BulkInsert("Agent", pair.Value);
                    break;
                case "agentContactsCSVFilePath":
                    _unitOfWork.BulkInsert("Contact", pair.Value);
                    break;
                case "agentsToAgenciesCSVFilePath":
                    _unitOfWork.BulkInsert("AgencyAgent", pair.Value);
                    break;
            }
            return new ImportResult();
        }
    }
}
