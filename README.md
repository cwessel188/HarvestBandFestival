# Harvest Band Festival

<h2>Summary</h2>

Several weeks ago I was approached by the organizer for the Harvest band Festival in my hometown of Yakima, Washington. Their website was in need of a lot of work, and I volunteered to help with a rebuild. This is the first version of the project.

This website was built with ASP.NET MVC 5 templates. The login system implements the Microsoft identity package, and the database was created using Entity Framework code-first database creation.

My website at the current time contains 3 different areas, accessible by users with different Claims: 
  Unauthorized users van view the static front end fo the website, containing contest rules and information about each participating school. 
  Users logged in as a band director gain access top their own band's page and have rights to edit and uplaod files. 
  Users logged in as contest staff can edit each band, as well as add and edit contest scores for each band. 
  Finally, and Admin user has rights to all of the above, plus access to the user list, and the capabilities to create users and edit each user's claims. 
  
<h2>Layers</h2>
This web application si built using a four-layer archtecture.
  
In the infrastructure layer, the database uses Microsoft SQLServer, which is accessed through a generic repository using Linq, a C#-integrated version of T-SQL. 

The services layer contains all the database access logic, so that the controllers never access the database directly This is where you'll find all the Linq queries, as well as some methods I use to implement the Claims.

The domain layer contains controllers for each set of views, as well as a set of views models that dictate what data is sent to each view. this allows for a faster and more secure website because only the required data is sent for the database, and no more. Restrictions on a user's ability to see a view are also handled in this layer. 

The views and presentation logic are found in the presentation layer. Here the views are populated from the database, according to what the user is allowed to see. The pages in this project were created using ASP.NET Razor for easy manipulation of the view model. 

To see all the features of the site, there are some dummy usernames you can use to explore the website. They can be found in ```DatabaseInitializer.cs```.
