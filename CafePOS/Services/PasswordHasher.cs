namespace CafePOS.Services
{
    public static class PasswordHasher
    {
        public static string Hash(string pin)
        {
            return BCrypt.Net.BCrypt.HashPassword(pin);
        }

        public static bool Verify(string pin, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(pin, hash);
        }
    }
}
