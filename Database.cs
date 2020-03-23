﻿using System;
using System.Collections.Generic;
using System.Data;
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
                    command.CommandText =
                        "UPDATE students SET eduplan = @eduplan, college = @college, major = @major, careerpath = @careerpath, ethnicity = @ethnicity, gender = @gender, ncaa = @ncaa, firstgen = @firstgen, onlineinterest = @onlineinterest WHERE studentnumber = @studentnumber;";
                    command.Parameters.Add("@eduplan", MySqlDbType.VarChar);
                    command.Parameters["@eduplan"].Value = eduplan;
                    command.Parameters.Add("@college", MySqlDbType.VarChar);
                    command.Parameters["@college"].Value = college;
                    command.Parameters.Add("@major", MySqlDbType.VarChar);
                    command.Parameters["@major"].Value = major;
                    command.Parameters.Add("@careerpath", MySqlDbType.VarChar);
                    command.Parameters["@careerpath"].Value = careerpath;
                    command.Parameters.Add("@ethnicity", MySqlDbType.VarChar);
                    command.Parameters["@ethnicity"].Value = ethnicity;
                    command.Parameters.Add("@gender", MySqlDbType.VarChar);
                    command.Parameters["@gender"].Value = gender;
                    command.Parameters.Add("@ncaa", MySqlDbType.VarChar);
                    command.Parameters["@ncaa"].Value = ncaa;
                    command.Parameters.Add("@firstgen", MySqlDbType.VarChar);
                    command.Parameters["@firstgen"].Value = firstgen;
                    command.Parameters.Add("@onlineinterest", MySqlDbType.VarChar);
                    command.Parameters["@onlineinterest"].Value = onlineinterest;
                    command.Parameters.Add("@studentnumber", MySqlDbType.VarChar);
                    command.Parameters["@studentnumber"].Value = _primarykey;
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
                    }
                }
            }

            return new[]
            {
                name, _primarykey, gpa, eduplan, college, major, careerpath, ethnicity, gender, ncaa, firstgen,
                onlineinterest
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
                    command.CommandText = "SELECT * FROM students;";
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine(reader.HasRows);
                        while (reader.Read())
                        {
                            string firstname = reader.GetString("firstname");
                            string lastname = reader.GetString("lastname");
                            string studentnumber = reader.GetString("studentnumber");
                            string gpa = reader.GetString("gpa");
                            string eduplan = reader.GetString("eduplan");
                            string college = reader.GetString("college");
                            string major = reader.GetString("major");
                            string careerpath = reader.GetString("careerpath");
                            string ncaa = reader.GetString("ncaa");
                            string firstgen = reader.GetString("firstgen");
                            string onlineinterest = reader.GetString("onlineinterest");
                            string ethnicity = reader.GetString("ethnicity");
                            students.Add(new[]
                            {
                                firstname, lastname, studentnumber, gpa, eduplan, college, major, careerpath, ncaa,
                                firstgen, onlineinterest, ethnicity
                            });
                        }
                    }
                }
            }
            return students;
        }
    }
}