using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmentRepo : IRepository<Department, int>
    {
        UMS_AEntities db;
        public DepartmentRepo(UMS_AEntities db) {
            this.db = db;
        }
        public void Add(Department e)
        {
            db.Departments.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Departments.FirstOrDefault(en => en.Id == id);
            db.Departments.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Department e)
        {
            var d = db.Departments.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Department> Get()
        {
            return db.Departments.ToList();
        }

        public Department Get(int id)
        {
            return db.Departments.FirstOrDefault(e => e.Id == id);
        }
    }
}
