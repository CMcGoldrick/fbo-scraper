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
//using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;

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

            ////PhantomJS driver
            //var driver = new PhantomJSDriver(".\\");
            //driver.Url = "https://mtairycasino.foxbet.com/#/american_football/competitions/8169879";
            //driver.Navigate();
            //var source = driver.PageSource;
            //var pathElement = driver.FindElementByClassName("eventsViewBase");

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            var driver = new ChromeDriver(options);
            driver.Url = "https://mtairycasino.foxbet.com/#/american_football/competitions/8169879";
            driver.Navigate();
            var source = driver.PageSource;

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(source);

            var isCorrectData = htmlDoc.DocumentNode;
            var gameContent = htmlDoc.DocumentNode.Descendants("section").Where(x => x.Attributes.Last().Value.Contains("eventsViewBase"));

            // game data
            var events = htmlDoc.DocumentNode.SelectNodes(
                "//html[1]/body[1]/div[1]/div[4]/div[1]/div[2]/div[2]/div[2]/div[1]/main[1]/div[3]/div[1]/ul[1]/li[2]/div[1]/section[1]/ul[1]/li[1]/div[2]/div[1]")
                .FirstOrDefault()
                .ChildNodes;

            // offers
            //var offers = htmlDoc.DocumentNode.SelectNodes(
            //    "//html[1]/body[1]/div[1]/div[4]/div[1]/div[2]/div[2]/div[2]/div[1]/main[1]/div[3]/div[1]/ul[1]/li[2]/div[1]/section[1]/ul[1]/li[1]/div[2]/div[1]/section[1]/div[1]/header[1]/div[1]")
            //    .FirstOrDefault()
            //    .ChildNodes;

            //var offerList = new List<string>();

            //foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes(
            //    "//html[1]/body[1]/div[1]/div[4]/div[1]/div[2]/div[2]/div[2]/div[1]/main[1]/div[3]/div[1]/ul[1]/li[2]/div[1]/section[1]/ul[1]/li[1]/div[2]/div[1]/section[1]/div[1]/header[1]/div[1]")
            //    .FirstOrDefault()
            //    .ChildNodes)
            //{
            //    if (node.Name == "span")
            //        offerList.Add(node.InnerText);
            //}
            //var show = offerList;


            foreach (var game in events)
            {
                int eventId = 1;
                var currentEvent = new Event();
                var outcomes = new List<Outcome>();

                var teams = game.Descendants().Where(n => n.HasClass("teamName"));
                var pointSpreads = game.Descendants().Where(ps => ps.HasClass("market-AMERICAN_FOOTBALL-FTOT-AHCP_MAIN"));

                currentEvent.HomeTeam = teams.First().InnerText;
                currentEvent.AwayTeam = teams.Last().InnerText;

                foreach(var ps in pointSpreads)
                {
                    var line = ps.Descendants().Where(ps => ps.HasClass("button__bet__title button__bet__title--abbreviated"));
                    var newOUtcome = new Outcome
                    {
                        EventId = eventId,
                        OfferName = "Point Spread",
                        Line = line.First().InnerText
                    };
                }


                eventId++;
            }

            


        }
    }
}


// Pure C# solution -> need System.Microsoft.Forms (not available in .net core)
// https://stackoverflow.com/questions/10169484/htmlagilitypack-and-dynamic-content-issue

// selenium solution -> .net Core
// https://code-maze.com/automatic-ui-testing-selenium-asp-net-core-mvc/


// offers xpath: /html[1]/body[1]/div[1]/div[4]/div[1]/div[2]/div[2]/div[2]/div[1]/main[1]/div[3]/div[1]/ul[1]/li[2]/div[1]/section[1]/ul[1]/li[1]/div[2]/div[1]/section[1]/div[1]/header[1]/div[1]
