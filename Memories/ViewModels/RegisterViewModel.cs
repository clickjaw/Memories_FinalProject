using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Memories.Data.Enum;
using Memories.Models;

namespace Memories.ViewModels
{
	public class RegisterViewModel
	{
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [ForeignKey("FamilyMember")]
        public int? FamilyMemberId { get; set; }
        public FamilyMember? FamilyMember { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage ="Confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public FamilyCategory FamilyCategory { get; set; }
    }
}

