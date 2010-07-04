using System.Collections.Generic;
using CommunityCourses.Web.Model;

namespace CommunityCourses.Web.ViewModel
{
	public class CourseViewModel : Course
	{
		public CourseViewModel()
		{
			Unit = new Unit();
			Centre = new Centre();
			Tutor = new Person();
			Verifier = new Person();
			Students = new List<Person>();
		}

		public Unit Unit { get; set; }
		public Centre Centre { get; set; }
		public Person Tutor { get; set; }
		public Person Verifier { get; set; }
		public IList<Person> Students { get; set; }
	}
}
