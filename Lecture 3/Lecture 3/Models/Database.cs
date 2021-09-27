using Lecture_3.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Lecture_3.Models
{
    public class Database
    {
        public Students Students { get; set; }
        public Courses Courses { get; set; }
        public Faculties Faculties { get; set; }
        public Database() {
            string connString = @"Server=DESKTOP-NM0ID5F\SQLEXPRESS;Database=UMS_A;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            Students = new Students(conn);
            Courses = new Courses();
            Faculties = new Faculties();
        }
    }
}