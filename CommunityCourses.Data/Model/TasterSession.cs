using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityCourses.Data.Model
{
  [MetadataType(typeof(TasterSessionValidation))]
  public partial class TasterSession
  {
    public IEnumerable<Student> Students
    {
      get
      {
        return Student.GetByTasterSession(Id);
      }
    }

		public static void AddStudentToTasterSession(int studentId, int id)
		{
			StudentTasterSession studentTasterSession =
				new StudentTasterSession { StudentId = studentId, TasterSessionId = id, };

			studentTasterSession.Add();
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
