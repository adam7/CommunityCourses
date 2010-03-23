using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using StudentTracking.Data.Model;

namespace StudentTracking.Web.ViewModel
{
	public class AddressViewModel
	{
		public AddressViewModel() : this(null) { }

		public AddressViewModel(Address address)
		{
			if (address != null)
			{
				FirstLine = address.FirstLine;
				Postcode = address.Postcode;
				City = address.City;
			}
		}

		[Required]
		public string FirstLine { get; set; }

		[Required]
		[RegularExpression(@"^(GIR|[A-Z]\d[A-Z\d]??|[A-Z]{2}\d[A-Z\d]??)[ ]??(\d[A-Z]{2})$")]
		public string Postcode { get; set; }

		[Required]
		public string City { get; set; }
	}
}
