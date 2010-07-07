using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CommunityCourses.Web.Model
{
	public class Address
	{
		[Required]
		[DisplayName("First line")]
		public string FirstLine { get; set; }

		[Required]
		[RegularExpression(@"^(GIR|[A-Z]\d[A-Z\d]??|[A-Z]{2}\d[A-Z\d]??)[ ]??(\d[A-Z]{2})$")]
		public string Postcode { get; set; }

		[Required]
		public string City { get; set; }

		public string ToSingleLine()
		{
			return string.Format("{0}, {1}, {2}", FirstLine, City, Postcode);
		}
	}
}
