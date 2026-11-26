using System;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    public static class DatabaseHelper
    {
        public static string ConnectionString = "server=192.168.5.144; database=db_colab; uid=ddbms_user; pwd=password123";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}