using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepo : IRepository<User, int>,IAuth
    {
        BlogsEntities db;
        public UserRepo(BlogsEntities db) {
            this.db = db;
        }
        public void Add(User e)
        {
            db.Users.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Users.Remove(db.Users.FirstOrDefault(e => e.Id == id));
            db.SaveChanges();
        }

        public void Edit(User e)
        {
            var u = db.Users.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(u).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(e => e.Id == id);
        }
        public Token Authenticate(User user)
        {
            var u = db.Users.FirstOrDefault(en => en.Username.Equals(user.Username) && en.Password.Equals(user.Password));
            Token t = null;
            if(u != null) //authenticated
            {
                string token = Guid.NewGuid().ToString();
                t = new Token();
                t.UserId = u.Id;
                t.AccessToken = token;
                t.CreatedAt = DateTime.Now;
                db.Tokens.Add(t);
                db.SaveChanges();

            }
            return t;
        }
        public bool IsAuthenticated(string token)
        {
            var rs = db.Tokens.Any(e => e.AccessToken.Equals(token) && e.ExpiredAt == null);
            return rs;
        }
        public bool Logout(string token)
        {
            var t = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token));
            if(t != null)
            {
                t.ExpiredAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
