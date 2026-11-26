using System;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    public static class DatabaseHelper
    {
        public static string ConnectionString = "server=localhost; database=db_colab; uid=root";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}