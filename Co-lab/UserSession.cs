using System;

namespace Co_LAB
{
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string FullName { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;
        public static bool IsLoggedIn { get; set; }

        public static void Set(int userId, string fullName, string email, string role)
        {
            UserId = userId;
            FullName = fullName ?? string.Empty;
            Email = email ?? string.Empty;
            Role = role ?? string.Empty;
            IsLoggedIn = true;
        }

        public static void Clear()
        {
            UserId = 0;
            FullName = string.Empty;
            Email = string.Empty;
            Role = string.Empty;
            IsLoggedIn = false;
        }
    }
}

