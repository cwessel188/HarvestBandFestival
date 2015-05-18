using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace HarvestBandFestival.Models
{
    public static class PermissionsHelper
    {
        /// <summary>
        ///  Gets user for httpContext and checks claims for 'ContestStaff.'
        /// </summary>
        /// <returns>True if user had claim 'ContestStaff', false otherwise</returns>
        public static bool UserIsAdmin()
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;

            return user.HasClaim("Admin", "true");
        }
        /// <summary>
        ///  Gets user for httpContext and checks claims for 'ContestStaff.'
        /// </summary>
        /// <returns>True if user had claim 'ContestStaff', false otherwise</returns>
        public static bool UserIsContestStaff()
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;

            return user.HasClaim("ContestStaff", "true");
        }
    }
}