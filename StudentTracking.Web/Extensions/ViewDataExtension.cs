using System.Collections.Generic;
using StudentTracking.Data.Model;
using StudentTracking.Data.Enum;
using StudentTracking.Web.ViewModel;
using System.Linq;
using System.Collections;

namespace System.Web.Mvc
{
	public static class ViewDataExtension
	{
		#region Fields (7) 

		static readonly string centresKey = "centres";
		static readonly string disabilitiesKey = "disabilities";
		static readonly string ethnicitiesKey = "ethnicities";
		static readonly string potentialStudentsKey = "potentialStudents";
		static readonly string tutorsKey = "tutors";
		static readonly string unitsKey = "units";
		static readonly string verifiersKey = "verifiers";

		#endregion Fields 

		#region Methods (14) 

		// Public Methods (14) 

		public static List<Centre> GetCentres(this ViewDataDictionary viewDataDictionary)
		{
			return viewDataDictionary[centresKey] as List<Centre>;
		}

		public static string[] GetDisabilities(this ViewDataDictionary viewDataDictionary)
		{
			return (from disability in Disability.All() select disability.Name).ToArray();
		}

		public static List<Ethnicity> GetEthnicities(this ViewDataDictionary viewDataDictionary)
		{
			return viewDataDictionary[ethnicitiesKey] as List<Ethnicity>;
		}

		public static IEnumerable GetGenders(this ViewDataDictionary viewDataDictionary)
		{
			return from Gender gender in Enum.GetValues(typeof(Gender))
						 select new { 
							 Id = (int)gender, 
							 Name = gender.ToString() };
		}

		public static List<Student> GetPotentialStudents(this ViewDataDictionary viewDataDictionary)
		{
			return viewDataDictionary[potentialStudentsKey] as List<Student>;
		}

		public static List<Tutor> GetTutors(this ViewDataDictionary viewDataDictionary)
		{
			return viewDataDictionary[tutorsKey] as List<Tutor>;
		}

		public static List<Unit> GetUnits(this ViewDataDictionary viewDataDictionary)
		{
			return viewDataDictionary[unitsKey] as List<Unit>;
		}

		public static List<Verifier> GetVerifiers(this ViewDataDictionary viewDataDictionary)
		{
			return viewDataDictionary[verifiersKey] as List<Verifier>;
		}

		public static void SetCentres(this ViewDataDictionary viewDataDictionary, List<Centre> centres)
		{
			viewDataDictionary[centresKey] = centres;
		}

		public static void SetEthnicities(this ViewDataDictionary viewDataDictionary, List<Ethnicity> ethnicities)
		{
			viewDataDictionary[ethnicitiesKey] = ethnicities;
		}

		public static void SetPotentialStudents(this ViewDataDictionary viewDataDictionary, List<Student> students)
		{
			viewDataDictionary[potentialStudentsKey] = students;
		}

		public static void SetTutors(this ViewDataDictionary viewDataDictionary, List<Tutor> tutors)
		{
			viewDataDictionary[tutorsKey] = tutors;
		}

		public static void SetUnits(this ViewDataDictionary viewDataDictionary, List<Unit> units)
		{
			viewDataDictionary[unitsKey] = units;
		}

		public static void SetVerifiers(this ViewDataDictionary viewDataDictionary, List<Verifier> verifiers)
		{
			viewDataDictionary[verifiersKey] = verifiers;
		}

		#endregion Methods 
	}
}
