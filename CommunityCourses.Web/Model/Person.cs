using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CommunityCourses.Web.Model
{
	public class Person
	{
		public Person()
		{
			Address = new Address();
			CourseModules = new List<CourseModule>();
			CourseSessions = new List<CourseSession>();
			Disabilities = new List<string>();
			Roles = new List<string>();
		}

		public string Name
		{
			get { return string.Format("{0} {1} {2}", Title, FirstName, LastName); }
		}

		/// <summary>
		/// e.g. Student, Tutor etc.
		/// </summary>
		public List<string> Roles { get; set; }

		public string Id { get; set; }

		[RegularExpression("[0-9]{12}")]
		[DisplayName("CRB number")]
		public string CriminalRecordsBureauReferenceNumber { get; set; }
		
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
		[DisplayName("CRB expiry date")]
		public DateTime? CriminalRecordsBureauExpiryDate { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
		[DisplayName("Date of birth")]
		public DateTime? DateOfBirth { get; set; }

		public List<string> Disabilities { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		public string Ethnicity { get; set; }

		[Required]
		[DisplayName("First name")]
		public string FirstName { get; set; }

		[Required]
		public string Gender { get; set; }

		[Required]
		[DisplayName("Last name")]
		public string LastName { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string Mobile { get; set; }

		public string Notes { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }

		[Required]
		public string Title { get; set; }

		public Address Address { get; set; }

		public IList<CourseSession> CourseSessions { get; set; }
		public IList<CourseModule> CourseModules { get; set; }
	}
}