using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace HarvestBandFestival.Models
{
    public static class PermissionsHelper
    {
        public static bool UserIsContestStaff()
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;

            return user.HasClaim("ContestStaff", "true");

        }
    }
}