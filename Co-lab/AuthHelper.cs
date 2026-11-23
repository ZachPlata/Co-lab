using System;
using System.Security.Cryptography;
using System.Text;

namespace Co_LAB
{
    public static class AuthHelper
    {
        private const string HashPrefix = "PBKDF2";
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100_000;

        /// <summary>
        /// Hashes a password using salted PBKDF2-HMAC-SHA256.
        /// </summary>
        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);
            return $"{HashPrefix}${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
        }

        /// <summary>
        /// Returns true if the stored credential uses the PBKDF2 hash format.
        /// </summary>
        public static bool IsHashed(string? storedPassword)
        {
            return !string.IsNullOrEmpty(storedPassword) &&
                   storedPassword.StartsWith(HashPrefix + "$", StringComparison.Ordinal);
        }

        /// <summary>
        /// Verifies an input password against a salted PBKDF2 hash (or legacy plaintext for migration) in constant time.
        /// </summary>
        public static bool VerifyPassword(string inputPassword, string storedPassword)
        {
            if (inputPassword == null || string.IsNullOrEmpty(storedPassword))
            {
                return false;
            }

            if (IsHashed(storedPassword))
            {
                string[] parts = storedPassword.Split('$');
                if (parts.Length != 4 ||
                    !string.Equals(parts[0], HashPrefix, StringComparison.Ordinal) ||
                    !int.TryParse(parts[1], out int iterations) ||
                    iterations <= 0)
                {
                    return false;
                }

                try
                {
                    byte[] salt = Convert.FromBase64String(parts[2]);
                    byte[] expectedHash = Convert.FromBase64String(parts[3]);
                    byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                        inputPassword,
                        salt,
                        iterations,
                        HashAlgorithmName.SHA256,
                        expectedHash.Length);
                    return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            byte[] inputBytes = Encoding.UTF8.GetBytes(inputPassword);
            byte[] storedBytes = Encoding.UTF8.GetBytes(storedPassword);
            return CryptographicOperations.FixedTimeEquals(inputBytes, storedBytes);
        }
    }
}



