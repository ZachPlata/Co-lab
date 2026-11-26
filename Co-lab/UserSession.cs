using System;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    public enum HeartbeatResult
    {
        Ok,
        Blacklisted,
        SessionInvalid,
        Offline
    }

    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string FullName { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;
        public static string SessionId { get; set; } = string.Empty;
        public static bool IsVerified { get; set; }
        public static string VerificationStatus { get; set; } = "Pending";
        public static bool IsLoggedIn { get; set; }
        public static bool SignedOut { get; set; }

        public static void Set(
            int userId,
            string fullName,
            string email,
            string role,
            string sessionId = "",
            bool isVerified = true,
            string verificationStatus = "Verified")
        {
            UserId = userId;
            FullName = fullName ?? string.Empty;
            Email = email ?? string.Empty;
            Role = role ?? string.Empty;
            SessionId = sessionId ?? string.Empty;
            IsVerified = isVerified;
            VerificationStatus = string.IsNullOrWhiteSpace(verificationStatus)
                ? (isVerified ? "Verified" : "Pending")
                : verificationStatus;
            IsLoggedIn = true;
            SignedOut = false;
        }

        public static void Heartbeat()
        {
            Heartbeat(out _);
        }

        public static HeartbeatResult Heartbeat(out string banReason)
        {
            banReason = string.Empty;
            if (UserId <= 0) return HeartbeatResult.Ok;

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using (MySqlCommand checkCmd = new MySqlCommand(
                    @"SELECT is_blacklisted, BanReason, session_id, is_verified, VerificationStatus
                      FROM tbl_users WHERE UserId = @uid LIMIT 1", conn))
                {
                    checkCmd.Parameters.AddWithValue("@uid", UserId);
                    using MySqlDataReader reader = checkCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        bool isBlacklisted = reader["is_blacklisted"] != DBNull.Value &&
                                             Convert.ToInt32(reader["is_blacklisted"]) == 1;
                        if (isBlacklisted)
                        {
                            banReason = reader["BanReason"]?.ToString() ?? string.Empty;
                            return HeartbeatResult.Blacklisted;
                        }

                        string dbSessionId = reader["session_id"]?.ToString() ?? string.Empty;
                        if (!string.IsNullOrEmpty(SessionId) &&
                            !string.Equals(dbSessionId, SessionId, StringComparison.Ordinal))
                        {
                            return HeartbeatResult.SessionInvalid;
                        }

                        bool dbVerified = reader["is_verified"] != DBNull.Value &&
                                          Convert.ToInt32(reader["is_verified"]) == 1;
                        string dbVerifStatus = reader["VerificationStatus"]?.ToString() ?? (dbVerified ? "Verified" : "Pending");
                        IsVerified = dbVerified || string.Equals(dbVerifStatus, "Verified", StringComparison.OrdinalIgnoreCase);
                        VerificationStatus = dbVerifStatus;
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand(
                    "UPDATE tbl_users SET last_active = NOW() WHERE UserId = @uid", conn))
                {
                    cmd.Parameters.AddWithValue("@uid", UserId);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                return HeartbeatResult.Ok;
            }
            catch (MySqlException)
            {
                return HeartbeatResult.Offline;
            }
            catch
            {
                return HeartbeatResult.Offline;
            }
        }

        public static void EndSession()
        {
            try
            {
                if (UserId > 0)
                {
                    using MySqlConnection conn = DatabaseHelper.GetConnection();
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
            IsVerified = false;
            VerificationStatus = "Pending";
            IsLoggedIn = false;
        }
    }
}
