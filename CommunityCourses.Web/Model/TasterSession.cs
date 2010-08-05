using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CommunityCourses.Web.Model
{
	public class TasterSession
	{
		public TasterSession()
		{
			Students = new List<Person>();
		}

		public string Id { get; set; }

		[DisplayName("Centre")]
		public string CentreId { get; set; }

		public string CentreName { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[DisplayName("Tutor")]
		public string TutorId { get; set; }

		public string TutorName { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
		[DisplayName("Date")]
		public DateTime? DateAndTime { get; set; }

		public IList<Person> Students { get; set; }
	}
}