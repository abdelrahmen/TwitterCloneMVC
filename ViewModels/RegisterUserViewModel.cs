using System.ComponentModel.DataAnnotations;

namespace TwitterClone.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name{ get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}