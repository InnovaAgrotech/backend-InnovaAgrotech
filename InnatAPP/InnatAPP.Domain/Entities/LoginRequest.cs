namespace InnatAPP.Domain.Entities
{
    public class LoginRequest
    {
        public string Email { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;
    }
}