using Core.Common;
using Core.Interfaces;
using DataLayerEF.Entities;
using Domain.Models;
using Infrastructure.Converters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestTravelController : ControllerBase
    {
        private readonly ILogger<TestTravelController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TestTravelController(IUnitOfWork unitOfWork, ILogger<TestTravelController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AgencyModel>> GetAgencies()
        {
            var agencies = await _unitOfWork.Repository<Agency>().GetEntities();
            var agencyModels = agencies.Select(_ => EFToModelConverters.AgencyEFToModel(_)).ToArray();
            return agencyModels;
        }

        [HttpGet]
        public async Task<IEnumerable<AgentModel>> GetAgents()
        {
            var agents = await _unitOfWork.Repository<Agent>().GetEntities();
            var agentModels = agents.Select(_ => EFToModelConverters.AgentEFToModel(_)).ToArray();
            return agentModels;
        }
    }
}

