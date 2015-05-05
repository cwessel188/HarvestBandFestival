using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HarvestBandFestival.Models;
using System.Data.Entity.Validation;

namespace HarvestBandFestival.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            // Call DB Initializer here
            Database.SetInitializer(new DatabaseInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            // clever bit of code to catch the except in VS rather than the browser
            // stolen from StackOverflow
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }
        public IDbSet<Band> Bands { get; set; }



    }
}