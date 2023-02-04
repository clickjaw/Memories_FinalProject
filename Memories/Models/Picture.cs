using System;
namespace Memories.Models
{
	public class Picture
	{
		public int Id { get; set; }

		public ApplicationUser? ApplicationUser { get; set; }

		public string FamilyMemberName { get; set; }
		

		public string? OtherName { get; set; }
		public string? OtherName2 { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Family> Families { get; set; }



    }
}

