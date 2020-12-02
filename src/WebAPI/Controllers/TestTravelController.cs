using Domain;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestTravelController : ControllerBase
    {
        private readonly ILogger<TestTravelController> _logger;
        private readonly IAgencyService _agencyService;


        public TestTravelController(IAgencyService agencyService, ILogger<TestTravelController> logger)
        {
            _agencyService = agencyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AgencyModel>> GetAgencies()
        {
           return await _agencyService.GetAgenciesFullInfo();
        }

        [HttpPost]
        public async Task AddAgentToAgency(int agencyId, AgentModel agentModel)
        {
            await _agencyService.AddAgentToAgency(agencyId, agentModel);
        }

        [HttpPost]
        public async Task<ImportResult> ImportAgenciesWithAgents()
        {
            return await _agencyService.ImportAgenciesWithAgents(new List<AgencyModel>());
        }
    }
}

