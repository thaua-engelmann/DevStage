namespace DevStage.Api.Infrastructure.Security.Cryptography
{
    public class BCryptAlgorithms
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    }
}
