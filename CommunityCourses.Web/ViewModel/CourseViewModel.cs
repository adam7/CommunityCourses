using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CommunityCourses.Data.Enum;

namespace CommunityCourses.Web.ViewModel
{


	public class CourseViewModel
	{
		public int Id { get; set; }

		[Required]
		public int CentreId { get; set; }

		public string CentreName { get; set; }

		public CourseStatus Status
		{
			get
			{
				DateTime today = DateTime.Today;
				if (StartDate > today)
				{
					return CourseStatus.Upcoming;
				}
				else
				{
					if (StartDate < today && EndDate > today)
					{
						return CourseStatus.Started;
					}
					else
					{
						return CourseStatus.Finished;
					}
				}
			}
		}

		[Required]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime? StartDate { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime? EndDate { get; set; }

		[Required]
		public int UnitId { get; set; }

		public string UnitName { get; set; }

		[Required]
		public int TutorId { get; set; }

		public string TutorPersonName { get; set; }

		public int? VerifierId { get; set; }

		public string VerifierPersonName { get; set; }

		public IList<CourseStudentViewModel> Students { get; set; }
		public IEnumerable<StudentCourseModuleViewModel> Modules { get; set; }
		public IEnumerable<StudentCourseSessionViewModel> Sessions { get; set; }
	}
}
