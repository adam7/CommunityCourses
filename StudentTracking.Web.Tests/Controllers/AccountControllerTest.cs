using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentTracking.Web;
using StudentTracking.Web.Controllers;

namespace StudentTracking.Web.Tests.Controllers
{

  [TestClass]
  public class AccountControllerTest
  {
		//[TestMethod]
		//public void LoginPostRedirectsHomeIfLoginSuccessfulButNoReturnUrlGiven()
		//{
		//  // Arrange
		//  AccountController controller = GetAccountController();

		//  // Act
		//  RedirectToRouteResult result = (RedirectToRouteResult)controller.LogOn("someUser", "goodPass");

		//  // Assert
		//  Assert.AreEqual("Home", result.RouteValues["controller"]);
		//  Assert.AreEqual("Index", result.RouteValues["action"]);
		//}

		//[TestMethod]
		//public void LoginPostRedirectsToReturnUrlIfLoginSuccessfulAndReturnUrlGiven()
		//{
		//  // Arrange
		//  AccountController controller = GetAccountController();

		//  // Act
		//  RedirectResult result = (RedirectResult)controller.LogOn("someUser", "goodPass");

		//  // Assert
		//  Assert.AreEqual("someUrl", result.Url);
		//}

		//[TestMethod]
		//public void LoginPostReturnsViewIfPasswordNotSpecified()
		//{
		//  // Arrange
		//  AccountController controller = GetAccountController();

		//  // Act
		//  ViewResult result = (ViewResult)controller.LogOn("username", "");

		//  // Assert
		//  Assert.AreEqual("You must specify a password.", result.ViewData.ModelState["password"].Errors[0].ErrorMessage);
		//}

		//[TestMethod]
		//public void LoginPostReturnsViewIfUsernameNotSpecified()
		//{
		//  // Arrange
		//  AccountController controller = GetAccountController();
			
		//  // Act
		//  ViewResult result = (ViewResult)controller.LogOn("", "somePass");

		//  // Assert
		//  Assert.AreEqual("You must specify a username.", result.ViewData.ModelState["username"].Errors[0].ErrorMessage);
		//}

		//[TestMethod]
		//public void LoginPostReturnsViewIfUsernameOrPasswordIsIncorrect()
		//{
		//  // Arrange
		//  AccountController controller = new AccountController();

		//  // Act
		//  ViewResult result = (ViewResult)controller.LogOn("someUser", "badPass");

		//  // Assert
		//  Assert.AreEqual("The username or password provided is incorrect.", result.ViewData.ModelState["_FORM"].Errors[0].ErrorMessage);
		//}

		//[TestMethod]
		//public void LogOff()
		//{
		//  // Arrange
		//  AccountController controller = GetAccountController();

		//  // Act
		//  RedirectToRouteResult result = (RedirectToRouteResult)controller.LogOff();

		//  // Assert
		//  Assert.AreEqual("Home", result.RouteValues["controller"]);
		//  Assert.AreEqual("Index", result.RouteValues["action"]);
		//}   
  }
}
