using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using CommunityCourses.Web.Model;

namespace CommunityCourses.Web.Indexes
{
	// TODO: Make this work !
	//public class RoleCount
	//{
	//  public string Role { get; set; }
	//  public int Count { get; set; }
	//}

	//public class PeopleCount_ByRole: AbstractIndexCreationTask
	//{
	//  public override IndexDefinition CreateIndexDefinition()
	//  {
	//    return new IndexDefinition<RoleCount>
	//    {
	//      Map = from person in people
	//            from role in person.Roles
	//            select new RoleCount { Role = role, Count = 1 },
	//      Reduce = from result in results
	//               group results by result.Role into g
	//               select new RoleCount { Role = g.Key, Count = g.Sum(x => x.Count) }
	//    }
	//    .ToIndexDefinition(DocumentStore.Conventions);
	//  }
	//}
}