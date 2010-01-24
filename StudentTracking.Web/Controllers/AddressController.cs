using System.Web.Mvc;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
  public partial class AddressController : Controller
  {
    public virtual ActionResult Index()
    {
      return View();
    }
  }
}
