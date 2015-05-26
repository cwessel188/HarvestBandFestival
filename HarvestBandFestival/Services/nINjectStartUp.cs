using HarvestBandFestival.Infrastructure;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarvestBandFestival.Services
{
    public class ServicesDependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenericRepository>().To<GenericRepository>();
        }

    }
}