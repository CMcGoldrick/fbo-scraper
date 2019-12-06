using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxbetScrapeAPI.Models;
using HtmlAgilityPack;
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

            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            var events = new List<Event>();
            
            HtmlWeb website = new HtmlWeb();
            website.AutoDetectEncoding = false;
            website.OverrideEncoding = Encoding.Default;
            HtmlDocument Doc = website.Load("https://localhost:44363/");
            //var tabla = Doc.DocumentNode.Descendants(“table”).Where(d => d.Attributes.Contains(“class”) && d.Attributes[“class”].Value.Contains(“product-list”)).First();

            var table = Doc.DocumentNode.Descendants("table").First();
            var tableRows = Doc.DocumentNode.Descendants("table").First().ChildNodes.Where(r => r.Name == "tr");
            var tds = tableRows.Select(r => r.ChildNodes.Where(s => s.Name == "td")).ToList();
            tds.RemoveAt(0);
 
            foreach (var td in tds)
            {
                foreach(var innerHtml in td)
                {
                    events.Add(new Event
                    {
                        Id = Int32.Parse(innerHtml.InnerHtml),

                    });
                }
            }

            return events;
        }
    }
}
