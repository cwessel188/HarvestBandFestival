using System;

public class Class1
{
	public Class1()
	{
        /**
         * TODO DEPENDENCY INJECTIONS
         * add the services folder back in 
         * create some of :
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
         * TODO CRUD for USERS
         * TODO CRUD for BANDS
         * 
         * defaults for user name and pw validation are in the IdentityConfig folder, by default in the App_Start Folder
         *  Contains the following classes: SignInManager, ApplicationUserManager, EmailService, SmsService
         * 
         * TODOBug
         * when logging in, program appears to lag out, then attempts to dropCreate the database.
         *  - changed the DBInitializer to DropCreateIfNewer
         *   - signinmanager is null. signinmanager should be called from GetOwinContext
         * 
         * 
         * */
	}
}
