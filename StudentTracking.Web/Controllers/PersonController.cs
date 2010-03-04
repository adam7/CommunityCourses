using System.Linq;
using System.Web.Mvc;
using StudentTracking.Data.Model;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
  public partial class PersonController : Controller
  {
    [AcceptVerbs(HttpVerbs.Get)]
    public virtual ActionResult Index()
    {
      return View(Person.All().ToList());
    }

    [AcceptVerbs(HttpVerbs.Get)]
    public virtual ActionResult Create()
    {
      PopulateViewData();
      return View(MVC.Person.Actions.Edit, new Person());
    }

    [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult Create(Person person)
    {
      try
      {
        person.Save();
        TempData.SetMessage("New person created");
        return RedirectToAction(MVC.Person.Actions.Index);
      }
      catch
      {
        return View();
      }
    }

    [AcceptVerbs(HttpVerbs.Get)]
    public virtual ActionResult Edit(int id)
    {
      PopulateViewData();
      return View(Person.SingleOrDefault(person => person.Id == id));
    }

    [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult Edit(Person person, Address address)
    {
      try
      {
        person.Save();
        return RedirectToAction(MVC.Person.Actions.Index);
      }
      catch
      {
        return View();
      }
    }

    void PopulateViewData()
    {
      ViewData.SetEthnicities(Ethnicity.All().ToList());
    }
  }
}
