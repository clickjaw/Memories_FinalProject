using System;
using System.ComponentModel.DataAnnotations.Schema;
using Memories.Data.Enum;

namespace Memories.Models
{
	public class Family
	{
		public int Id { get; set; }
		public string FamilyName { get; set; }
		public string Image { get; set; }

		public FamilyCategory FamilyCategory { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("AppUser")]
		public string? AppUserId { get; set; }
		public AppUser? AppUser { get; set; }


	}
}

