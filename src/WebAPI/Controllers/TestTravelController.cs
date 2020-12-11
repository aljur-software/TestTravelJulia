using Domain;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Infrastructure.Serialization;
using Infrastructure.ZipReader;
using Domain.Entities;
using Infrastructure.DataPreparation;

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

        [HttpPost, DisableRequestSizeLimit, Route("file")]
        [ProducesResponseType(typeof(ImportResult), 200)]
        public async Task<IActionResult> ImportAgenciesWithAgents(IFormFile file)
        {
            try
            {
                var agencies = new List<Agency>();
                using (var stream = file.OpenReadStream())
                {
                    ZipReader<Agency> zipReader = new ZipReader<Agency>();
                    agencies = zipReader.ReadFromZip(stream);
                }
                var dataFilepaths = DataForBulkPreparer.SomeMethod(agencies);
                foreach (var item in dataFilepaths)
                {
                    await _agencyService.ImportAgenciesWithAgents(item);
                }

                return Ok(await _agencyService.ImportAgenciesWithAgents(agencies));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + "; " + ex.InnerException?.Message);
                return BadRequest(ex.Message + "; " + ex.InnerException?.Message);
            }
        }

       /* 
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GenerateTestXML()
        {
            for (int i = 1; i < 5; i++)
            {
                XMLModelSerializer<AgencyModel>.ToXMLTest(i);
            }
            return Ok();
        }*/
    }
}

