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
	public class TasterSessions_All : AbstractIndexCreationTask
	{
		public override IndexDefinition CreateIndexDefinition()
		{
			return new IndexDefinition<TasterSession>
			{
				Map = tasterSessions => from tasterSession in tasterSessions orderby tasterSession.Name select new { tasterSession }
			}
			.ToIndexDefinition(DocumentStore.Conventions);
		}
	}
}