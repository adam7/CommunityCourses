using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client.Indexes;
using CommunityCourses.Web.Model;
using Raven.Database.Indexing;

namespace CommunityCourses.Web.Indexes
{
	public class Courses_All : AbstractIndexCreationTask
	{
		public override IndexDefinition CreateIndexDefinition()
		{
			return new IndexDefinition<Course>
			{
				Map = courses => from course in courses select new { course }
			}
			.ToIndexDefinition(DocumentStore.Conventions);
		}
	}
}