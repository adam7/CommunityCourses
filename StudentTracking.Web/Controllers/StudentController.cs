using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using StudentTracking.Data;
using StudentTracking.Data.Repository;
using StudentTracking.Web.Service;
using SubSonic.DataProviders;
using SubSonic.Linq;
using SubSonic.Query;
using StudentTracking.Data.Model;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
  public partial class StudentController : Controller
  {
    //
    // GET: /Student/

    //public virtual ActionResult Index(int page)
    //{
    //  return View(new StudentRepository().GetPaged(page));
    //}


    public virtual ActionResult Index()
    {
      return View(new StudentRepository().GetPaged(1));
    }

    //
    // GET: /Student/Details/5

    public virtual ActionResult Details(int id)
    {
      return View(new StudentRepository().Get(id));
    }

    //
    // GET: /Student/Create

    public virtual ActionResult Create()
    {
      PopulateViewData();
      return View(MVC.Student.Actions.Edit, new Student());
    }

    //
    // POST: /Student/Create

    [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult Create(Person person, Address address)
    {
      try
      {
        StudentService.Create(person, address);

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    //
    // GET: /Student/Edit/5
    [AcceptVerbs(HttpVerbs.Get)]
    public virtual ActionResult Edit(int id)
    {
      PopulateViewData();
      return View(new StudentRepository().Get(id));
    }

    //
    // POST: /Student/Edit/5
    [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult Edit(Person person, Address address)
    {
      try
      {
        StudentService.Update(person, address);
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
      ViewData.SetGenders(Gender.All().ToList());
      ViewData.SetDisabilities(Disability.All().ToList());
    }
  }
}
