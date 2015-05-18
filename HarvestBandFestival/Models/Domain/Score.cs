using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HarvestBandFestival.Models {


    public class Score
    {

        public Score()
        {
            Year = DateTime.Now.Year;
        }
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }

        [DisplayName("Music Performance - Ensemble")]
        public double MusicPerformanceEnsemble { get; set; }

        [DisplayName("Music Performance - Individual")]
        public double MusicPerformanceIndividual { get; set; }

        [DisplayName("Percussion")]
        public double Percussion { get; set; }

        [DisplayName("Visual Performance - Ensemble")]
        public double VisualPerformanceEnsemble { get; set; }

        [DisplayName("Visual Performance - Individual")]
        public double VisualPerformanceIndividual { get; set; }

        [DisplayName("Auxiliary")]
        public double Auxiliary { get; set; }

        [DisplayName("Musical Effect")]
        public double MusicalEffect { get; set; }

        [DisplayName("Visual Effect")]
        public double VisualEffect { get; set; }

        [DisplayName("Drum Major")]
        public double DrumMajor { get; set; }
    }
}