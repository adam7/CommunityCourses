using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentTracking.Web.ViewModel
{
	public class CentreViewModel
	{
			public int Id { get; set; }

			[Required]
			public string Name {get; set; }

			[Required]
			public string Phone { get; set; }

			public AddressViewModel Address { get; set; }
	}
}
