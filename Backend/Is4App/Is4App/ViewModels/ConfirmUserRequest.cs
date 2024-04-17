namespace Is4App.ViewModels
{
    public class ConfirmUserRequest
    {
        public string Email { get; set; } = string.Empty;
        public int SecretCode { get; set; }
    }
}
