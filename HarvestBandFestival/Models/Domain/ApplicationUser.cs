﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HarvestBandFestival.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) 
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            
            // TODO add claims for scoreEntry, EditBand, ViewBands, ContestStaff
            // new claim Admin
            // new claim ContestStaff

            Claim ContestStaff = new Claim("ContestStaff", "true");

            return userIdentity;
        }

        // Inherited properties used in this project:
        // guid Id
         //   string Email
         //   string PhoneNumber

        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        [MaxLength(2, ErrorMessage="Please enter two characters i.e.'WA'")]
        [Display(Name = "State")]
        public string Territory { get; set; }
        public int? Zipcode { get; set; }


        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
        

    }


}