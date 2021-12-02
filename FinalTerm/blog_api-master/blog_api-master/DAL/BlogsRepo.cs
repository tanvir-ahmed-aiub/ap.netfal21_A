using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BlogsRepo : IRepository<Blog, int>
    {
        BlogsEntities db;
        public BlogsRepo(BlogsEntities db) {
            this.db = db;
        }
        public void Add(Blog e)
        {
            db.Blogs.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Blogs.Remove(db.Blogs.FirstOrDefault(e => e.Id == id));
            db.SaveChanges();
        }

        public void Edit(Blog e)
        {
            var u = db.Blogs.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(u).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Blog> Get()
        {
            return db.Blogs.ToList();
        }

        public Blog Get(int id)
        {
            return db.Blogs.FirstOrDefault(e => e.Id == id);
        }
    }
}
