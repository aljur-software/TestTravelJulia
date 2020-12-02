using Domain;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        [ProducesResponseType(typeof(List<AgencyModel>), 200)]
        public async Task<IActionResult> GetAgencies()
        {
            try
            {
                return Ok(await _agencyService.GetAgenciesFullInfo());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + "; " + ex.InnerException?.Message);
                return BadRequest(ex.Message + "; " + ex.InnerException?.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddAgentToAgency(int agencyId, AgentModel agentModel)
        {
            try
            {
                await _agencyService.AddAgentToAgency(agencyId, agentModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + "; " + ex.InnerException?.Message);
                return BadRequest(ex.Message + "; " + ex.InnerException?.Message);
            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(ImportResult), 200)]
        public async Task<IActionResult> ImportAgenciesWithAgents()
        {
            try
            {
                return Ok(await _agencyService.ImportAgenciesWithAgents(new List<AgencyModel>()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + "; " + ex.InnerException?.Message);
                return BadRequest(ex.Message + "; " + ex.InnerException?.Message);
            }
        }
    }
}

