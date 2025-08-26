using System;
using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required"), EmailAddress, StringLength(50)]
        public string? Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string? PasswordHash { get; set; }

        [Required]
        [RegularExpression("Admin|User", ErrorMessage = "Role must be either Admin or User")]
        public string Role { get; set; } = "User";
    }
}