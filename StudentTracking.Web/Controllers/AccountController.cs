using System;
using System.Globalization;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentTracking.Web.Controllers
{
  [HandleError]	
  public partial class AccountController : Controller
  {
		public virtual ActionResult LogOn()
		{
			return View();
		}

    [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult LogOn(string userName, string password)
    {
      if (FormsAuthentication.Authenticate(userName, password))
			{
				FormsAuthentication.SetAuthCookie(userName, false);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("logon", "Invalid username or password");
				return View();
			}
    }

    public virtual ActionResult LogOff()
    {
      FormsAuthentication.SignOut();
      return RedirectToAction("Index", "Home");
    }
  }
}
