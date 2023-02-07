using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Memories.Data.Enum;
using Memories.Validation;

namespace Memories.Models
{
    public class FamilyMember
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MemberImage { get; set; } = "";

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }

        public FamilyCategory FamilyCategory { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
