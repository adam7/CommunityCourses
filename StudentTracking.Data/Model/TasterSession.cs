using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTracking.Data.Model;
using StudentTracking.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace StudentTracking.Data.Model
{
  [MetadataType(typeof(TasterSessionValidation))]
  public partial class TasterSession
  {
    public IEnumerable<Student> Students
    {
      get
      {
        return new StudentRepository().GetByTasterSession(Id);
      }
    }
  }

  public class TasterSessionValidation
  {
    [Required]
    public string Name;

    [Required]
    public int? CentreId;

    [Required]
    public int? TutorId;

    [Required]
    [DataType(DataType.Date)]
    public DateTime? DateAndTime;
  }
}
