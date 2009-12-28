using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentTracking.Data.Repository;

namespace StudentTracking.Data.Model
{
  [MetadataType(typeof(CourseValidation))]
  public partial class Course
  {
    public IEnumerable<Student> Students
    {
      get
      {
        return new StudentRepository().GetByCourse(Id);
      }
    }
  }

  public class CourseValidation
  {
    [Required]
    public int? CentreId;

    [Required]
    public string Name;

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate;

    [Required]
    public int? UnitId;

    [Required]
    public int? TutorId;  
  }
}
