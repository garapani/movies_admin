using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
