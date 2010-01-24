using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SubSonic.Schema;
using StudentTracking.Data.Model;
using SubSonic.Repository;
using System.Reflection;

namespace StudentTracking.Data
{
	public class ActiveRecordModelBinder :IModelBinder
	{
		#region IModelBinder Members

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			throw new NotImplementedException();
		}

		
		#endregion
	}
}
