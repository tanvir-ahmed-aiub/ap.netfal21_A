using BLL;
using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TierApp.Controllers
{
    [EnableCors("*","*","*")]
    public class StudentController : ApiController
    {
        [Route("api/Student/Names")]
        [HttpGet]
        public List<string> GetNames() {
            return StudentService.GetNames();
        }
        [Route("api/Student/All")]
        [HttpGet]
        public List<StudentModel> GetAll() {
            return StudentService.Get();
        }
        [Route("api/Student/Create")]
        [HttpPost]
        public void Add(StudentModel s)
        {
            StudentService.Add(s);
        }

    }
}
