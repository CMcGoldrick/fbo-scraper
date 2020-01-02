using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxbetScrapeAPI.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using OpenQA.Selenium.PhantomJS;

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
        public async void Get()
        {
            var events = new List<Event>();

            //HtmlWeb website = new HtmlWeb();
            //website.AutoDetectEncoding = false;
            //website.OverrideEncoding = Encoding.Default;
            //HtmlDocument Doc = website.Load("https://localhost:44363/");
            //HtmlDocument Doc = website.Load("https://mtairycasino.foxbet.com/#/american_football/competitions/8169879");
            //var tabla = Doc.DocumentNode.Descendants(“table”).Where(d => d.Attributes.Contains(“class”) && d.Attributes[“class”].Value.Contains(“product-list”)).First();

            //var tableRows = Doc.DocumentNode.Descendants("table").First().ChildNodes.Where(r => r.Name == "tr");
            //var tds = tableRows.Select(r => r.ChildNodes.Where(s => s.Name == "td")).ToList();
            //tds.RemoveAt(0);

            //foreach (var td in tds)
            //{
            //    foreach(var innerHtml in td)
            //    {
            //        events.Add(new Event
            //        {
            //            Id = Int32.Parse(innerHtml.InnerHtml),

            //        });
            //    }
            //}

            //var show = "shaggie";

            var driver = new PhantomJSDriver(".\\");
            driver.Url = "https://mtairycasino.foxbet.com/#/american_football/competitions/8169879";
            driver.Navigate();
            var source = driver.PageSource;
            //var pathElement = driver.FindElementByClassName("eventsViewBase");

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(source);

            var b = htmlDoc.DocumentNode;
            var s = htmlDoc.DocumentNode.Descendants("section");

            var a = htmlDoc.DocumentNode.Descendants("section").Where(x => x.Attributes.Last().Value.Contains("afEvt"));
            


            var hey = "oooooo";


        }
    }
}


// Pure C# solution
// https://stackoverflow.com/questions/10169484/htmlagilitypack-and-dynamic-content-issue