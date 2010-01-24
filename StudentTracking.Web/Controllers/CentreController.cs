using System.Web.Mvc;
using StudentTracking.Data;
using StudentTracking.Data.Model;
using System.Transactions;
using SubSonic.DataProviders;
using System;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
	public partial class CentreController : Controller
	{
		public virtual ActionResult Index()
		{
			return View(Centre.All());
		}

		public virtual ActionResult Details(int id)
		{
			return View(Centre.SingleOrDefault(centre => centre.Id == id));
		}

		public virtual ActionResult Create()
		{
			return View(MVC.Centre.Actions.Edit, new Centre());
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(Centre centre, Address address)
		{
			try
			{
				Centre.Add(centre, address);
				TempData.SetMessage("New centre created");
				return RedirectToAction(MVC.Centre.Actions.Index);
			}
			catch (ValidationException validationException)
			{
				validationException.CopyToModelState(ModelState, "centre");
				return View();
			}
		}

		[AcceptVerbs(HttpVerbs.Get)]
		public virtual ActionResult Edit(int id)
		{
			return View(Centre.SingleOrDefault(centre => centre.Id == id));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(int id, FormCollection form)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					try
					{
						Centre centre = Centre.SingleOrDefault(s => s.Id == Convert.ToInt32(id));
						UpdateModel(centre, form.ToValueProvider());
						centre.Update();

						Address address = centre.Address;
						UpdateModel(address, form.ToValueProvider());
						address.Update();

						transactionScope.Complete();
						TempData.SetMessage("Centre updated");
						return RedirectToAction(MVC.Centre.Actions.Index);
					}
					catch (ValidationException validationException)
					{
						validationException.CopyToModelState(ModelState, "centre");
						return View();
					}
				}
			}
		}
	}
}
