using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CommunityCourses.Web.Model
{
	public class Centre
	{
		public string Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Phone { get; set; }
		[DisplayName("Contact")]
		public string ContactId { get; set; }
		public string ContactName { get; set; }
        public Address Address { get; set; }
	}
}