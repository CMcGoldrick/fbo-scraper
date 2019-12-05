using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoxbetScrapeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace FoxbetScrapeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoxBet : ControllerBase
    {
        private readonly ILogger<FoxBet> _logger;

        public FoxBet(ILogger<FoxBet> logger)
        {
            var event1 = new Event()
            {
                AwayTeam = "Ajax",
                HomeTeam = "PSV",
                OfferId = 1,
                dateTime = DateTime.Now            
            };
            var event2 = new Event()
            {
                AwayTeam = "Chelsea",
                HomeTeam = "WestHam",
                OfferId = 2,
                dateTime = DateTime.Now
            };
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {

        }
    }
}
