using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StudentTracking.Data.Model
{
  [MetadataType(typeof(CentreValidation))]
  public partial class Centre
  {
    //public Address Address
    //{
    //  get { return Addresses.FirstOrDefault() ?? new Address(); }
    //  set { AddressId = value.Id; }
    //}
  }

  public class CentreValidation
  {
    [Required]
    public string Name;

    [Required]
    public string Phone;
  }

}
