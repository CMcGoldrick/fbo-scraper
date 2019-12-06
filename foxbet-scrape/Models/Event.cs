﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxbetScrapeAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string OfferName { get; set; }
        public int Odds { get; set; }
        public string SportsBook { get; set; }
    }
}
