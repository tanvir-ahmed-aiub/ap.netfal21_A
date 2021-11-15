using IntroWebAPI.Models;
using IntroWebAPI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroWebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        //By default api maps method with request verbs
        public List<DepartmentModel> Get() {
            List<DepartmentModel> depts = new List<DepartmentModel>();
            for (int i = 0; i < 10; i++) {
                depts.Add(new DepartmentModel() { Id = i + 1, Name = "Department " + i });
            }
            return depts;
            //UMS_AEntities db = new UMS_AEntities();
            //return db.Departments.ToList();
        }
        public DepartmentModel Get(int id) {
            return new DepartmentModel() { Id = id, Name = "dep" + id };
        }
        public string Post(DepartmentModel d) {
            List<DepartmentModel> depts = new List<DepartmentModel>();
            for (int i = 0; i < 10; i++)
            {
                depts.Add(new DepartmentModel() { Id = i + 1, Name = "Department " + i });
            }
            depts.Add(d);
            return "Added";
        }
        public string Put(int id,DepartmentModel d) {
            return "Put";
        }

        public string Delete() {
            return "Delete";
        
        }

        
    }
}
