using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentRepo : IRepository<Student, int>
    {
        UMS_AEntities db;
        public StudentRepo(UMS_AEntities db) {
            this.db = db;
        }
        public void Add(Student e)
        {
            db.Students.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = db.Students.FirstOrDefault(e => e.Id == id);
            db.Students.Remove(s);
            db.SaveChanges();
        }

        public void Edit(Student e)
        {
            var s = db.Students.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(s).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public Student Get(int id)
        {
            return db.Students.FirstOrDefault(e => e.Id == id);
        }
    }
}
