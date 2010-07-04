using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace System.Web.Mvc
{
	public static class AjaxHelperExtension
	{
		public static MvcHtmlString ShowDetailsActionLink(this AjaxHelper ajaxHelper, string controller, int itemId, string updateTargetId, string onComplete)
		{
			return ajaxHelper.ActionLink("Details", "Details", controller, new { id = itemId }, 
				new AjaxOptions { HttpMethod = "Get", UpdateTargetId = updateTargetId, OnComplete = onComplete });
		}

		public static MvcHtmlString ShowDetailsActionLink(this AjaxHelper ajaxHelper, string controller, string itemId, string updateTargetId, string onComplete)
		{
			return ajaxHelper.ActionLink("Details", "Details", controller, new { id = itemId },
				new AjaxOptions { HttpMethod = "Get", UpdateTargetId = updateTargetId, OnComplete = onComplete });
		}
	}
}
