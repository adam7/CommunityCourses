using System.Linq;
using System.Web.Mvc;
using StudentTracking.Data;
using StudentTracking.Data.Model;
using System.Transactions;
using SubSonic.DataProviders;
using System;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
	public partial class StudentController : Controller
	{
		const int pageSize = 50;
		//
		// GET: /Student/

		//public virtual ActionResult Index(int page)
		//{
		//  return View(new StudentRepository().GetPaged(page));
		//}


		public virtual ActionResult Index()
		{
			return View(Student.GetPaged(1, pageSize));
		}

		//
		// GET: /Student/Details/5

		public virtual ActionResult Details(int id)
		{
			return View(Student.SingleOrDefault(student => student.Id == id));
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
			Student student = new Student();

			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					try
					{
						address.Save();
						person.AddressId = address.Id;
						person.Save();
						student.PersonId = person.Id;
						student.Save();

						transactionScope.Complete();
					}
					catch (ValidationException validationException)
					{
						validationException.CopyToModelState(ModelState, "student");
						return View();
					}
				}
			}
			return RedirectToAction("Index");
		}

		//
		// GET: /Student/Edit/5
		[AcceptVerbs(HttpVerbs.Get)]
		public virtual ActionResult Edit(int id)
		{
			PopulateViewData();
			return View(Student.SingleOrDefault(student => student.Id == id));
		}

		//
		// POST: /Student/Edit/5
		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(int id, FormCollection form)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					try
					{
						Student student = Student.SingleOrDefault(s => s.Id == Convert.ToInt32(id));
						Person person = student.Person;
						UpdateModel(person, form.ToValueProvider());
						person.Update();

						Address address = person.Address;
						UpdateModel(address, form.ToValueProvider());
						address.Update();

						transactionScope.Complete();
						TempData.SetMessage("Student updated");
						return RedirectToAction(MVC.Person.Actions.Index);
					}
					catch (ValidationException validationException)
					{
						validationException.CopyToModelState(ModelState, "student");
						return View();
					}
				}
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
