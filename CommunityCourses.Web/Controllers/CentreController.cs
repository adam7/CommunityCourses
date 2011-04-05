using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CommunityCourses.Web.ExportModels;
using CommunityCourses.Web.Indexes;
using CommunityCourses.Web.Model;
using FileHelpers;

namespace CommunityCourses.Web.Controllers
{
    [Authorize]
    public partial class CentreController : Controller
    {
        const int pageSize = 20;

        public virtual ActionResult Index(int page)
        {
            var query = MvcApplication.CurrentSession
                .Query<Centre, Centres_All>()
                .Customize(customize => customize.WaitForNonStaleResults());

            ViewData.SetPageNumber(page);
            ViewData.SetTotalPages(query, pageSize);

            return View(query.Skip((page - 1) * pageSize).Take(pageSize));
        }

        public virtual ActionResult Download(int page)
        {
            var query = MvcApplication.CurrentSession
                .Query<Centre, Centres_All>()
                .Customize(customize => customize.WaitForNonStaleResults());

            FileHelperEngine<CentreExport> engine = new FileHelperEngine<CentreExport>()
                {
                    HeaderText = @"Name, Phone , Contact, Address"
                };                 
            string filename = "centres.csv";
            string filePath = Path.Combine(new[] { Server.MapPath("~/App_Data"), filename });

            IEnumerable<CentreExport> centres =
                    Mapper.Map<IEnumerable<Centre>, IEnumerable<CentreExport>>(query.Skip((page - 1) * pageSize).Take(pageSize));

            engine.WriteFile(filePath, centres);

            return File(filePath, "text/plain", filename);
        }

        public virtual ActionResult Details(string id)
        {
            return PartialView(MvcApplication.CurrentSession.Load<Centre>(id));
        }

        public virtual ActionResult Create()
        {
            return View(Views.Edit, new Centre());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create(Centre centre)
        {
            if (ModelState.IsValid)
            {
                MvcApplication.CurrentSession.Store(centre);
                TempData.SetMessage(string.Format("Centre {0} created"));
                return RedirectToAction(MVC.Centre.Actions.Index(1));
            }
            else
            {
                return View(centre);
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult Edit(string id)
        {
            return View(MvcApplication.CurrentSession.Load<Centre>(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Edit(Centre centre)
        {
            if (ModelState.IsValid)
            {
                MvcApplication.CurrentSession.Store(centre);
                TempData.SetMessage(string.Format("Centre {0} updated"));
                return RedirectToAction(MVC.Centre.Actions.Index(1));
            }
            else
            {
                return View(centre);
            }
        }
    }
}
