using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxbetScrapeAPI.Models
{
    public class Outcome
    {
        public int EventId { get; set; }
        public string OfferName { get; set; }
        public string Line { get; set; }
        public string Odds { get; set; }
    }
}
