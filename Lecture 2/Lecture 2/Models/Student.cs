using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecture_2.Models
{
    public class Student
    {
        
        public string Name { get; set; }
        public string Id { get; set; }
        public string Dob { get; set; }
        public float Cgpa { get; set; }

       
    }
}