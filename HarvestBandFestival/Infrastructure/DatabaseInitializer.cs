using HarvestBandFestival.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace HarvestBandFestival.Infrastructure
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // TODO? what is GetOwinContext?
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            // add Overlord to Db
            var overlord = userManager.FindByName("Overlord");
            if (overlord == null)
            {
                overlord = new ApplicationUser // TODO should eventually be admin(?)
                {
                    UserName = "Overlord",
                    Email = "wesselcp@plu.edu"
                };
                userManager.Create(overlord, "password");
            }

            // TODO add claims
            userManager.AddClaim(overlord.Id, new Claim("CanDeleteUsers", "true"));


        }
    }
}
