using MySql.Data.MySqlClient;

namespace Stride
{
    public class Database
    {
        private static bool _auth;
        public static MySqlConnectionStringBuilder Builder()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "Stride",
                UserID = "root",
                Password = ""
            };
            return builder;
        }
        public static bool Auth(string user, string pass)
        {
            using (var conn = new MySqlConnection(Builder().ConnectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM users WHERE username = '" + user + "' and password = '" + pass + "'";
                    using (var reader = command.ExecuteReader())
                    {
                        _auth = reader.HasRows;
                        return _auth;
                    }
                }
            }
        }

        public static bool IsAuth()
        {
            return _auth;
        }
    }
}