using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using CommunityCourses.Web.ExportModels;
using CommunityCourses.Web.Indexes;
using CommunityCourses.Web.Model;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

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
				null,
				"{controller}/Create/",
				new { action = "Create" }
			);

			routes.MapRoute(
				null,
				"{controller}/Edit/",
				new { action = "Edit" }
			);

			routes.MapRoute(
				null,                                                     // Route name
				"{controller}/{action}/Page{page}",												// URL pattern e.g. ~/Page683
				new { controller = "Home", action = "Index", page = 1 },  // Parameter defaults
				new { page = @"\d+" }                                     // Constraints: page must be numercal
			);

			routes.MapRoute(
				null,                                                     // Route name
				"{controller}/{action}/{id}",															// URL pattern e.g. ~/Page683
				new { controller = "Home", action = "Index", id = "" }    // Parameter defaults
			);
		}

		protected void Application_Start()
		{
			_documentStore = new DocumentStore { Url = "http://localhost:8080/" };
			_documentStore.Conventions.IdentityPartsSeparator = "_";
			_documentStore.Conventions.MaxNumberOfRequestsPerSession = 300; // This is bad, but need it for Course Index right now ... will fix
			_documentStore.Initialize();

            // Create Raven indexes
            IndexCreation.CreateIndexes(typeof(Centres_All).Assembly, _documentStore);

            ConfigureAutoMapper();

			RegisterRoutes(RouteTable.Routes);
		}

		void ConfigureAutoMapper()
		{
            Mapper.CreateMap<Centre, CentreExport>()
                .ForMember(member => member.Address, option => option.MapFrom(member => member.Address.ToSingleLine()));
            Mapper.CreateMap<Person, PersonExport>()
                .ForMember(member => member.Address, option => option.MapFrom(member => member.Address.ToSingleLine()))
                .ForMember(member => member.Roles, option => option.MapFrom(member => string.Join(",", member.Roles)))
                .ForMember(member => member.Disabilities, option => option.MapFrom(member => string.Join(",", member.Disabilities)));
            Mapper.CreateMap<Course, CourseExport>();
		}
	}
}