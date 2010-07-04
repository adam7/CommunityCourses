using System.Text;
using System.Web.Mvc.Html;
using CommunityCourses.Web.ViewModel;
using System.Collections.Generic;


namespace System.Web.Mvc
{

  public static class HtmlHelperExtension
  {
		  /// <summary>
  /// This helper method renders a link within an HTML LI tag.
  /// A class="selected" attribute is added to the tag when
  /// the link being rendered corresponds to the current
  /// controller and action.
  /// 
  /// This helper method is used in the Site.Master View 
  /// Master Page to display the website menu.
  /// </summary>
    public static string MenuItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
    {
      string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
      string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

      var sb = new StringBuilder();

      if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
        sb.Append("<li class=\"selected\">");
      else
        sb.Append("<li>");

      sb.Append(helper.ActionLink(linkText, actionName, controllerName));
      sb.Append("</li>");
      return sb.ToString();
    }

		public static string CheckBoxList(this HtmlHelper helper, IList<string> selectedItems, 
			IEnumerable<string> items, string propertyName)
		{
			StringBuilder stringBuilder = new StringBuilder();

			foreach (string item in items)
			{
				bool selected = selectedItems != null && selectedItems.Contains(item);
				// Add the checkbox
				stringBuilder.AppendFormat("<input name=\"{0}\" id=\"{0}\" type=\"checkbox\" value=\"{1}\" {2}>{1}</input><br />",
					propertyName, item, selected ? "checked" : "");
			}

			return stringBuilder.ToString();
		}
  }
}
