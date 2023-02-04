using System;
using System.ComponentModel.DataAnnotations.Schema;
using Memories.Data.Enum;

namespace Memories.Models
{
	public class Family
	{
		public int Id { get; set; }
		public string? FamilyName { get; set; }
		public string? Image { get; set; }
		public string? FamilyMemberName { get; set; }

		public FamilyCategory FamilyCategory { get; set; }

		[ForeignKey("FamilyMember")]
		public int FamilyMemberId { get; set; }
		public FamilyMember FamilyMember { get; set; }


        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }


    }
}

