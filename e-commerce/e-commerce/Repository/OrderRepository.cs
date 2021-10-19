using e_commerce.BModels;
using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Repository
{
    public class OrderRepository
    {
        static Entities db;
        static OrderRepository() {
            db = new Entities();
        }
        public static void PlaceOrder(List<ProductModel> products, string uId) {

            Order o = new Order();
            o.Amount = 100000;
            o.CustomerId = uId;
            o.Status = "Ordered";
            db.Orders.Add(o);
            db.SaveChanges();
            foreach (var p in products) {
                var od = new Orderdetail() { 
                    OrderId = o.Id,
                    ProductId = p.Id,
                    Unitprice = p.Price,
                    Qty = 1 
                };
                db.Orderdetails.Add(od);
                db.SaveChanges();

            }

        }
    }
}