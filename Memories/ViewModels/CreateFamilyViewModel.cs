using System;
using Memories.Data.Enum;
using Memories.Models;

namespace Memories.ViewModels
{
	public class CreateFamilyViewModel
	{
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public IFormFile Image { get; set; }

        public FamilyCategory FamilyCategory { get; set; }

        public string ApplicationUserId { get; set; }
    }
}

