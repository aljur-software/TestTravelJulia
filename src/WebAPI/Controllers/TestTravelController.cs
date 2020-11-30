using Core.Interfaces;
using DataLayerEF.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
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
        public async Task<IEnumerable<Agency>> Get()
        {
            var agencies = await _unitOfWork.Repository<Agency>().GetEntities();

            if (agencies.Count < 1)
                agencies.Add(new Agency
                {
                    Id = 0,
                    Name = "TestAgency",
                    Description = "Bla-Bla",
                    Address = "somewhere",
                    Contacts = new List<Contact> { new Contact { Id = -1, Type = ContactType.Email, Value = "JUK@gmail.com" } }
                }) ;
            
            return agencies.ToArray();
            /*var rng = new Random();            
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
    }
}
