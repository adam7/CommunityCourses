using System.ComponentModel.DataAnnotations;

namespace StudentTracking.Data.Model
{
  [MetadataType(typeof(AddressValidation))]
  public partial class Address
  {
    public string ToSingleLine()
    {
      return string.Format("{0}, {1}, {2}", FirstLine, City, Postcode);
    }
  }

  public partial class AddressValidation
  {
    [Required]
    public string FirstLine;

    [Required]
    [RegularExpression(@"^(GIR|[A-Z]\d[A-Z\d]??|[A-Z]{2}\d[A-Z\d]??)[ ]??(\d[A-Z]{2})$")]
    public string Postcode;

    [Required]
    public string City;
  }
}
