using System;

namespace Co_LAB
{
    public static class AuthHelper
    {
        // TODO: Replace plain-text password hashing with BCrypt (e.g. BCrypt.Net-Next) in production.
        public static string HashPassword(string password)
        {
            // Plain-text pass-through for now
            return password;
        }

        // TODO: Replace plain-text password comparison with BCrypt verification in production.
        public static bool VerifyPassword(string inputPassword, string storedPassword)
        {
            // Plain-text comparison for now
            return string.Equals(inputPassword, storedPassword, StringComparison.Ordinal);
        }
    }
}



