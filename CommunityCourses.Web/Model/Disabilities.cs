using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityCourses.Web.Model
{
	public static class Disabilities
	{
		static IEnumerable<string> disabilities = new SortedSet<string> { 
			"Blind/partially sighted",
			"Deaf/have a hearing impediment",
			"Wheelchair user/have mobility difficulties",
			"Personal care support",
			"Mental health difficulties",
			"Unseen disability, eg. diabetes, epilepsy, asthma",
			"A specific learning difficulty eg. dyslexia",
			"Disability not listed above",
			"Prefer not to say"
		};

		public static IEnumerable<string> All()
		{
			return disabilities;
		}
	}
}