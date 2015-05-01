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
    public class DatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        
        protected override void Seed(ApplicationDbContext context)
        {
            // TODO? what is GetOwinContext?
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            // add Overlord to Db
            // TODO? code stops executing at this point
            var overlord = userManager.FindByEmail("wesselcp@plu.edu");
            //ApplicationUser overlord = null;
            if (overlord == null)
            {
                overlord = new ApplicationUser // TODO should eventually be admin(?)
                {
                    UserName = "wesselcp@plu.edu",
                    Email = "wesselcp@plu.edu"
                };
                userManager.Create(overlord, "password");
            }


            // add claims
            userManager.AddClaim(overlord.Id, new Claim("CanDeleteUsers", "true"));

            // add some bands to test with
            var bands = new List<Band> {
                new Band {
                    School="AC Davis Senior High School", 
                    Disctrict="Yakima School District",
                    Division=Division.Exhibition, 
                    DirectorFirstName="Scotty",
                    DirectorLastName="Goranson",
                    PhoneNumber="509-456-4321",
                    Email="scottygandthepirates@yakimaschools.com",
                    BandNickName="The Davis High School Buccaneer Marching Band"
                },
                    new Band {
                    School="IKE", 
                    Disctrict="Yakima School District",
                    Division=Division.Exhibition, 
                    DirectorFirstName="David",
                    DirectorLastName="Walters",
                    PhoneNumber="509-456-4321",
                    Email="wally@yakimaschools.com"
                },
                    new Band {
                    School="Kennewick High School", 
                    Disctrict="Kennewick School District",
                    Division=Division.AA, 
                    DirectorFirstName="Dillon",
                    DirectorLastName="Miller",
                    PhoneNumber="509-222-7100",
                    Email="dillon.miller@ksd.org",
                    BandNickName="The Pride of the Mid Columbia Basin",
                    StreetAddress="500 S. Dayton St",
                    City="Kennewick",
                    ZipCode=99336,
                    BandSize=45,
                    PaidStatus=PaidStatus.Application_Received
                }    
            };

            foreach (var b in bands)
            {
                context.Bands.Add(b);
            }

        }
    }
}
