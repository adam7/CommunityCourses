using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CommunityCourses.Web.Model
{
	public class Course
	{
		public Course()
		{
			StudentIds = new List<string>();
		}

		public string Id { get; set; }

		[Required]
		[DisplayName("Centre")]
		public string CentreId { get; set; }
		
		public string Status
		{
			get
			{
				DateTime today = DateTime.Today;
				if (StartDate > today)
				{
					return "Upcoming";
				}
				else
				{
					if (StartDate < today && EndDate > today)
					{
						return "Started";
					}
					else
					{
						return "Finished";
					}
				}
			}
		}

		[Required]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
		[DisplayName("Start date")]
		public DateTime? StartDate { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
		[DisplayName("End date")]
		public DateTime? EndDate { get; set; }

		[Required]
		[DisplayName("Unit")]
		public string UnitId { get; set; }

		[Required]
		[DisplayName("Tutor")]
		public string TutorId { get; set; }

		[DisplayName("Verifier")]
		public string VerifierId { get; set; }
		
		public IList<string> StudentIds { get; set; }
	}
}