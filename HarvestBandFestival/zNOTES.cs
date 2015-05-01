using System;

public class zNOTES
{
	public zNOTES()
	{
        /**
         * TODO DEPENDENCY INJECTIONS
         * add the services folder back in 
         * create some of:
         *              BandService, IBandService, GenericRepository, IGenericRepository, etc
         *              
         *      Infrastucture: GenRepo, IGenRepo
         * 
         * TODO DTOs AND AUTOMAPPER
         * use Automapper to make Band DTOs to work with various views.
         * eg. a BandIndexDTO for the index view to only display necessary information
         * 
         * TODO ADMIN AREA
         * an admin only area with access to every account and the front end of the site
         * 
         * TODO Claims
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
         * TODOSTEPHEN - 
         * was able to reproduct bug: log in, close, restart, attept to open bands/index
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
         * 
         * 
         * 
         * 
         * NEAT THINGS TO SHOW OFF
         * - RouteConfig redirects edit to the first band.
         * - enums and IdentityModel are split into their own classes
         * - used built in Users property of the ApplicationDbContext to create users view
         * 
         * */
    }
}
