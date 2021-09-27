using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Entity
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Provide name")]
        [MinLength(2,ErrorMessage ="Name must be > 2 character")]
        [MaxLength(10,ErrorMessage ="Name should not exceed 10 character")]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
        public string Gender { get; set; }
        public float Cgpa { get; set; }
    }
}