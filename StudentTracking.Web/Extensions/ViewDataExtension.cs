using System.Collections.Generic;
using StudentTracking.Data.Model;

namespace System.Web.Mvc
{
  public static class ViewDataExtension
  {
		#region Fields (7) 

    static readonly string centresKey = "centres";
    static readonly string disabilitiesKey = "disabilities";
    static readonly string ethnicitiesKey = "ethnicities";
    static readonly string gendersKey = "genders";
    static readonly string tutorsKey = "tutors";
    static readonly string unitsKey = "units";
    static readonly string verifiersKey = "verifiers";
		static readonly string potentialStudentsKey = "potentialStudents";


		#endregion Fields 

		#region Methods (14) 

		// Public Methods (14) 

    public static List<Centre> GetCentres(this ViewDataDictionary viewDataDictionary)
    {
      return viewDataDictionary[centresKey] as List<Centre>;
    }

    public static List<Disability> GetDisabilities(this ViewDataDictionary viewDataDictionary)
    {
      return viewDataDictionary[disabilitiesKey] as List<Disability>;
    }

    public static List<Ethnicity> GetEthnicities(this ViewDataDictionary viewDataDictionary)
    {
      return viewDataDictionary[ethnicitiesKey] as List<Ethnicity>;
    }

    public static List<Gender> GetGenders(this ViewDataDictionary viewDataDictionary)
    {
      return viewDataDictionary[gendersKey] as List<Gender>;
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

		public static List<Student> GetPotentialStudents(this ViewDataDictionary viewDataDictionary)
		{
			return viewDataDictionary[potentialStudentsKey] as List<Student>;
		}

    public static void SetCentres(this ViewDataDictionary viewDataDictionary, List<Centre> centres)
    {
      viewDataDictionary[centresKey] = centres;
    }

    public static void SetDisabilities(this ViewDataDictionary viewDataDictionary, List<Disability> disabilities)
    {
      viewDataDictionary[disabilitiesKey] = disabilities;
    }

    public static void SetEthnicities(this ViewDataDictionary viewDataDictionary, List<Ethnicity> ethnicities)
    {
      viewDataDictionary[ethnicitiesKey] = ethnicities;
    }

    public static void SetGenders(this ViewDataDictionary viewDataDictionary, List<Gender> genders)
    {
      viewDataDictionary[gendersKey] = genders;
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

		public static void SetPotentialStudents(this ViewDataDictionary viewDataDictionary, List<Student> students)
		{
			viewDataDictionary[potentialStudentsKey] = students;
		}

		#endregion Methods 
  }
}
