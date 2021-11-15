using IntroWebAPI.Models;
using IntroWebAPI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Web.Http.Cors;

namespace IntroWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class StudentController : ApiController
    {
        
        [Route("api/student/names")]
        [HttpGet]
        public List<string> StNames() {
            var data = (from st in new UMS_AEntities().Students
                        select st.Name).ToList();
            return data;
        }
        [Route("api/student/create")]
        [HttpPost]
        public void Post(Student s) {
            var db = new UMS_AEntities();
            db.Students.Add(s);
            db.SaveChanges();
        
        }
        public List<StudentModel> Get() {
            UMS_AEntities db = new UMS_AEntities();
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Student, StudentModel>();
                    cfg.CreateMap<Department, DepartmentModel>();
                }
            );
            var mapper = new Mapper(config);
            var data = mapper.Map<List<StudentModel>>(db.Students.ToList());

           /* var data = new List<StudentModel>();
            foreach (var e in db.Students) {
                var st = new StudentModel() { 
                    Id = e.Id,
                    Name = e.Name,
                    Cgpa = e.Cgpa,
                    Gender = e.Gender,
                    Dob = e.Dob,
                    DepartmentId = e.DepartmentId,
                };
                data.Add(st);
            }*/
            return data;
        }
        public StudentModel Get(int id) {
            
            UMS_AEntities db = new UMS_AEntities();
            var e= db.Students.FirstOrDefault(d => d.Id == id);
            var st = new StudentModel()
            {
                Id = e.Id,
                Name = e.Name,
                Cgpa = e.Cgpa,
                Gender = e.Gender,
                Dob = e.Dob,
                DepartmentId = e.DepartmentId,
            };
            return st;
        }
    }
}
