using CommunityCourses.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using CommunityCourses.Web.Model;
using CommunityCourses.Web.ViewModel;

namespace CommunityCourses.Web.Tests.Controllers
{
    
    
    /// <summary>
    ///This is a test class for CourseControllerTest and is intended
    ///to contain all CourseControllerTest Unit Tests
    ///</summary>
	[TestClass()]
	public class CourseControllerTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for AddStudent
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		public void AddStudentTest()
		{
			CourseController target = new CourseController(); // TODO: Initialize to an appropriate value
			string id = string.Empty; // TODO: Initialize to an appropriate value
			string studentId = string.Empty; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.AddStudent(id, studentId);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ConvertToCourseViewModel
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		[DeploymentItem("CommunityCourses.Web.dll")]
		public void ConvertToCourseViewModelTest()
		{
			CourseController_Accessor target = new CourseController_Accessor(); // TODO: Initialize to an appropriate value
			Course course = null; // TODO: Initialize to an appropriate value
			CourseViewModel expected = null; // TODO: Initialize to an appropriate value
			CourseViewModel actual;
			actual = target.ConvertToCourseViewModel(course);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Create
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		public void CreateTest()
		{
			CourseController target = new CourseController(); // TODO: Initialize to an appropriate value
			Course course = null; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Create(course);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for CreateUnits
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		[DeploymentItem("CommunityCourses.Web.dll")]
		public void CreateUnitsTest()
		{
			CourseController_Accessor target = new CourseController_Accessor(); // TODO: Initialize to an appropriate value
			target.CreateUnits();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for Details
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		public void DetailsTest()
		{
			CourseController target = new CourseController(); // TODO: Initialize to an appropriate value
			string id = string.Empty; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Details(id);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Edit
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		public void EditTest()
		{
			CourseController target = new CourseController(); // TODO: Initialize to an appropriate value
			string id = string.Empty; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Edit(id);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Edit
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		public void EditTest1()
		{
			CourseController target = new CourseController(); // TODO: Initialize to an appropriate value
			Course course = null; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Edit(course);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Index
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		public void IndexTest()
		{
			CourseController target = new CourseController(); // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Index();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for UpdateModuleComplete
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		public void UpdateModuleCompleteTest()
		{
			CourseController target = new CourseController(); // TODO: Initialize to an appropriate value
			string courseId = string.Empty; // TODO: Initialize to an appropriate value
			string studentId = string.Empty; // TODO: Initialize to an appropriate value
			string moduleId = string.Empty; // TODO: Initialize to an appropriate value
			bool complete = false; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.UpdateModuleComplete(courseId, studentId, moduleId, complete);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for UpdateSessionComplete
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Adam Cooper\\Documents\\Visual Studio 2008\\Projects\\CommunityCourses\\CommunityCourses.Web", "/")]
		[UrlToTest("http://localhost:1187/")]
		public void UpdateSessionCompleteTest()
		{
			CourseController target = new CourseController(); // TODO: Initialize to an appropriate value
			string courseId = string.Empty; // TODO: Initialize to an appropriate value
			string studentId = string.Empty; // TODO: Initialize to an appropriate value
			string sessionId = string.Empty; // TODO: Initialize to an appropriate value
			bool complete = false; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.UpdateSessionComplete(courseId, studentId, sessionId, complete);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
