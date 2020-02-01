using System.ComponentModel.DataAnnotations;

namespace API.ViewModels.User
{
    public class UserViewModelEntrada
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength =4, ErrorMessage = "You must specify password between 4 and 8 letters")]
        public string Password { get; set; }
    }
}
