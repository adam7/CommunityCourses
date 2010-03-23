using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTracking.Data.Model;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System.Web.Mvc;
using StudentTracking.Data.Enum;


namespace StudentTracking.Web.ViewModel
{
	public class PersonViewModel
	{

		#region Properties (12) 

		[RegularExpression("[0-9]{12}")]
		public string CriminalRecordsBureauReferenceNumber { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime? DateOfBirth { get; set; }

		public string[] Disabilities { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		public int EthnicityId { get; set; }

		public string EthnicityName { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public int? GenderId { get; set; }

		[Required]
		public string LastName { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string Mobile { get; set; }

		public string Notes { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }

		[Required]
		public string Title { get; set; }

		#endregion Properties 		

		public SelectList GetGenderSelectList()
		{
			var values = from Gender gender in Enum.GetValues(typeof(Gender))
									 select new { Id = (int)gender, Name = gender.ToString() };

			return new SelectList(values, "Id", "Name", GenderId);
		}
	}
}
