using System.Collections.Generic;
using CommunityCourses.Web.ViewModel;
using System.Linq;
using System.Collections;
using CommunityCourses.Web.Model;
using CommunityCourses.Web;
using CommunityCourses.Web.Indexes;

namespace System.Web.Mvc
{
	public static class ViewDataExtension
	{
		#region Fields (7) 

		static readonly string potentialStudentsKey = "potentialStudents";

		#endregion Fields 

		#region Methods (14) 

		// Public Methods (14) 

		public static IEnumerable<string> GetRoles(this ViewDataDictionary viewDataDictionary)
		{
			return Roles.All();
		}

		public static IEnumerable<Centre> GetCentres(this ViewDataDictionary viewDataDictionary)
		{
			return MvcApplication.CurrentSession.Query<Centre>(new Centres_All().IndexName);
		}

		public static IEnumerable<Person> GetPotentialStudents(this ViewDataDictionary viewDataDictionary)
		{
			return viewDataDictionary[potentialStudentsKey] as IEnumerable<Person>;
		}

		public static IEnumerable<Person> GetTutors(this ViewDataDictionary viewDataDictionary)
		{
			return MvcApplication.CurrentSession.Query<Person>(new People_All().IndexName).ToList().Where(p => p.Roles.Contains(Roles.Tutor));
		}

		public static IEnumerable<Unit> GetUnits(this ViewDataDictionary viewDataDictionary)
		{
			return MvcApplication.CurrentSession.Query<Unit>(new Units_All().IndexName);
		}

		public static IEnumerable<Person> GetVerifiers(this ViewDataDictionary viewDataDictionary)
		{
			return MvcApplication.CurrentSession.Query<Person>(new People_All().IndexName).ToList().Where(p => p.Roles.Contains(Roles.Verifier));
		}

		public static void SetPotentialStudents(this ViewDataDictionary viewDataDictionary, IEnumerable<Person> students)
		{
			viewDataDictionary[potentialStudentsKey] = students;
		}		
		#endregion Methods 
	}
}
