using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarvestBandFestival.Models
{
    public class BandsIndexViewModel
    {
        public IList<Band> Bands { get; set; }
        public bool HasClaimContestStaff { get; set; }
        public bool HasClaimDirector { get; set; }
        public bool HasClaimAdmin { get; set; }
    }
}