using System.Linq;
using System.Web.Mvc;
using CommunityCourses.Data;
using CommunityCourses.Data.Model;
using System.Transactions;
using SubSonic.DataProviders;
using System;
using System.Collections;
using System.Collections.Generic;
using CommunityCourses.Web.ViewModel;
using AutoMapper;

namespace CommunityCourses.Web.Controllers
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
			return PartialView(new StudentViewModel(Student.SingleOrDefault(student => student.Id == id)));
		}

		//
		// GET: /Student/Create

		public virtual ActionResult Create()
		{
			PopulateViewData();
			return View(Views.Edit, new StudentViewModel());
		}

		//
		// POST: /Student/Create

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(StudentViewModel studentViewModel)
		{
			Student student = new Student();

			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					try
					{
						Address address = Mapper.Map<AddressViewModel, Address>(studentViewModel.Address);
						address.Save();

						Person person = Mapper.Map<PersonViewModel, Person>(studentViewModel.Person);
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
			return View(new StudentViewModel(Student.SingleOrDefault(student => student.Id == id)));
		}

		//
		// POST: /Student/Edit/5
		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(StudentViewModel studentViewModel)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					try
					{
						// Get the student from the db
						Student student = Student.SingleOrDefault(s => s.Id == studentViewModel.Id);
						Person person = student.Person;
						Address address = person.Address;
						
						Mapper.Map(studentViewModel.Person, person);
						person.SetDisabilities(studentViewModel.Person.Disabilities);
						person.Update();
						
						Mapper.Map(studentViewModel.Address, address);
						address.Update();

						transactionScope.Complete();

						TempData.SetMessage("Student updated");
						return RedirectToAction(MVC.Student.Actions.Index());
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
		}
	}
}
