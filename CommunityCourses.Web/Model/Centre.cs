using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CommunityCourses.Web.Model
{
	public class Centre
	{
		public string Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]		
		public string Phone { get; set; }
		public Person Contact { get; set; }
		public Address Address { get; set; }
	}
}