using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CommunityCourses.Web.Model;
using CommunityCourses.Web.ViewModel;
using Raven.Client;
using Raven.Client.Document;
using System.Collections.Generic;
using Raven.Client.Indexes;
using CommunityCourses.Web.Indexes;

namespace CommunityCourses.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private const string RavenSessionKey = "Raven.Session";
		private static DocumentStore _documentStore;

		public MvcApplication()
		{
			BeginRequest += (sender, args) => HttpContext.Current.Items[RavenSessionKey] = _documentStore.OpenSession();
			EndRequest += (o, eventArgs) =>
			{
				CurrentSession.SaveChanges();
				var disposable = HttpContext.Current.Items[RavenSessionKey] as IDisposable;
				if (disposable != null)
					disposable.Dispose();
			};
		}

		public static IDocumentSession CurrentSession
		{
			get { return HttpContext.Current.Items[RavenSessionKey] as IDocumentSession; }
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
					"Default",                                                  // Route name
					"{controller}/{action}/{id}",                               // URL with parameters
					new { controller = "TasterSession", action = "Index", id = "" }   // Parameter defaults
			);

			//routes.MapRoute(
			//  null,                                                       // Route name
			//  "",                                                         // Matches the root URL, i.e. ~/
			//  new { controller = "Student", action = "Index", page = 1 }  // Parameter defaults
			//);

			//routes.MapRoute(
			//    null,                                                     // Route name
			//    "{controller}/{action}/{id}/Page{page}",                  // URL pattern e.g. ~/Page683
			//    new { controller = "Student", action = "Index", id = "" },// Parameter defaults
			//    new { page = @"\d+" }                                     // Constraints: page must be numercal
			//);

		}

		protected void Application_Start()
		{
			_documentStore = new DocumentStore { Url = "http://localhost:8080/" };
			_documentStore.Conventions.IdentityPartsSeparator = "-";
			_documentStore.Initialize();

			CreateIndexes();

			RegisterRoutes(RouteTable.Routes);
		}

		void CreateIndexes()
		{
			IndexCreation.CreateIndexes(typeof(Centres_All).Assembly, _documentStore);
			IndexCreation.CreateIndexes(typeof(Courses_All).Assembly, _documentStore);
			IndexCreation.CreateIndexes(typeof(People_All).Assembly, _documentStore);
			IndexCreation.CreateIndexes(typeof(Roles_All).Assembly, _documentStore);
			IndexCreation.CreateIndexes(typeof(TasterSessions_All).Assembly, _documentStore);
			IndexCreation.CreateIndexes(typeof(Units_All).Assembly, _documentStore);

			//_documentStore.DatabaseCommands.PutIndex(
			//  "AllTutors",
			//  new IndexDefinition<Person>()
			//  {
			//    Map = people => from person in people
			//                    where Enumerable.Contains(person.Roles, Roles.Tutor)
			//                    select new { person }
			//  });

			//_documentStore.DatabaseCommands.PutIndex(
			//  "AllStudents",
			//  new IndexDefinition<Person>()
			//  {
			//    Map = people => from person in people
			//                    from role in person.Roles
			//                    where role == "Student"
			//                    select new { role }

			//  });

			//_documentStore.DatabaseCommands.PutIndex(
			//  "AllVolunteers",
			//  new IndexDefinition<Person>()
			//  {	
			//    Map = people => from person in people
			//                    where person.Roles.Contains<string>(Roles.Volunteer)
			//                    select new { person }
			//  });

			//_documentStore.DatabaseCommands.PutIndex(
			//  "AllVerifiers",
			//  new IndexDefinition<Person>()
			//  {
			//    Map = people => from person in people
			//                    where person.Roles.Contains<string>(Roles.Verifier)
			//                    select new { person }
			//  });

			//_documentStore.DatabaseCommands.PutIndex(
			//  "AllUnits",
			//  new IndexDefinition<Unit>()
			//  {
			//    Map = units => from unit in units select new { unit }
			//  });
		}
	}
}