using System.Linq;
using System.Web.Mvc;
using StudentTracking.Data.Model;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
  public partial class UnitController : Controller
    {
        //
        // GET: /Unit/

    public virtual ActionResult Index()
        {
            return View(Unit.All().ToList());
        }

        //
        // GET: /Unit/Details/5

    public virtual ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Unit/Create

    public virtual ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Unit/Create

        [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Unit/Edit/5

        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Unit/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
