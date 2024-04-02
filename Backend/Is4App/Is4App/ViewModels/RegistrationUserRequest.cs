using System.ComponentModel.DataAnnotations;

namespace Is4App.ViewModels
{
    public class RegistrationUserRequest
    {
        [Required]
        [MaxLength(25)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(13)]
        public string NumberPhone { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
