using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace lab1.Models.ViewModel
{
    public class EditUserVM
    {

        [Required]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

       
        public IList<string> UserRoles { get; set; }= new List<string>();

       
        public List<IdentityRole> AllRoles { get; set; } = new List<IdentityRole>();

        public List<string> SelectedRoles { get; set; } = new List<string>();
    }
}
