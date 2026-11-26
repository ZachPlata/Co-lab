using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    public static class NotificationHelper
    {
        /// <summary>
        /// Inserts a notification record into tbl_notifications.
        /// </summary>
        public static void SendNotification(
            int? userId,
            string? userEmail,
            string targetRole,
            string title,
            string message,
            string type = "Info",
            int? relatedId = null)
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = @"INSERT INTO tbl_notifications 
                    (UserId, UserEmail, TargetRole, Title, Message, Type, RelatedId, IsRead, CreatedAt)
                    VALUES 
                    (@uid, @email, @role, @title, @msg, @type, @relId, 0, NOW())";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@uid", userId.HasValue ? userId.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(userEmail) ? (object)DBNull.Value : userEmail.Trim());
                cmd.Parameters.AddWithValue("@role", targetRole);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@msg", message);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@relId", relatedId.HasValue ? relatedId.Value : (object)DBNull.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to send notification: {ex.Message}");
            }
        }

        /// <summary>
        /// Sends a notification to the skill listing owner when a student proposes a trade.
        /// </summary>
        public static void NotifyTradeRequest(int requestId, int targetSkillId, string skillTitle, string senderName, string senderEmail)
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = "SELECT s.UserId, s.OfferedBy, u.Email FROM tbl_skills s LEFT JOIN tbl_users u ON s.UserId = u.UserId WHERE s.SkillId = @sid LIMIT 1";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@sid", targetSkillId);
                da.SelectCommand = cmd;
                da.Fill(ds, "skill");
                conn.Close();

                DataTable dt = ds.Tables["skill"]!;
                if (dt != null && dt.Rows.Count > 0)
                {
                    int? ownerId = dt.Rows[0]["UserId"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["UserId"]) : null;
                    string ownerEmail = dt.Rows[0]["Email"]?.ToString() ?? "";

                    SendNotification(
                        ownerId,
                        ownerEmail,
                        "Student",
                        "🤝 New Trade Request",
                        $"{senderName} sent you a trade proposal for your skill \"{skillTitle}\".",
                        "TradeRequest",
                        requestId);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating trade request notification: {ex.Message}");
            }
        }

        /// <summary>
        /// Sends a notification to the proposal sender when their request is Accepted, Declined, or Completed.
        /// </summary>
        public static void NotifyTradeStatusUpdate(int requestId, string newStatus, string actionByName = "")
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = @"SELECT r.SenderName, r.SenderEmail, s.SkillTitle, s.OfferedBy 
                                    FROM tbl_traderequests r 
                                    INNER JOIN tbl_skills s ON r.TargetSkillId = s.SkillId 
                                    WHERE r.RequestId = @rid LIMIT 1";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@rid", requestId);
                da.SelectCommand = cmd;
                da.Fill(ds, "req");
                conn.Close();

                DataTable dt = ds.Tables["req"]!;
                if (dt != null && dt.Rows.Count > 0)
                {
                    string senderEmail = dt.Rows[0]["SenderEmail"]?.ToString() ?? "";
                    string skillTitle = dt.Rows[0]["SkillTitle"]?.ToString() ?? "Skill";
                    string owner = string.IsNullOrWhiteSpace(actionByName) ? (dt.Rows[0]["OfferedBy"]?.ToString() ?? "Owner") : actionByName;

                    string title;
                    string message;
                    string type = "TradeUpdate";

                    if (string.Equals(newStatus, "Accepted", StringComparison.OrdinalIgnoreCase))
                    {
                        title = "✅ Trade Proposal Accepted!";
                        message = $"{owner} accepted your trade proposal for \"{skillTitle}\"! Check your Trade Requests to view details.";
                    }
                    else if (string.Equals(newStatus, "Declined", StringComparison.OrdinalIgnoreCase))
                    {
                        title = "❌ Trade Proposal Declined";
                        message = $"{owner} declined your trade proposal for \"{skillTitle}\".";
                    }
                    else if (string.Equals(newStatus, "Completed", StringComparison.OrdinalIgnoreCase))
                    {
                        title = "🎉 Skill Exchange Completed!";
                        message = $"Your trade exchange for \"{skillTitle}\" with {owner} has been marked as Completed.";
                    }
                    else
                    {
                        title = "ℹ️ Trade Request Updated";
                        message = $"Your trade proposal for \"{skillTitle}\" status updated to {newStatus}.";
                    }

                    SendNotification(null, senderEmail, "Student", title, message, type, requestId);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating trade status update notification: {ex.Message}");
            }
        }

        /// <summary>
        /// Sends a notification to administrators when a student submits an incident report.
        /// </summary>
        public static void NotifyAdminNewReport(string skillId, string skillTitle, string reportedUser, string reason, string reporterName)
        {
            try
            {
                string title = "🚩 New Incident Report";
                string message = $"Student {reporterName} reported \"{reportedUser}\" (Reason: {reason}) regarding listing \"{skillTitle}\".";

                int.TryParse(skillId, out int sid);

                SendNotification(null, null, "Admin", title, message, "Report", sid > 0 ? sid : null);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating admin report notification: {ex.Message}");
            }
        }

        /// <summary>
        /// Syncs existing pending reports and trade requests into tbl_notifications if not already present.
        /// </summary>
        public static void SyncExistingPendingNotifications()
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                // For Admin: Sync pending reports
                MySqlCommand cmdAdmin = new MySqlCommand();
                cmdAdmin.CommandText = @"
                    INSERT INTO tbl_notifications (TargetRole, Title, Message, Type, RelatedId, IsRead, CreatedAt)
                    SELECT 'Admin', '🚩 Pending Incident Report', 
                           CONCAT('Student ""', r.ReportedUser, '"" has a pending report: ', r.Reason), 
                           'Report', r.ReportId, 0, r.ReportDate
                    FROM tbl_reports r
                    WHERE r.Status = 'Pending'
                      AND NOT EXISTS (
                          SELECT 1 FROM tbl_notifications n 
                          WHERE n.TargetRole = 'Admin' AND n.Type = 'Report' AND n.RelatedId = r.ReportId
                      )";
                cmdAdmin.Connection = conn;
                cmdAdmin.ExecuteNonQuery();

                // For Students: Sync pending incoming trade requests
                MySqlCommand cmdStudents = new MySqlCommand();
                cmdStudents.CommandText = @"
                    INSERT INTO tbl_notifications (UserId, UserEmail, TargetRole, Title, Message, Type, RelatedId, IsRead, CreatedAt)
                    SELECT s.UserId, u.Email, 'Student', '🤝 Incoming Trade Request',
                           CONCAT(r.SenderName, ' sent a trade proposal for your skill ""', s.SkillTitle, '"".'),
                           'TradeRequest', r.RequestId, 0, r.RequestDate
                    FROM tbl_traderequests r
                    JOIN tbl_skills s ON r.TargetSkillId = s.SkillId
                    LEFT JOIN tbl_users u ON s.UserId = u.UserId
                    WHERE r.Status = 'Pending'
                      AND NOT EXISTS (
                          SELECT 1 FROM tbl_notifications n 
                          WHERE n.TargetRole = 'Student' AND n.Type = 'TradeRequest' AND n.RelatedId = r.RequestId
                      )";
                cmdStudents.Connection = conn;
                cmdStudents.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error syncing initial notifications: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the count of unread notifications for a user or admin.
        /// </summary>
        public static int GetUnreadCount(string userEmail, string role)
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM tbl_notifications WHERE TargetRole = 'Admin' AND IsRead = 0";
                }
                else
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM tbl_notifications WHERE TargetRole = 'Student' AND ((@email != '' AND UserEmail = @email) OR (UserId = @uid AND @uid > 0)) AND IsRead = 0";
                    cmd.Parameters.AddWithValue("@email", userEmail ?? string.Empty);
                    cmd.Parameters.AddWithValue("@uid", UserSession.UserId);
                }
                cmd.Connection = conn;

                int unread = 0;
                using MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() && reader[0] != DBNull.Value)
                {
                    unread = Convert.ToInt32(reader[0]);
                }
                conn.Close();
                return unread;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Fetches the recent notifications for a user or admin.
        /// </summary>
        public static DataTable GetNotifications(string userEmail, string role, int limit = 30)
        {
            try
            {
                int safeLimit = Math.Clamp(limit, 1, 200);
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();

                if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.CommandText = "SELECT * FROM tbl_notifications WHERE TargetRole = 'Admin' ORDER BY NotificationId DESC LIMIT @lim";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM tbl_notifications WHERE TargetRole = 'Student' AND ((@email != '' AND UserEmail = @email) OR (UserId = @uid AND @uid > 0)) ORDER BY NotificationId DESC LIMIT @lim";
                    cmd.Parameters.AddWithValue("@email", userEmail ?? string.Empty);
                    cmd.Parameters.AddWithValue("@uid", UserSession.UserId);
                }
                cmd.Parameters.AddWithValue("@lim", safeLimit);

                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "notifications");
                conn.Close();
                return ds.Tables["notifications"]!;
            }
            catch
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// Marks a single notification as read.
        /// </summary>
        public static void MarkAsRead(int notificationId)
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "UPDATE tbl_notifications SET IsRead = 1 WHERE NotificationId = @id";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", notificationId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
        }

        /// <summary>
        /// Marks all notifications for a user or admin as read.
        /// </summary>
        public static void MarkAllAsRead(string userEmail, string role)
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.CommandText = "UPDATE tbl_notifications SET IsRead = 1 WHERE TargetRole = 'Admin'";
                }
                else
                {
                    cmd.CommandText = "UPDATE tbl_notifications SET IsRead = 1 WHERE TargetRole = 'Student' AND ((@email != '' AND UserEmail = @email) OR (UserId = @uid AND @uid > 0))";
                    cmd.Parameters.AddWithValue("@email", userEmail ?? string.Empty);
                    cmd.Parameters.AddWithValue("@uid", UserSession.UserId);
                }
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
        }
    }
}
