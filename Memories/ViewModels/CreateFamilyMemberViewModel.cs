using System;
using Memories.Data.Enum;
using Memories.Models;

namespace Memories.ViewModels
{
    public class CreateFamilyMemberViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile MemberImage { get; set; }

        public FamilyCategory FamilyCategory { get; set; }

        public string ApplicationUserId { get; set; }
    }
}

