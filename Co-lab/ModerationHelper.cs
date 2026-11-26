using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    public static class ModerationHelper
    {
        public static bool IsAdminUser(int userId)
        {
            if (userId <= 0) return false;
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using MySqlCommand cmd = new MySqlCommand(
                    "SELECT Role FROM tbl_users WHERE UserId = @uid LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@uid", userId);
                object? roleObj = cmd.ExecuteScalar();
                return string.Equals(roleObj?.ToString(), "Admin", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public static void BlacklistStudent(int targetUserId, string banReason, int? reportId = null)
        {
            using MySqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using MySqlTransaction tx = conn.BeginTransaction();

            try
            {
                string targetEmail = string.Empty;
                string targetName = string.Empty;
                using (MySqlCommand userLookup = new MySqlCommand(
                    "SELECT FullName, Email, Role FROM tbl_users WHERE UserId = @uid LIMIT 1", conn, tx))
                {
                    userLookup.Parameters.AddWithValue("@uid", targetUserId);
                    using MySqlDataReader r = userLookup.ExecuteReader();
                    if (r.Read())
                    {
                        targetName = r["FullName"]?.ToString() ?? string.Empty;
                        targetEmail = r["Email"]?.ToString() ?? string.Empty;
                        string role = r["Role"]?.ToString() ?? "Student";
                        if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            throw new InvalidOperationException("Admin accounts cannot be blacklisted.");
                        }
                    }
                }

                using (MySqlCommand userCmd = new MySqlCommand(
                    @"UPDATE tbl_users
                      SET is_blacklisted = 1, BanReason = @reason, is_logged_in = 0, session_id = NULL
                      WHERE UserId = @uid", conn, tx))
                {
                    userCmd.Parameters.AddWithValue("@reason", banReason);
                    userCmd.Parameters.AddWithValue("@uid", targetUserId);
                    userCmd.ExecuteNonQuery();
                }

                using (MySqlCommand skillCmd = new MySqlCommand(
                    "UPDATE tbl_skills SET Status = 'Paused' WHERE UserId = @uid AND Status = 'Active'", conn, tx))
                {
                    skillCmd.Parameters.AddWithValue("@uid", targetUserId);
                    skillCmd.ExecuteNonQuery();
                }

                var affectedTrades = new List<(int RequestId, string CounterpartyEmail, string SkillTitle)>();
                using (MySqlCommand findTradesCmd = new MySqlCommand(
                    @"SELECT r.RequestId, s.SkillTitle,
                             CASE
                                 WHEN s.UserId = @uid THEN r.SenderEmail
                                 ELSE ownerU.Email
                             END AS CounterpartyEmail
                      FROM tbl_traderequests r
                      INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId
                      LEFT JOIN tbl_users ownerU ON s.UserId = ownerU.UserId
                      WHERE r.Status = 'Pending'
                        AND (s.UserId = @uid OR (@email != '' AND r.SenderEmail = @email) OR (@name != '' AND r.SenderName = @name))",
                    conn, tx))
                {
                    findTradesCmd.Parameters.AddWithValue("@uid", targetUserId);
                    findTradesCmd.Parameters.AddWithValue("@email", targetEmail);
                    findTradesCmd.Parameters.AddWithValue("@name", targetName);

                    using MySqlDataReader r = findTradesCmd.ExecuteReader();
                    while (r.Read())
                    {
                        int reqId = Convert.ToInt32(r["RequestId"]);
                        string cpEmail = r["CounterpartyEmail"]?.ToString() ?? string.Empty;
                        string skillTitle = r["SkillTitle"]?.ToString() ?? "Skill";
                        affectedTrades.Add((reqId, cpEmail, skillTitle));
                    }
                }

                if (affectedTrades.Count > 0)
                {
                    using MySqlCommand declineTradesCmd = new MySqlCommand(
                        @"UPDATE tbl_traderequests r
                          INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId
                          SET r.Status = 'Declined'
                          WHERE r.Status = 'Pending'
                            AND (s.UserId = @uid OR (@email != '' AND r.SenderEmail = @email) OR (@name != '' AND r.SenderName = @name))",
                        conn, tx);
                    declineTradesCmd.Parameters.AddWithValue("@uid", targetUserId);
                    declineTradesCmd.Parameters.AddWithValue("@email", targetEmail);
                    declineTradesCmd.Parameters.AddWithValue("@name", targetName);
                    declineTradesCmd.ExecuteNonQuery();
                }

                if (reportId.HasValue && reportId.Value > 0)
                {
                    using MySqlCommand repCmd = new MySqlCommand(
                        "UPDATE tbl_reports SET Status = 'Reviewed' WHERE ReportId = @id", conn, tx);
                    repCmd.Parameters.AddWithValue("@id", reportId.Value);
                    repCmd.ExecuteNonQuery();
                }

                tx.Commit();
                conn.Close();

                foreach (var trade in affectedTrades)
                {
                    if (!string.IsNullOrWhiteSpace(trade.CounterpartyEmail))
                    {
                        NotificationHelper.SendNotification(
                            null,
                            trade.CounterpartyEmail,
                            "Student",
                            "⚠️ Trade Request Cancelled",
                            $"Your pending trade for \"{trade.SkillTitle}\" was automatically declined because the other account was suspended.",
                            "TradeUpdate",
                            trade.RequestId);
                    }
                }
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }
}
