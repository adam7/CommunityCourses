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
		static readonly string potentialStudentsKey = "potentialStudents";
		static readonly string pageNumberKey = "pageNumberKey";
		static readonly string totalPagesKey = "totalPagesKey";

		public static int GetPageNumber(this ViewDataDictionary viewDataDictionary)
		{
			return (int)viewDataDictionary[pageNumberKey];
		}

		public static int GetTotalPages(this ViewDataDictionary viewDataDictionary)
		{
			return (int)viewDataDictionary[totalPagesKey];
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

		public static void SetPageNumber(this ViewDataDictionary viewDataDictionary, int pageNumber)
		{
			viewDataDictionary[pageNumberKey] = pageNumber;
		}

		public static void SetTotalPages(this ViewDataDictionary viewDataDictionary, IQueryable<object> query, int pageSize)
		{
			viewDataDictionary[totalPagesKey] = (int)Math.Ceiling((double)query.Count() / pageSize);
		}
	}
}
