namespace DevStage.Api.Infrastructure.Security.Cryptography
{
    public class BCryptAlgorithms
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public bool VerifyPassword(string password, string hashPassword) => BCrypt.Net.BCrypt.Verify(password, hashPassword);
    }
}
