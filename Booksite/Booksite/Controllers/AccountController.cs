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
    public class AccountController : Controller
    {
        BooksiteEntities ctx = new BooksiteEntities();

        public ActionResult Index()
        {
                return View();

        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            var usr = username;
            var psw = password;
            var acc = ctx.Accounts.SingleOrDefault(x => x.Username == usr && x.Password == psw);
            if(acc != null)
            {
                return RedirectToAction("Index", "Home", new { permalink = "Joes-Page" });

            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


        // GET: Account


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account ac)
        {
            if (ModelState.IsValid)
            {
                var check = ctx.Accounts.FirstOrDefault(s => s.Username == ac.Username);
                if (check == null)
                {
                    ac.Password = ac.Password;
                    ctx.Configuration.ValidateOnSaveEnabled = false;
                    ctx.Accounts.Add(ac);
                    ctx.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }


}