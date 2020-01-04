using System.Data;
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
                    command.CommandText = "SELECT * FROM users WHERE username = @username and password = @password;";
                    command.Parameters.Add("@username", MySqlDbType.VarChar);
                    command.Parameters["@username"].Value = user;
                    command.Parameters.Add("@password", MySqlDbType.VarChar);
                    command.Parameters["@password"].Value = pass;
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
        public static void SaveData(string eduplan, string college, string careerpath, string ethnicity, string gender)
        {
            using (var conn = new MySqlConnection(Builder().ConnectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "UPDATE students SET eduplan = '" + eduplan + "', college = '" + college +
                                          "', careerpath = '" + careerpath + "', ethnicity = '" + ethnicity +
                                          "', gender = '" + gender + "' WHERE studentnumber = '1234567'";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}