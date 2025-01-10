using System.ComponentModel.DataAnnotations;

namespace FlashCards.Server.Models.DTO.Requests
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public string? Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}
