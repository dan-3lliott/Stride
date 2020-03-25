using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Stride
{
    public class Database
    {
        private static bool _auth;
        private static string _primarykey; //primary key is student number

        private static MySqlConnectionStringBuilder Builder()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "stride",
                UserID = "root",
                Password = ""
            };
            return builder;
        }

        public static string Auth(string user, string pass)
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
                        if (_auth)
                        {
                            _primarykey = user;
                            reader.Read();
                            return reader.GetString("usertype");
                        }

                        return null; //no auth
                    }
                }
            }
        }

        public static bool IsAuth()
        {
            return _auth;
        }

        public static void SaveStudentData(string eduplan, string college, string major, string careerpath,
            string ethnicity, string gender, string ncaa, string firstgen, string onlineinterest)
        {
            using (var conn = new MySqlConnection(Builder().ConnectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "UPDATE students SET";
                    
                    if (eduplan != null)
                    {
                        command.CommandText += ", eduplan = @eduplan";
                        command.Parameters.Add("@eduplan", MySqlDbType.VarChar);
                        command.Parameters["@eduplan"].Value = eduplan;
                    }

                    if (college != null)
                    {
                        command.CommandText += ", college = @college";
                        command.Parameters.Add("@college", MySqlDbType.VarChar);
                        command.Parameters["@college"].Value = college;
                    }

                    if (major != null)
                    {
                        command.CommandText += ", major = @major";
                        command.Parameters.Add("@major", MySqlDbType.VarChar);
                        command.Parameters["@major"].Value = major;
                    }

                    if (careerpath != null)
                    {
                        command.CommandText += ", careerpath = @careerpath";
                        command.Parameters.Add("@careerpath", MySqlDbType.VarChar);
                        command.Parameters["@careerpath"].Value = careerpath;
                    }

                    if (ethnicity != null)
                    {
                        command.CommandText += ", ethnicity = @ethnicity";
                        command.Parameters.Add("@ethnicity", MySqlDbType.VarChar);
                        command.Parameters["@ethnicity"].Value = ethnicity;
                    }

                    if (gender != null)
                    {
                        command.CommandText += ", gender = @gender";
                        command.Parameters.Add("@gender", MySqlDbType.VarChar);
                        command.Parameters["@gender"].Value = gender;
                    }

                    if (ncaa != null)
                    {
                        command.CommandText += ", ncaa = @ncaa";
                        command.Parameters.Add("@ncaa", MySqlDbType.VarChar);
                        command.Parameters["@ncaa"].Value = ncaa;
                    }

                    if (firstgen != null)
                    {
                        command.CommandText += ", firstgen = @firstgen";
                        command.Parameters.Add("@firstgen", MySqlDbType.VarChar);
                        command.Parameters["@firstgen"].Value = firstgen;
                    }

                    if (onlineinterest != null)
                    {
                        command.CommandText += ", onlineinterest = @onlineinterest";
                        command.Parameters.Add("@onlineinterest", MySqlDbType.VarChar);
                        command.Parameters["@onlineinterest"].Value = onlineinterest;
                    }

                    command.CommandText += " WHERE studentnumber = @studentnumber;";
                    command.Parameters.Add("@studentnumber", MySqlDbType.VarChar);
                    command.Parameters["@studentnumber"].Value = _primarykey;
                    command.CommandText = command.CommandText.Remove(19, 1);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static string[] LoadSaveData()
        {
            string name;
            string gpa;
            string eduplan;
            string college;
            string major;
            string careerpath;
            string ethnicity;
            string gender;
            string ncaa;
            string firstgen;
            string onlineinterest;
            string counselor;
            using (var conn = new MySqlConnection(Builder().ConnectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM students WHERE studentnumber = @studentnumber;";
                    command.Parameters.Add("@studentnumber", MySqlDbType.VarChar);
                    command.Parameters["@studentnumber"].Value = _primarykey;
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        name = reader.GetString("firstname") + " " + reader.GetString("lastname");
                        gpa = reader.GetString("gpa");
                        eduplan = reader.GetString("eduplan");
                        college = reader.GetString("college");
                        major = reader.GetString("major");
                        careerpath = reader.GetString("careerpath");
                        ethnicity = reader.GetString("ethnicity");
                        gender = reader.GetString("gender");
                        ncaa = reader.GetString("ncaa");
                        firstgen = reader.GetString("firstgen");
                        onlineinterest = reader.GetString("onlineinterest");
                        counselor = reader.GetString("counselor");
                    }
                }
            }

            return new[]
            {
                name, _primarykey, gpa, eduplan, college, major, careerpath, ethnicity, gender, ncaa, firstgen,
                onlineinterest, counselor
            };
        }

        public static IEnumerable<string[]> LoadStudents()
        {
            IList<string[]> students = new List<string[]>();
            using (var conn = new MySqlConnection(Builder().ConnectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM users JOIN students ON users.username = students.studentnumber;";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var firstname = reader.GetString("firstname");
                            var lastname = reader.GetString("lastname");
                            var studentnumber = reader.GetString("studentnumber");
                            var gpa = reader.GetString("gpa");
                            var eduplan = reader.GetString("eduplan");
                            var college = reader.GetString("college");
                            var major = reader.GetString("major");
                            var careerpath = reader.GetString("careerpath");
                            var ncaa = reader.GetString("ncaa");
                            var firstgen = reader.GetString("firstgen");
                            var onlineinterest = reader.GetString("onlineinterest");
                            var ethnicity = reader.GetString("ethnicity");
                            var email = reader.GetString("email");
                            students.Add(new[]
                            {
                                firstname, lastname, studentnumber, gpa, eduplan, college, major, careerpath, ncaa,
                                firstgen, onlineinterest, ethnicity, email
                            });
                        }
                    }
                }
            }
            return students;
        }

        public static string[] LoadCounselorInfo(string counselor)
        {
            string firstname;
            string lastname;
            string phonenumber;
            string email;
            using (var conn = new MySqlConnection(Builder().ConnectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM counselors WHERE username = @counselor;";
                    command.Parameters.Add("@counselor", MySqlDbType.VarChar);
                    command.Parameters["@counselor"].Value = counselor;
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        firstname = reader.GetString("firstname");
                        lastname = reader.GetString("lastname");
                        phonenumber = reader.GetString("phonenumber");
                    }
                }
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM users WHERE username = @counselor;";
                    command.Parameters.Add("@counselor", MySqlDbType.VarChar);
                    command.Parameters["@counselor"].Value = counselor;
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        email = reader.GetString("email");
                    }
                }
            }

            return new[]
            {
                firstname, lastname, phonenumber, email
            };
        }
    }
}