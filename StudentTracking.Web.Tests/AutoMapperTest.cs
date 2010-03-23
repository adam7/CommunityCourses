using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentTracking.Web.Tests
{
	/// <summary>
	/// Summary description for AutoMapperTest
	/// </summary>
	[TestClass]
	public class AutoMapperTest
	{
		public AutoMapperTest()
		{
		}

		[TestMethod]
		public void MappingTest()
		{
			MvcApplication.RegisterAutoMappings();
		}
	}
}
