using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityCourses.Web.Model
{
	public class Unit
	{
		public Unit()
		{
			Modules = new List<Module>();
			Sessions = new List<Session>();
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<Module> Modules { get; set; }
		public IEnumerable<Session> Sessions { get; set; }
	}
}