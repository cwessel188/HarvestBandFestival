using HarvestBandFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HarvestBandFestival.Services
{
    public class BandService : IBandService
    {
        // ensures this class uses only generics
        private IGenericRepository _repo;

        public BandService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<Band> GetBands()
        {
            return _repo.Query<Band>().Include(b => b.PrimaryContact).ToList();
        }

        public Band FindById(int? id)
        {
            return _repo.Find<Band>(id);
        }

        public ApplicationUser FindUserByContactId(string id)
        {
            return _repo.Find<ApplicationUser>(id);
        }

        public void AddBand(Band band)
        {
            _repo.Add<Band>(band);
            _repo.SaveChanges();
        }

        public List<ApplicationUser> GetApplicationUsers()
        {
            return _repo.Query<ApplicationUser>().ToList();
        }

        public void UpdateBand(Band band)
        {
            var original = _repo.Find<Band>(band.Id);
            original.School = band.School;
            original.Disctrict = band.Disctrict;
            original.Division = band.Division;
            original.BandSize = band.BandSize;
            original.BandNickName = band.BandNickName;
            original.ImageSource = band.ImageSource;
            original.PrimaryContactId = band.PrimaryContactId;

            _repo.SaveChanges();
        }

        public void DeleteBandById(int id)
        {
            var band = _repo.Find<Band>(id);
            _repo.Delete<Band>(band);
            _repo.SaveChanges();
        }

        public Score GetScoreForCurrentYearById(int? id)
        {
            var band = (_repo.Query<Band>().Include(b => b.Scores).Where(b => b.Id == id)).FirstOrDefault();

            if (band == null)
            {
                return null;
            }

            if (band.Scores.Count == 0 || band.Scores.Last().Year != DateTime.Now.Year)
            {
                band.Scores.Add(new Score());
                _repo.SaveChanges();
            }
            return band.Scores.Last();
        }
        public void UpdateCurrentScore(int bandId, Score score)
        {
            var band = (_repo.Query<Band>().Include(b => b.Scores).Where(b => b.Id == bandId)).FirstOrDefault();
            var original = band.Scores.Last();
            original.Auxiliary = score.Auxiliary;
            original.DrumMajor = score.DrumMajor;
            original.MusicalEffect = score.MusicalEffect;
            original.MusicPerformanceEnsemble = score.MusicPerformanceEnsemble;
            original.MusicPerformanceIndividual = score.MusicPerformanceIndividual;
            original.Percussion = score.Percussion;
            original.VisualEffect = score.VisualEffect;
            original.VisualPerformanceEnsemble = score.VisualPerformanceEnsemble;
            original.VisualPerformanceIndividual = score.VisualPerformanceIndividual;

            _repo.SaveChanges();
        }
    }
}