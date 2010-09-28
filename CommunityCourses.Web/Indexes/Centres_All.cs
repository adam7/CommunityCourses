using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client.Indexes;
using CommunityCourses.Web.Model;
using Raven.Database.Indexing;

namespace CommunityCourses.Web.Indexes
{
	public class Centres_All : AbstractIndexCreationTask
	{
		public override IndexDefinition CreateIndexDefinition()
		{
			return new IndexDefinition<Centre>
			{
				Map = centres => from centre in centres orderby centre.Name select new { centre }
			}
			.ToIndexDefinition(DocumentStore.Conventions);
		}
	}
}