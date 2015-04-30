﻿using HarvestBandFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HarvestBandFestival.Models;

namespace HarvestBandFestival.App_Start
{
    public class AutoMapperStartup
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<Band, BandIndexDTO>();
        }
    }
}