using Lecture_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Lecture_3.Models.Tables
{
    public class Users
    {
        SqlConnection conn;
        public Users(SqlConnection conn)
        {
            this.conn = conn;
        }
        public User Authenticate(string username, string password) {
            User user = null;
            conn.Open();
            /*var md5 = new MD5CryptoServiceProvider();
            password = md5.ComputeHash(password);*/
            string query = String.Format("select * from Users where Username='{0}' and Password='{1}'",username,password);

            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                user = new User() { 
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Username = reader.GetString(reader.GetOrdinal("Username"))
                };
            }
            conn.Close();
            return user;
        }
        public int GetUserType(string username) {
            int type = 0;
            conn.Open();
            /*var md5 = new MD5CryptoServiceProvider();
            password = md5.ComputeHash(password);*/
            string query = String.Format("select Type from Users where Username='{0}'", username);

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                type = reader.GetInt32(reader.GetOrdinal("Type"));
               
               
            }
            conn.Close();
            return type;
        }
    }
}