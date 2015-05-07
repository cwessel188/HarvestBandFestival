using System;

public class zNOTES
{
	public zNOTES()
	{
        /**
         * TODO DEPENDENCY INJECTIONS
         * add the services folder back in 
         * create some of:
         *              BandService, IBandService, etc
         * 
         * 
         * TODO DTOs AND AUTOMAPPER
         * use Automapper to make Band DTOs to work with various views.
         * eg. a BandIndexDTO for the index view to only display necessary information
         * 
         * TODO ADMIN AREA
         * an admin only area with access to every account and the front end of the site
         * 
         * 
         * TODO create a custom Razor helper for to edit Primarycontact. add to neat things.
         * 
         * defaults for user name and pw validation are in the IdentityConfig folder, by default in the App_Start Folder
         *  Contains the following classes: SignInManager, ApplicationUserManager, EmailService, SmsService
         * 
         * Bug
         * when logging in, program appears to lag out, then attempts to dropCreate the database.
         *  - changed the DBInitializer to DropCreateIfNewer
         *   - signinmanager is null. signinmanager should be called from GetOwinContext
         * FIXED: just log out and in again.
         * 
         * 
         * 
         * 
         * Domain v Services
         * both have models
         * domain models are the real rep of objects in domain
         * then you have DTOs that represent views on domain models
         * 
         * 
         * 
         * TODO DELETE SCRIPTS import from bootstrap?
         * except jqueryvalidateunobstrusive
         * 
         * CURRENTLY WORKING ON
         * making a drop list in the bands edit view for a primary contact
         *  - doesn't carry primarycontact through the view model
         *  
         * implementing claims
         * 
         * updating home controller to reflect current user
         * 
         * DESIRED FUCTIONALITY:
         * claims:
         *      admin
         *      staff
         *      user/director
         * only admin should be able to create a new user
         * admin should be able to edit claims
         * 
         * home controller:
         *      contacts should reflect user's contact info
         *      bands controller should always be visible
         *      directorscontrol should be visible to admin
         *      
         * 
         * 
         * Identity:
         * IAuthentication manager has a signin method that takes an Identity (with Claims[])
         * we're using PasswordSignInASync, which does not.
         * 
         * 
         * 
         * NEAT THINGS TO SHOW OFF
         * - RouteConfig redirects edit to the first band.
         * - enums and IdentityModel are split into their own classes
         * - used built in Users property of the ApplicationDbContext to create users view
         * - sprinkled Trace.Writeline statements to help with debugging, hid module loading notifications to clean up output window
         * 5-2
         * - added functionality via attribute routes to look up user via GuID or last name
         * - used foreign key to create a relationship between Band and Applicationuser
         * 5-4
         * - created a drop list for the bands controller
         * - added functionality to the home page
         *  
         * 
         * */
    }
}
