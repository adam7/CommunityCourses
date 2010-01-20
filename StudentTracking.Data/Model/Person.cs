using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using xVal;

namespace StudentTracking.Data.Model
{
  [MetadataType(typeof(PersonValidation))]
  public partial class Person
  {
    public string Name
    {
      get { return string.Format("{0} {1} {2}", Title, FirstName, LastName); }
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
