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
	public partial class PersonController : Controller
	{
		const int pageSize = 20;

		public virtual ActionResult Index(int page)
		{
            var query = MvcApplication.CurrentSession
                .Query<Person, People_All>()
                .Customize(customize => customize.WaitForNonStaleResults());
				
			ViewData.SetPageNumber(page);
			ViewData.SetTotalPages(query, pageSize);

			return View(query.Skip((page-1) * pageSize).Take(pageSize));
		}

        public virtual ActionResult Download(int page)
        {
            var query = MvcApplication.CurrentSession
                .Query<Person, People_All>()
                .Customize(customize => customize.WaitForNonStaleResults());

            FileHelperEngine<PersonExport> engine = new FileHelperEngine<PersonExport> 
            { 
                HeaderText = @"Name, Roles, CRB Number, CRB Expiry, DOB, Disabilities, Email, Ethnicity, Gender, Mobile, Notes, Phone, Address" 
            };

            string filename = "people.csv";
            string filePath = Path.Combine(new[] { Server.MapPath("~/App_Data"), filename });

            IEnumerable<PersonExport> people =
                    Mapper.Map<IEnumerable<Person>, IEnumerable<PersonExport>>(query.Skip((page - 1) * pageSize).Take(pageSize));

            engine.WriteFile(filePath, people);

            return File(filePath, "text/plain", filename);
        }

		public virtual ActionResult Details(string id)
		{
			return PartialView(MvcApplication.CurrentSession.Load<Person>(id));
		}

		public virtual ActionResult Create()
		{
			return View(Views.Edit, new Person());
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(Person person)
		{
			if (ModelState.IsValid)
			{
				MvcApplication.CurrentSession.Store(person);

				TempData.SetMessage(string.Format("Person {0} created", person.Name));
				return RedirectToAction(MVC.Person.Actions.Index(1));
			}
			else
			{
				return View(MVC.Person.Views.Edit, person);
			}
		}

		[AcceptVerbs(HttpVerbs.Get)]
		public virtual ActionResult Edit(string id)
		{
			return View(MvcApplication.CurrentSession.Load<Person>(id));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(Person person)
		{
			if(ModelState.IsValid)
			{
				MvcApplication.CurrentSession.Store(person);

				TempData.SetMessage(string.Format("Person {0} updated", person.Name));
				return RedirectToAction(MVC.Person.Actions.Index(1));
			}
			else
			{
				return View(MVC.Person.Views.Edit, person);
			}
		}
	}
}
