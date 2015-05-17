using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarvestBandFestival.Models;
using System.Web.Mvc;

namespace HarvestBandFestival.Views.BandDirectors
{
    public class BandsViewModelWithUsers
    {
        public Band Band { get; set; }
        public SelectList AppUsers { get; set; }

    }
}