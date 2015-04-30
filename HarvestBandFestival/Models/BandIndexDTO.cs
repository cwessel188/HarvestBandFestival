using HarvestBandFestival.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarvestBandFestival.Models
{
    public class BandIndexDTO
    {
        public int Id { get; set; }
        public string School { get; set; }
        public string Disctrict { get; set; }
        public Division Division { get; set; }

        [DisplayName("Band Size")]
        public int BandSize { get; set; }

        [DisplayName("Paid Status")]
        public PaidStatus PaidStatus { get; set; }

    }
}