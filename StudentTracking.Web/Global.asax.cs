using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using StudentTracking.Web.ViewModel;
using StudentTracking.Data.Model;
using System.Collections.Generic;

namespace StudentTracking.Web
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
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

		public class DisabilityToStringConverter : TypeConverter<Disability, string>
		{
			protected override string ConvertCore(Disability disability)
			{
				return disability.Name;
			}
		}

		public class StudentToCourseStudentViewModelConverter : TypeConverter<Student, CourseStudentViewModel>
		{
			protected override CourseStudentViewModel ConvertCore(Student student)
			{
				return new CourseStudentViewModel { Id = student.Id, Name = student.Person.Name, Address = student.Person.Address.FirstLine };
			}
		}

		public class StudentCourseModuleToCourseStudentSessionViewModel : TypeConverter<StudentCourseModule, StudentCourseModuleViewModel>
		{
			protected override StudentCourseModuleViewModel ConvertCore(StudentCourseModule studentCourseModule)
			{
				return new StudentCourseModuleViewModel
				{
					CourseId = studentCourseModule.Id,
					ModuleId = studentCourseModule.CourseModule.ModuleId,
					ModuleName = studentCourseModule.CourseModule.Module.Name,
					StudentId = studentCourseModule.StudentId,
					StudentName = studentCourseModule.Student.Person.Name,
					Completed = studentCourseModule.Complete
				};
			}
		}

		public class StudentCourseSessionToCourseStudentSessionViewModel : TypeConverter<StudentCourseSession, StudentCourseSessionViewModel>
		{
			protected override StudentCourseSessionViewModel ConvertCore(StudentCourseSession studentCourseSession)
			{
				return new StudentCourseSessionViewModel
				{
					Completed = studentCourseSession.Complete,
					CourseId = studentCourseSession.CourseId,
					SessionId = studentCourseSession.CourseSession.SessionId,
					SessionName = studentCourseSession.CourseSession.Session.Name,
					StudentId = studentCourseSession.StudentId,
					StudentName = studentCourseSession.Student.Person.Name
				};
			}
		}
		
		public static void RegisterAutoMappings()
		{
			// Map Disability/string
			Mapper.CreateMap<Disability, string>()
				.ConvertUsing<DisabilityToStringConverter>();

			// Map Address/AddressViewModel
			Mapper.CreateMap<AddressViewModel, Address>()
				.ForMember(destination => destination.TestMode, option => option.Ignore())
				.ForMember(destination => destination.Id, option => option.Ignore());
			Mapper.CreateMap<Address, AddressViewModel>();

			// Map Person/PersonViewModel
			Mapper.CreateMap<PersonViewModel, Person>()
				.ForMember(destination => destination.AddressId, option => option.Ignore())
				.ForMember(destination => destination.Ethnicity, option => option.Ignore())
				.ForMember(destination => destination.Address, option => option.Ignore())
				.ForMember(destination => destination.TestMode, option => option.Ignore())
				.ForMember(destination => destination.Id, option => option.Ignore())
				.ForMember(destination => destination.Disabilities, option => option.Ignore());

			Mapper.CreateMap<Person, PersonViewModel>();

			// Map Course/CourseViewModel
			Mapper.CreateMap<CourseViewModel, Course>()
				.ForMember(destination => destination.Centre, option => option.Ignore())
				.ForMember(destination => destination.Tutor, option => option.Ignore())
				.ForMember(destination => destination.Unit, option => option.Ignore())
				.ForMember(destination => destination.TestMode, option => option.Ignore())
				.ForMember(destination => destination.Verifier, option => option.Ignore());

			Mapper.CreateMap<Course, CourseViewModel>()
				.ForMember(destination => destination.Sessions, option => option.MapFrom(source => source.StudentCourseSessions))
				.ForMember(destination => destination.Modules, option => option.MapFrom(source => source.StudentCourseModules));

			// Map Centre/CentreViewModel
			Mapper.CreateMap<CentreViewModel, Centre>()
				.ForMember(destination => destination.TestMode, option => option.Ignore())
				.ForMember(destination => destination.Contact, option => option.Ignore())
				.ForMember(destination => destination.ContactId, option => option.Ignore())
				.ForMember(destination => destination.Id, option => option.Ignore())
				.ForMember(destination => destination.Address, option => option.Ignore())
				.ForMember(destination => destination.AddressId, option => option.Ignore());

			Mapper.CreateMap<Centre, CentreViewModel>();

			// Map Student/CourseStudentViewModel
			Mapper.CreateMap<Student, CourseStudentViewModel>()
				.ConvertUsing<StudentToCourseStudentViewModelConverter>();

			// Map StudentCourseSession/StudentCourseSessionViewModel
			Mapper.CreateMap<StudentCourseSession, StudentCourseSessionViewModel>()
				.ConvertUsing<StudentCourseSessionToCourseStudentSessionViewModel>();

			// Map StudentCourseModule/StudentCourseModuleViewModel
			Mapper.CreateMap<StudentCourseModule, StudentCourseModuleViewModel>()
				.ConvertUsing<StudentCourseModuleToCourseStudentSessionViewModel>();
			
			Mapper.AssertConfigurationIsValid();
		}

		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
			RegisterAutoMappings();
		}
	}
}