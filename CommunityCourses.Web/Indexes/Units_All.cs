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
	public class Units_All : AbstractIndexCreationTask
	{
		public override IndexDefinition CreateIndexDefinition()
		{
			return new IndexDefinition<Unit>
			{
				Map = units => from unit in units orderby unit.Name select new { unit }
			}
			.ToIndexDefinition(DocumentStore.Conventions);
		}
	}
}