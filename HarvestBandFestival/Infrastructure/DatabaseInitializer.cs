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
using System.Diagnostics;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace HarvestBandFestival.Infrastructure
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            // writes to output window
            Trace.WriteLine("Database Initialization Started");

            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            // add Overlord to Db
            var overlord = new ApplicationUser
                {
                    UserName = "wesselcp@plu.edu",
                    Email = "wesselcp@plu.edu",
                };

            userManager.Create(overlord, "password");

            // add claims
            userManager.AddClaim(overlord.Id, new Claim("Admin", "true"));
            userManager.AddClaim(overlord.Id, new Claim("ContestStaff", "true"));

            // add plain users to Db
            var chaz = new ApplicationUser
            {
                UserName = "chazbiroan@codercamps.com",
                Email = "chazbiroan@codercamps.com"
            };
            userManager.Create(chaz, "password");
            userManager.AddClaim(chaz.Id, new Claim("ContestStaff", "true"));

            var scottyG = new ApplicationUser
            {
                FirstName = "Scotty",
                LastName = "G",
                PhoneNumber = "509.123.4321",
                Email = "scottygandthepirates@yakimaschools.org",
                UserName = "scottygandthepirates@yakimaschools.org"
            };
            userManager.Create(scottyG, "password");

            var wally = new ApplicationUser
            {
                FirstName = "Wally",
                LastName = "Walters",
                PhoneNumber = "509.456.7654",
                Email = "wally@yakimaschools.com",
                UserName = "wally@yakimaschools.com"
            };
            userManager.Create(wally, "password");

            var dillon = new ApplicationUser
            {
                FirstName = "Dillon",
                LastName = "Miller",
                PhoneNumber = "509-222-7100",
                Email = "dillon.miller@ksd.org",
                UserName = "dillon.miller@ksd.org",
                StreetAddress = "500 S. Dayton St.",
                City = "Kennewick",
                Territory = "WA",
                Zipcode = 98336
            };
            userManager.Create(dillon, "password");



            // ================================  add some bands to test with  =================================
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
                    }
                    
            };

            foreach (var b in bands)
            {
                context.Bands.Add(b);
            }

            var WVYakima = new Band
            {
                School = "West Valley High School",
                Disctrict = "West Valley School District",
                Division = Division.AAA_S,
                BandSize = 100,
                PrimaryContact = chaz
            };

            var Kenn = new Band
            {
                School = "Kennewick High School",
                Disctrict = "Kennewick School District",
                Division = Division.AA,
                BandNickName = "The Pride of the Mid Columbia Basin",
                BandSize = 45,
                PaidStatus = PaidStatus.Application_Received,
                PrimaryContact = dillon
            };
            // ====================================Scores==========================================

            WVYakima.Scores.Add(
            new Score
                {
                    Year = 2001,
                    MusicPerformanceEnsemble = 206.5,
                    MusicPerformanceIndividual = 206.5,
                    VisualPerformanceEnsemble = 104.5,
                    VisualPerformanceIndividual = 104.5,
                    MusicalEffect = 167,
                    VisualEffect = 106,
                    Percussion = 55,
                    Auxiliary = 55,
                    DrumMajor = 0
                }
            );

            WVYakima.Scores.Add(
                new Score
                {
                    Year = 2005,
                    MusicPerformanceEnsemble = 245,
                    MusicPerformanceIndividual = 271,
                    VisualPerformanceEnsemble = 164,
                    VisualPerformanceIndividual = 152,
                    MusicalEffect = 239,
                    VisualEffect = 185,
                    Percussion = 76,
                    Auxiliary = 71.5,
                    DrumMajor = 67
                }
                );

            context.Bands.Add(WVYakima);

            Kenn.Scores.Add(
                new Score
                {
                    Year = 2005,
                    MusicPerformanceEnsemble = 250,
                    MusicPerformanceIndividual = 252,
                    VisualPerformanceEnsemble = 161,
                    VisualPerformanceIndividual = 148,
                    MusicalEffect = 250,
                    VisualEffect = 210,
                    Percussion = 78,
                    Auxiliary = 75,
                    DrumMajor = 71
                }
            );

            context.Bands.Add(Kenn);

            Trace.WriteLine("Database Initialization Completed");
        }

    }
}
