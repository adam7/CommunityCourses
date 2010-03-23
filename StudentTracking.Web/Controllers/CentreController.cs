using System.Web.Mvc;
using StudentTracking.Data;
using StudentTracking.Data.Model;
using System.Transactions;
using SubSonic.DataProviders;
using System;
using StudentTracking.Web.ViewModel;
using AutoMapper;

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
			Centre centre = Centre.SingleOrDefault(c => c.Id == id);
			return PartialView(Mapper.Map<Centre, CentreViewModel>(centre));
		}

		public virtual ActionResult Create()
		{
			return View(MVC.Centre.Actions.Edit, new CentreViewModel());
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(CentreViewModel centreViewModel)
		{
			try
			{
				Centre centre = Mapper.Map<CentreViewModel, Centre>(centreViewModel);
				Address address = Mapper.Map<AddressViewModel, Address>(centreViewModel.Address);

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
			return View(Mapper.Map<Centre, CentreViewModel>(Centre.SingleOrDefault(centre => centre.Id == id)));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(CentreViewModel centreViewModel)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					try
					{
						Centre centre = Centre.SingleOrDefault(s => s.Id == centreViewModel.Id);
						Mapper.Map<CentreViewModel, Centre>(centreViewModel, centre);
						centre.Update();

						Address address = centre.Address;
						Mapper.Map<AddressViewModel, Address>(centreViewModel.Address, address);
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
