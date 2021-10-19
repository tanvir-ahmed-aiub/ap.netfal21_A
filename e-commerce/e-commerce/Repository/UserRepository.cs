using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Repository
{
    public class UserRepository
    {
        static Entities db;
        static UserRepository() {
            db = new Entities();
        }
        public static Customer Get(string cId) {
            var c = (from cus in db.Customers
                     where cus.Id == cId
                     select cus).FirstOrDefault();
            return c;

        }
        public static Customer Authenticate(string phone, string name)
        {
            var c = (from cus in db.Customers
                     where cus.Id == phone && 
                     cus.Name == name
                     select cus).FirstOrDefault();

            var customer = db.Customers.FirstOrDefault(e => e.Id == phone && e.Name == name);
            return c;
        }

    }
}