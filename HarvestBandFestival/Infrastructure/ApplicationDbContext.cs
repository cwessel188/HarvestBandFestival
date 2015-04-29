using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HarvestBandFestival.Models;

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
    }
}