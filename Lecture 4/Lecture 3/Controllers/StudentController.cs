using Lecture_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Lecture_3.Models;
using Lecture_3.Auth;

namespace Lecture_3.Controllers
{
    [AdminAccess (Roles ="manager")]
    public class StudentController : Controller
    {
        // GET: Student
        [AllowAnonymous]
        public ActionResult Index()
        {
            Database db = new Database();
            var students = db.Students.GetAll();
            return View(students);
        }
        
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) {
            if (ModelState.IsValid) {
                Database db = new Database();
                db.Students.Add(s);
                return RedirectToAction("Index");
            }
            return View();
            
        }

    }
}