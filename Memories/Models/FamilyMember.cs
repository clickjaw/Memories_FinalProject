using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Memories.Models
{
	public class FamilyMember
	{
		[Key]

		//public int Id { get; set; }
		//public string? FirstName { get; set; } = "Bettye";
		//public string? LastName { get; set; } = "Morgan";
		//public string? MemberImage { get; set; } = "https://i.imgur.com/sFnheBI.jpg";

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MemberImage { get; set; }

		[ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}

