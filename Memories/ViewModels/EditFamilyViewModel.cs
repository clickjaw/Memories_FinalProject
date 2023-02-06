using System.Net;
using Memories.Data.Enum;
using Memories.Models;

namespace Memories.ViewModels
{
    public class EditFamilyViewModel
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }

        public FamilyCategory FamilyCategory { get; set; }
    }
}