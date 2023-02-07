using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Memories.Data;

namespace Memories.Models
{
	public class ApplicationUser:IdentityUser
	{
		//[Key]
		//public string Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? FamilyName { get; set; }

		//public string? UserRoles { get; set; }

		//[ForeignKey("Address")]
		//public int? AddressId { get; set; }
		//public Address? Address { get; set; }

		public ICollection<Family> Families { get; set; }
		public ICollection<FamilyMember> FamilyMembers { get; set; }

	}
}

