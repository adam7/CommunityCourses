using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Database.Indexing;
using Raven.Client.Indexes;
using Raven.Client.Document;
using CommunityCourses.Web.Model;

namespace CommunityCourses.Web.Indexes
{
	public class People_All : AbstractIndexCreationTask
	{
		public override IndexDefinition CreateIndexDefinition()
		{
			return new IndexDefinition<Person>
			{
				Map = people => from person in people select new { person }
			}
			.ToIndexDefinition(DocumentStore.Conventions);
		}
	}
}