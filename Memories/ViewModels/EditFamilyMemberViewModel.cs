using System;
using Memories.Data.Enum;

namespace Memories.ViewModels
{
	public class EditFamilyMemberViewModel
	{
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public IFormFile MemberImage { get; set; }
        public string? URL { get; set; }


        public FamilyCategory FamilyCategory { get; set; }
    }
}

