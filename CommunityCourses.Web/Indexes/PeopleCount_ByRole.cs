using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using CommunityCourses.Web.Model;

namespace CommunityCourses.Web.Indexes
{
	public class RoleCount
	{
		public string Role { get; set; }
		public int Count { get; set; }
	}

	// TODO: Make this index strongly typed!
	public class PeopleCount_ByRole : AbstractIndexCreationTask
	{
		public override IndexDefinition CreateIndexDefinition()
		{
			return new IndexDefinition//<RoleCount>
			{
				Map = "from person in docs.People from role in person.Roles select new { Role = role, Count = 1 }",
				//people => from person in people
				//          from role in person.Role
				//          select new { Role = role, Count = 1 },
				Reduce = "from result in results group result by result.Role into g select new { Role = g.Key, Count = g.Sum(x=>x.Count) }"
				//results => from result in results
				//           group result by result into g
				//           select new { Role = g.Key, Count = g.Count() }
			};
			//.ToIndexDefinition(DocumentStore.Conventions);
		}
	}
}