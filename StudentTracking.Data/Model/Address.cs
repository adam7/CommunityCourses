using System.ComponentModel.DataAnnotations;

namespace StudentTracking.Data.Model
{
  public partial class Address
  {
    public string ToSingleLine()
    {
      return string.Format("{0}, {1}, {2}", FirstLine, City, Postcode);
    }
  }
}
