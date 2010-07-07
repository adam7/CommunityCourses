using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommunityCourses.Web.Model
{
	public static class Genders
	{
		static IEnumerable<string> genders = new SortedSet<string>(){
			"Male",
			"Female"
		};

		public static IEnumerable<string> All()
		{
			return genders;
		}
	}
}
