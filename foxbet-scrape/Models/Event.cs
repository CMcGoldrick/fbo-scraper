using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxbetScrapeAPI.Models
{
    public class Event
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int OfferId { get; set; }
        public DateTime dateTime { get; set; }
    }
}
