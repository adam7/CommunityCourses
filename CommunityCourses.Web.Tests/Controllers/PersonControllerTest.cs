
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommunityCourses.Web.Controllers;
using CommunityCourses.Web.Model;

namespace CommunityCourses.Web.Tests.Controllers
{
	[TestClass]
	public class PersonControllerTest
	{
		//[ClassInitialize]
		//public static void ClassInitialize()
		//{
		//  // TODO: Spin up raven embedded instance
		//}

		[TestMethod]
		public void Create()
		{
			Person person = new Person
			{
				Address = new Address{},
				FirstName = "John",
				LastName = "Smith",
				Title = "Mr",
				Gender = "Male"
			};
			PersonController personController = new PersonController();

			personController.Create(person);
			
			// TODO: Assert
		}
	}
}
