using System.ComponentModel.DataAnnotations;

namespace lab1.Models.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        // public string Email { get; set; }
        [Required,MinLength(4),MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [Compare("Password",ErrorMessage ="Password Do't Match ")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
