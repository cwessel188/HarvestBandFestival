using System;
namespace HarvestBandFestival.Services
{
    public interface IBandService
    {
        void AddBand(HarvestBandFestival.Models.Band band);
        void DeleteBandById(int id);
        HarvestBandFestival.Models.Band FindById(int id);
        HarvestBandFestival.Models.ApplicationUser FindUserByContactId(int id);
        System.Collections.Generic.List<HarvestBandFestival.Models.ApplicationUser> GetApplicationUsers();
        System.Collections.Generic.List<HarvestBandFestival.Models.Band> GetBands();
        HarvestBandFestival.Models.Score GetScoreForCurrentYearById(int id);
        void UpdateBand(HarvestBandFestival.Models.Band band);
        void UpdateCurrentScore(int bandId, HarvestBandFestival.Models.Score score);
    }
}
