using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SubSonic.Schema;
using xVal.ServerSide;
using StudentTracking.Data.Model;
using SubSonic.Repository;
using System;
using System.Reflection;

namespace StudentTracking.Data.Extensions
{
	public static class IActiveRecordExtension
	{
		public static IEnumerable<ErrorInfo> GetErrors(this IActiveRecord instance)
		{
			var metadataAttrib = instance.GetType().GetCustomAttributes(typeof(MetadataTypeAttribute), true).OfType<MetadataTypeAttribute>().FirstOrDefault();
			var buddyClassOrModelClass = metadataAttrib != null ? metadataAttrib.MetadataClassType : instance.GetType();
			var buddyClassProperties = TypeDescriptor.GetProperties(buddyClassOrModelClass).Cast<PropertyDescriptor>();
			var modelClassProperties = TypeDescriptor.GetProperties(instance.GetType()).Cast<PropertyDescriptor>();

			return from buddyProp in buddyClassProperties
						 join modelProp in modelClassProperties on buddyProp.Name equals modelProp.Name
						 from attribute in buddyProp.Attributes.OfType<ValidationAttribute>()
						 where !attribute.IsValid(modelProp.GetValue(instance))
						 select new ErrorInfo(buddyProp.Name, attribute.FormatErrorMessage(string.Empty), instance);
		}

		public static bool IsValid(this IActiveRecord instance)
		{
			return !GetErrors(instance).Any();
		}
	}
}
