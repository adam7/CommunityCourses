using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StudentTracking.Data.Model
{
  [MetadataType(typeof(PersonValidation))]
  public partial class Person
  {
    public string Name
    {
      get { return string.Format("{0} {1} {2}", Title, FirstName, LastName); }
    }

		public static List<Person> GetAllTutors()
		{
			IQueryable<Person> query = from people in Person.All()
																 join tutors in Tutor.All()
																 on people.Id equals tutors.PersonId
																 select people;
			return query.ToList();
		}

		public static List<Person> GetAllVerifiers()
		{
			IQueryable<Person> query = from people in Person.All()
																 join verifiers in Verifier.All()
																 on people.Id equals verifiers.PersonId
																 select people;
			return query.ToList();
		}
  }

  public partial class PersonValidation
  {
    [Required]
    public string Title;

    [Required]
    public string FirstName;

    [Required]
    public string LastName;

		[Required]
		public int? EthnicityId;
		
		[Required]
		public int? DisabilityId;

    [DataType(DataType.PhoneNumber)]
    public string Phone;

    [DataType(DataType.PhoneNumber)]
    public string Mobile;

    [DataType(DataType.EmailAddress)]
    public string Email;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth;

		[RegularExpression("[0-9]{12}")]
		public string CriminalRecordsBureauReferenceNumber;
  }

}
