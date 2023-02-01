using System;
namespace Memories.Models
{
	public class AppUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FamilyName { get; set; }
		public Address? Address { get; set; }

		public ICollection<Family> Families { get; set; }

	}
}

