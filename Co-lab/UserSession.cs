using System;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string FullName { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;
        public static string SessionId { get; set; } = string.Empty;
        public static bool IsLoggedIn { get; set; }
        public static bool SignedOut { get; set; }

        public static void Set(int userId, string fullName, string email, string role, string sessionId = "")
        {
            UserId = userId;
            FullName = fullName ?? string.Empty;
            Email = email ?? string.Empty;
            Role = role ?? string.Empty;
            SessionId = sessionId ?? string.Empty;
            IsLoggedIn = true;
            SignedOut = false;
        }

        public static void Heartbeat()
        {
            if (UserId <= 0) return;
            try
            {
                using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "UPDATE tbl_users SET last_active = NOW() WHERE UserId = @uid";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@uid", UserId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
        }

        public static void EndSession()
        {
            try
            {
                if (UserId > 0)
                {
                    using MySqlConnection conn = new MySqlConnection("server=localhost; database=db_colab; uid=root");
                    MySqlCommand cmd = new MySqlCommand();
                    conn.Open();
                    cmd.CommandText = "UPDATE tbl_users SET is_logged_in = 0, session_id = NULL WHERE UserId = @uid";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@uid", UserId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch { }
            finally
            {
                Clear();
            }
        }

        public static void Clear()
        {
            UserId = 0;
            FullName = string.Empty;
            Email = string.Empty;
            Role = string.Empty;
            SessionId = string.Empty;
            IsLoggedIn = false;
        }
    }
}
