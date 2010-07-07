using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityCourses.Web.Model
{
	public static class Roles
	{
		public const string Student = "Student"; 
		public const string Tutor = "Tutor"; 
		public const string Verifier = "Verifier"; 
		public const string Volunteer = "Volunteer"; 

		public static IEnumerable<string> All()
		{
			return new SortedSet<string>
			{
				Student, Tutor, Verifier, Volunteer
			};
		}
	}
}