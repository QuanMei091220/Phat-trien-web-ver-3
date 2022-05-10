using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booksite.Models;

namespace Booksite.Controllers
{
    public class CartController : Controller
    {
        BooksiteEntities ctx = new BooksiteEntities();
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.yourSessionId = HttpContext.Session.SessionID;

            List<ItemCart> cart = null;
            if (HttpContext.Session["yourcart"] == null)
            {
                cart = new List<ItemCart>();

            }
            else
            {
                cart = (List<ItemCart>)HttpContext.Session["yourcart"];
            }


            // cal total of your cart

            float total = 0;

            foreach (ItemCart it in cart)
            {

                total += it.LineTotal;
            }

            ViewBag.Total = total;
            //passing to View
            return View(cart);
        }


        [HttpPost]
        public ActionResult AddToCart()
        {

            //step 1
            List<ItemCart> cart = null;
            if (HttpContext.Session["yourcart"] == null)
            {
                cart = new List<ItemCart>();

            }
            else
            {
                cart = (List<ItemCart>)HttpContext.Session["yourcart"];
            }

            int ID = Convert.ToInt32(Request.Form["ID"]);

            //ItemCart 
            Book book = ctx.Books.Where(t => t.ID == ID).SingleOrDefault();
            int qty = Convert.ToInt32(Request.Form["txtQuantity"]);

            ItemCart item = new ItemCart()
            {

                Book = book,
                Quantity = qty,
                LineTotal = (float)(qty * book.Sale_price)

            };
            //step 2
            cart.Add(item);
            //step 3

            HttpContext.Session["yourcart"] = cart;
            return RedirectToAction("Index");
        }

    }
}