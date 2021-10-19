using e_commerce.BModels;
using e_commerce.Models;
using e_commerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace e_commerce.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = ProductRepository.GetAll();
            return View(products);
        }
        public ActionResult AddToCart(int id) {
            var p = ProductRepository.Get(id);
            var pm = new ProductModel()
            {
                Id = p.Id,
                Price = p.Price
            };
            List<ProductModel> products;
            if (Session["cart"] == null)
            {
                products = new List<ProductModel>();
            }
            else {
                var json = Session["cart"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
            }
            
            products.Add(pm);
            var json2 = new JavaScriptSerializer().Serialize(products);
            Session["cart"] = json2;
            return RedirectToAction("Index");
        }
        public ActionResult Cart() {
            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
            return View(products);
        }
        public ActionResult Checkout() {
            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
            OrderRepository.PlaceOrder(products,User.Identity.Name);
            return RedirectToAction("Index");
            //return null;
        }
    }
}