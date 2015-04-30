using HarvestBandFestival.Models;
using System;
using System.Collections.Generic;
namespace HarvestBandFestival.Services
{
    public interface IBandService
    {


        IList<BandIndexDTO> List();

    }
}
