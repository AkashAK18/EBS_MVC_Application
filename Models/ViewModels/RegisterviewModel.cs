using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required, StringLength(50)]
        public string UserName { get; set; } = null!;

        [Required, EmailAddress, StringLength(256)]
        public string Email { get; set; } = null!

;        [Required, StringLength(100, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required, DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
