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

        //public Score()
        //{
        //    Year = DateTime.Now.Year;
        //}
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }

        [DisplayName("Music Performance - Ensemble")]
        public decimal MusicPerformanceEnsemble { get; set; }

        [DisplayName("Music Performance - Individual")]
        public decimal MusicPerformanceIndividual { get; set; }

        [DisplayName("Percussion")]
        public decimal Percussion { get; set; }

        [DisplayName("Visual Performance - Ensemble")]
        public decimal VisualPerformanceEnsemble { get; set; }

        [DisplayName("Visual Performance - Individual")]
        public decimal VisualPerformanceIndividual { get; set; }

        [DisplayName("Auxiliary")]
        public decimal Auxiliary { get; set; }

        [DisplayName("Musical Effect")]
        public decimal MusicalEffect { get; set; }

        [DisplayName("Visual Effect")]
        public decimal VisualEffect { get; set; }

        [DisplayName("Drum Major")]
        public decimal DrumMajor { get; set; }
    }
}