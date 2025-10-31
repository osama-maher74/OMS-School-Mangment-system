using System.ComponentModel.DataAnnotations;

namespace lab1.Models.ViewModel
{
    public class LoginVM
    {
        [Required]
        public string UsserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
