using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booksite.Models;
namespace Booksite.Controllers
{
    public class CheckoutController : Controller
    {
        BooksiteEntities ctx = new BooksiteEntities();
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Check_out check_Out)
        {
            if (ModelState.IsValid)
            {

                //custom  --> check cToyId unique

                Check_out checkout_db = ctx.Check_out.Where(t => t.ID == check_Out.ID).SingleOrDefault();
                if (checkout_db != null)
                {

                    ModelState.AddModelError(string.Empty, "ID");


                    return View(check_Out);
                }
                else
                {
                    //save to db
                    ctx.Check_out.Add(check_Out);
                    ctx.SaveChanges();
                    return RedirectToAction("Index", "Home", new { permalink = "Joes-Page" });

                }
            }
            else
            {
              
                return View(check_Out);
            }
        }
        public ActionResult Checkout()
        {
            Check_out check_Out = new Check_out();
            return View(check_Out);
        }
    }
}