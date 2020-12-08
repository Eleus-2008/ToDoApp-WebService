using System.ComponentModel.DataAnnotations;

namespace ToDoAppWebService.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Should be a valid email")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Should be minimum 8 characters")]
        public string Password { get; set; }
    }
}