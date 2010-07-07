using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityCourses.Web.Model
{
	public static class Ethnicities
	{
		static IEnumerable<string> ethnicities = new SortedSet<string> { 
			"White British",
			"White Irish",
			"White Scottish",
			"Irish Traveller",
			"Other White Background",
			"Black or Black British - Caribbean",
			"Black or Black British - African",
			"Other Black background",
			"Asian or Asian British - Indian",
			"Asian or Asian British - Pakistani",
			"Asian or Asian British - Bangladesh",
			"Chinese or Chinese British",
			"Other Asian background",
			"Arabic or Arabic British",
			"Mixed - White/Black Caribbean",
			"Mixed - White/Black African",
			"Mixed - White/Asian",
			"Other mixed background",
			"Other ethnic background",
			"Somali",
			"Yemeni",
			"Nigerian",
			"Gypsy",
			"Prefer not to say" 
		};

		public static IEnumerable<string> All()
		{
			return ethnicities;
		}
	}
}