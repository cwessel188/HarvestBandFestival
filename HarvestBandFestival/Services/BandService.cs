using HarvestBandFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Web.Mvc;

namespace HarvestBandFestival.Services
{
    public class BandService : HarvestBandFestival.Services.IBandService
    {
        // ensures this clas uses only generics
        private IGenericRepository _repo;

        // maps the generic repo to one that's more useful
        public BandService(IGenericRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// creates a list of BandIndexDTOs
        /// </summary>
        /// <returns></returns>
        public IList<BandIndexDTO> List()
        {

            var bandIndexDTOs = _repo.Query<Band>().Project().To<BandIndexDTO>();
            return bandIndexDTOs.ToList();
        }

        public List<Band> Bands { get; set; }

    }
}