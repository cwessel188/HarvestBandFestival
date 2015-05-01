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
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            // add Overlord to Db
            var overlord = new ApplicationUser
            {
                UserName = "wesselcp@plu.edu",
                Email = "wesselcp@plu.edu",
            };
            userManager.Create(overlord, "password");

            // add claims
            userManager.AddClaim(overlord.Id, new Claim("UserManager", "true"));
            userManager.AddClaim(overlord.Id, new Claim("BandManager", "true"));
            userManager.AddClaim(overlord.Id, new Claim("ContestStaff", "true"));

            // add plain users to Db
            var chaz = new ApplicationUser
            {
                UserName = "chazbiroan@codercamps.com",
                Email = "chazbiroan@codercamps.com"
            };
            userManager.Create(chaz, "password");


            var scottyG = new ApplicationUser
            {
                FirstName="Scotty",
                LastName="G",
                PhoneNumber="509.123.4321",
                Email="scottygandthepirates@yakimaschools.org",
                UserName ="scottygandthepirates@yakimaschools.org"
            };
            userManager.Create(scottyG, "password");

            var wally = new ApplicationUser
            {
                FirstName="Wally",
                LastName="Walters",
                PhoneNumber="509.456.7654",
                Email="wally@yakimaschools.com",
                UserName ="wally@yakimaschools.com"
            };
            userManager.Create(wally, "password");

            var legituser = new ApplicationUser
            {
                FirstName="Dillon",
                LastName="Miller",
                PhoneNumber="509-222-7100",
                Email="dillon.miller@ksd.org",
                UserName = "dillon.miller@ksd.org",
                StreetAddress="500 S. Dayton St.",
                City="Kennewick",
                State="WA",
                Zipcode=98336
            };
            userManager.Create(legituser, "password");



            // add some bands to test with
            var bands = new List<Band> {
                new Band {
                    School="AC Davis Senior High School", 
                    Disctrict="Yakima School District",
                    Division=Division.Exhibition, 
                    BandNickName="The Davis High School Buccaneer Marching Band",
                    PrimaryContact = scottyG
                },
                    new Band {
                    School="IKE", 
                    Disctrict="Yakima School District",
                    Division=Division.Exhibition, 
                    PrimaryContact=wally
                },
                    new Band {
                    School="Kennewick High School", 
                    Disctrict="Kennewick School District",
                    Division=Division.AA, 
                    BandNickName="The Pride of the Mid Columbia Basin",
                    BandSize=45,
                    PaidStatus=PaidStatus.Application_Received,
                    PrimaryContact=legituser
                }    
            };

            foreach (var b in bands)
            {
                context.Bands.Add(b);
            }

        }
    }
}
