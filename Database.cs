using System.Data;
using System.Data.SqlClient;

namespace Stride
{
    public class Database
    {
        private static bool _auth;
        private static string _primarykey; //primary key is student number
        private static SqlConnectionStringBuilder Builder()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "danstride.database.windows.net",
                InitialCatalog = "Stride",
                UserID = "dan",
                Password = "Stridepassword!"
            };
            return builder;
        }
        public static bool Auth(string user, string pass)
        {
            using (var conn = new SqlConnection(Builder().ConnectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM users WHERE username = @username and password = @password;";
                    command.Parameters.Add("@username", SqlDbType.VarChar);
                    command.Parameters["@username"].Value = user;
                    command.Parameters.Add("@password", SqlDbType.VarChar);
                    command.Parameters["@password"].Value = pass;
                    using (var reader = command.ExecuteReader())
                    {
                        _auth = reader.HasRows;
                        if (_auth)
                        {
                            _primarykey = user;
                        }
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
            using (var conn = new SqlConnection(Builder().ConnectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "UPDATE students SET eduplan = @eduplan, college = @college, careerpath = @careerpath, ethnicity = @ethnicity, gender = @gender WHERE studentnumber = @studentnumber;";
                    command.Parameters.Add("@eduplan", SqlDbType.VarChar);
                    command.Parameters["@eduplan"].Value = eduplan;
                    command.Parameters.Add("@college", SqlDbType.VarChar);
                    command.Parameters["@college"].Value = college;
                    command.Parameters.Add("@careerpath", SqlDbType.VarChar);
                    command.Parameters["@careerpath"].Value = careerpath;
                    command.Parameters.Add("@ethnicity", SqlDbType.VarChar);
                    command.Parameters["@ethnicity"].Value = ethnicity;
                    command.Parameters.Add("@gender", SqlDbType.VarChar);
                    command.Parameters["@gender"].Value = gender;
                    command.Parameters.Add("@studentnumber", SqlDbType.VarChar);
                    command.Parameters["@studentnumber"].Value = _primarykey;
                    command.ExecuteNonQuery();
                }
            }
        }
        public static string[] LoadSaveData()
        {
            string eduplan;
            string college;
            string careerpath;
            string ethnicity;
            string gender;
            using (var conn = new SqlConnection(Builder().ConnectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM students WHERE studentnumber = @studentnumber;";
                    command.Parameters.Add("@studentnumber", SqlDbType.VarChar);
                    command.Parameters["@studentnumber"].Value = _primarykey;
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        eduplan = reader.GetString("eduplan");
                        college = reader.GetString("college");
                        careerpath = reader.GetString("careerpath");
                        ethnicity = reader.GetString("ethnicity");
                        gender = reader.GetString("gender");
                    }
                }
            }
            return new []{eduplan, college, careerpath, ethnicity, gender};
        }
    }
}