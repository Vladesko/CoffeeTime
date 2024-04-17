using System.ComponentModel.DataAnnotations;

namespace Is4App.ViewModels
{
    public class LoginUserRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
