using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    public static class DatabaseHelper
    {
        // =========================================================================
        // XAMPP / PHPMYADMIN CONFIGURATION
        // Modify these values if your database name or credentials differ
        // =========================================================================
        public static string Server = "localhost";
        public static string Database = "db_colab"; // Set your database name here
        public static string Uid = "root";
        public static string Password = "";

        public static string ConnectionString => $"server={Server};database={Database};uid={Uid};pwd={Password};Charset=utf8mb4;";

        /// <summary>
        /// Creates and returns a new MySqlConnection object using the configured connection string.
        /// </summary>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        /// <summary>
        /// Executes a SELECT query and returns the results as a DataTable.
        /// </summary>
        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using MySqlConnection conn = GetConnection();
            using MySqlCommand cmd = new MySqlCommand(query, conn);
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            using MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Executes an INSERT, UPDATE, or DELETE query and returns the number of rows affected.
        /// </summary>
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using MySqlConnection conn = GetConnection();
            using MySqlCommand cmd = new MySqlCommand(query, conn);
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;
        }

        /// <summary>
        /// Executes a query that returns a single scalar value.
        /// </summary>
        public static object? ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using MySqlConnection conn = GetConnection();
            using MySqlCommand cmd = new MySqlCommand(query, conn);
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            conn.Open();
            object? result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        }
    }
}

