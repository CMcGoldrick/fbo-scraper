using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxbetScrapeAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public virtual ICollection<Outcome> Outcomes { get; set; }

    }
}
