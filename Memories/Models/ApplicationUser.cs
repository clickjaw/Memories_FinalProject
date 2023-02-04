using System;
using System.ComponentModel.DataAnnotations;

namespace Memories.Models
{
	public class ApplicationUser
	{
		[Key]
		public string Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? FamilyName { get; set; }
		public Address? Address { get; set; }

		public ICollection<Family>? Families { get; set; }

	}
}

