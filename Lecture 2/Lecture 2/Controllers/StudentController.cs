using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture_2.Models;

namespace Lecture_2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Student s1 = new Student() { 
                Name = "Tanvir Ahmed",
                Id = "1234",
                Dob = "12.12.12"
            };

            /*ViewBag.Name = "Tanvir Ahmed";
            string[] names = new string[3];
            names[0] = "Sabbir";
            names[1] = "Tanvir";
            names[2] = "Ahmed";

            ViewBag.Names = names;*/

            return View(s1);   
        }
        public ActionResult List() {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++) {
                Student s1 = new Student()
                {
                    Name = "Tanvir Ahmed" + (i+1),
                    Id = "1234",
                    Dob = "12.12.12"
                };
                students.Add(s1);
            }
            return View(students);
        }
        public ActionResult Create() {
            
            return View();
        }
        public ActionResult CreateSubmit(Student s) {
            //Student s= new Student();
            //var c = Request;
            //from HttpRequestBase Request
            /*s.Name = Request["Name"];
            s.Id = Request["Id"];
            s.Dob = Request["Dob"];*/
            //form FormCollection Object
            /*s.Name = form["Name"];
            s.Id = form["Id"];
            s.Dob = form["Dob"];*/
            //from direct variables
            /*s.Name = Name;
            s.Id = Id;
            s.Dob = Dob;*/
            return View(s);
        }
    }
}