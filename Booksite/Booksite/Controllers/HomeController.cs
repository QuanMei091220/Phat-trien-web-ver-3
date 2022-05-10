using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booksite.Models;
using System.Security.Cryptography;
using System.Text;

namespace Booksite.Controllers
{
    public class HomeController : Controller
    {
        BooksiteEntities ctx = new BooksiteEntities();
        public ActionResult Index()
        {

                List<Book> books = ctx.Books.ToList();

                List<Book> top3books = ctx.Books.OrderBy(x => x.Original_Price).Take(3).ToList();
                ViewBag.top3books = top3books;
                return View(books);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
 

        public ActionResult DetailProduct(int id)
        {
            Book book = ctx.Books.Where(x => x.ID == id).SingleOrDefault();
            ViewBag.productId = id;
            //passing data /model to view 
            return View(book);
        }


    }
}