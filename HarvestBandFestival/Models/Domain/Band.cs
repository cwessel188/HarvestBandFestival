using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HarvestBandFestival.Models
{
    /// <summary>
    /// A Band class that contains every property a band could ever want.
    /// </summary>
    public class Band
    {
        public Band()
        {
            Scores = new List<Score>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string School { get; set; }
        [Required]
        public string Disctrict { get; set; }
        [Required]
        public Division Division { get; set; }

        [DisplayName("Band Size")]
        public int BandSize { get; set; }

        [DisplayName("Band Nick Name")]
        public string BandNickName { get; set; }

        [DisplayName("Paid Status")]
        public PaidStatus PaidStatus { get; set; }

        [DisplayName("Date Paid")]
        public DateTime? DatePaid { get; set; }

        public string ImageSource { get; set; } // TODO image implementation 

        public string PrimaryContactId { get; set; }

        [Display(Name="Primary Contact Information")]
        [ForeignKey("PrimaryContactId")]
        public ApplicationUser PrimaryContact { get; set; }

        public ICollection<Score> Scores { get; set; }

    }

}