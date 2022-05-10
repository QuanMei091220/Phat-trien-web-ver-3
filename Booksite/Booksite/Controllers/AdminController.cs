using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booksite.Models;

namespace Booksite.Controllers
{

    public class AdminController : Controller
    {
        BooksiteEntities ctx = new BooksiteEntities();
        // GET: Admin
        public ActionResult Index()
        {
            List<Book> books = ctx.Books.ToList();
            return View(books);
        }
        public ActionResult Author()
        {
            List<Author> authors = ctx.Authors.ToList();
            return View(authors);
        }

        public ActionResult Supplier()
        {
            List<Supplier> suppliers = ctx.Suppliers.ToList();
            return View(suppliers);
        }

        public ActionResult Publisher()
        {
            List<Publisher> publishers = ctx.Publishers.ToList();
            return View(publishers);
        }

        public ActionResult Category()
        {
            List<Category> categories = ctx.Categories.ToList();
            return View(categories);
        }
        public ActionResult ProductsDetail(int id)
        {

            //select *from Toys where
            Book book = ctx.Books.Where(t => t.ID == id).SingleOrDefault();

            ViewBag.Bookid = id;
            //passing data
            return View(book);
        }

        public ActionResult DeleteProduct(int id)
        {
            Book book = ctx.Books.Where(t => t.ID == id).SingleOrDefault();
            //xoa
            ctx.Books.Remove(book);
            ctx.SaveChanges();

            //redirect view
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddProduct(Book book)
        {
            if (ModelState.IsValid)
            {

                //custom  --> check cToyId unique

                Book book_db = ctx.Books.Where(t => t.ID == book.ID).SingleOrDefault();
                if (book_db != null)
                {

                    ModelState.AddModelError(string.Empty, "ID");
                    List<Category> categories = ctx.Categories.ToList();
                    ViewBag.categories = categories;

                    List<Publisher> publishers = ctx.Publishers.ToList();
                    ViewBag.publishers = publishers;

                    List<Author> authors = ctx.Authors.ToList();
                    ViewBag.authors = authors;

                    List<Supplier> suppliers = ctx.Suppliers.ToList();
                    ViewBag.suppliers = suppliers;

                    return View(book);
                }
                else
                {
                    //save to db
                    ctx.Books.Add(book);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            else
            {
                List<Category> categories = ctx.Categories.ToList();
                ViewBag.categories = categories;

                List<Publisher> publishers = ctx.Publishers.ToList();
                ViewBag.publishers = publishers;

                List<Author> authors = ctx.Authors.ToList();
                ViewBag.authors = authors;

                List<Supplier> suppliers = ctx.Suppliers.ToList();
                ViewBag.suppliers = suppliers;

                return View(book);
            }
        }
        public ActionResult AddProduct()
        {
            Book book = new Book();
            // list category
            List<Category> categories = ctx.Categories.ToList();
            ViewBag.categories = categories;

            List<Publisher> publishers = ctx.Publishers.ToList();
            ViewBag.publishers = publishers;

            List<Author> authors = ctx.Authors.ToList();
            ViewBag.authors = authors;

            List<Supplier> suppliers = ctx.Suppliers.ToList();
            ViewBag.suppliers = suppliers;

            return View(book);
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {

            // list category
            List<Category> categories = ctx.Categories.ToList();
            ViewBag.categories = categories;

            List<Publisher> publishers = ctx.Publishers.ToList();
            ViewBag.publishers = publishers;

            List<Author> authors = ctx.Authors.ToList();
            ViewBag.authors = authors;

            List<Supplier> suppliers = ctx.Suppliers.ToList();
            ViewBag.suppliers = suppliers;
            Book book = ctx.Books.Where(t => t.ID == id).SingleOrDefault();

            ViewBag.Bookid = id;
            //passing data
            return View(book);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Book book)
        {
            //search old entity
            Book oldbook = ctx.Books.Where(t => t.ID == book.ID).SingleOrDefault();
            // update
            oldbook.Book_name = book.Book_name;
            oldbook.Description = book.Description;
            oldbook.Category_name = book.Category_name;
            oldbook.Publisher_name = book.Publisher_name;
            oldbook.Author_name = book.Author_name;
            oldbook.Supplier_name = book.Supplier_name;
            oldbook.Original_Price = book.Original_Price;
            oldbook.Discount = book.Discount;
            oldbook.Sale_price = book.Sale_price;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {

                //custom  --> check cToyId unique

                Author author_db = ctx.Authors.Where(t => t.ID == author.ID).SingleOrDefault();
                if (author_db != null)
                {

                    ModelState.AddModelError(string.Empty, "ID");
                    return View(author);
                }
                else
                {
                    //save to db
                    ctx.Authors.Add(author);
                    ctx.SaveChanges();
                    return RedirectToAction("Author");

                }
            }
            else
            {
                return View(author);
            }
        }
        public ActionResult AddAuthor()
        {
            Author author = new Author();
            return View(author);
        }
        public ActionResult DeleteAuthor(int id)
        {
            Author author = ctx.Authors.Where(t => t.ID == id).SingleOrDefault();
            //xoa
            ctx.Authors.Remove(author);
            ctx.SaveChanges();

            //redirect view
            return RedirectToAction("Author");
        }

        [HttpGet]
        public ActionResult EditAuthor(int id)
        {

            Author author = ctx.Authors.Where(t => t.ID == id).SingleOrDefault();

            ViewBag.authorid = id;
            //passing data
            return View(author);
        }

        [HttpPost]
        public ActionResult UpdateAuthor(Author author)
        {
            //search old entity
            Author oldauthor = ctx.Authors.Where(t => t.ID == author.ID).SingleOrDefault();
            // update
            oldauthor.Author_name = author.Author_name;
            ctx.SaveChanges();

            return RedirectToAction("Author");
        }

        public ActionResult AuthorDetail(int id)
        {

            //select *from Toys where
            Author author = ctx.Authors.Where(t => t.ID == id).SingleOrDefault();

            ViewBag.authorid = id;
            //passing data
            return View(author);
        }

        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {

                //custom  --> check cToyId unique

                Supplier supplier_db = ctx.Suppliers.Where(t => t.ID == supplier.ID).SingleOrDefault();
                if (supplier_db != null)
                {

                    ModelState.AddModelError(string.Empty, "ID");
                    return View(supplier);
                }
                else
                {
                    //save to db
                    ctx.Suppliers.Add(supplier);
                    ctx.SaveChanges();
                    return RedirectToAction("Supplier");

                }
            }
            else
            {
                return View(supplier);
            }
        }
        public ActionResult AddSupplier()
        {
            Supplier supplier = new Supplier();
            return View(supplier);
        }

        public ActionResult DeleteSupplier(int id)
        {
            Supplier supplier = ctx.Suppliers.Where(t => t.ID == id).SingleOrDefault();
            //xoa
            ctx.Suppliers.Remove(supplier);
            ctx.SaveChanges();

            //redirect view
            return RedirectToAction("Supplier");
        }

        public ActionResult EditSupplier(int id)
        {

            Supplier supplier = ctx.Suppliers.Where(t => t.ID == id).SingleOrDefault();

            ViewBag.Supid = id;
            //passing data
            return View(supplier);
        }

        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {
            //search old entity
            Supplier oldsup = ctx.Suppliers.Where(t => t.ID == supplier.ID).SingleOrDefault();
            // update
            oldsup.Sup_name = supplier.Sup_name;
            ctx.SaveChanges();

            return RedirectToAction("Supplier");
        }

        [HttpPost]
        public ActionResult AddPublisher(Publisher publisher)
        {
            if (ModelState.IsValid)
            {

                //custom  --> check cToyId unique

                Publisher publisher_db = ctx.Publishers.Where(t => t.ID == publisher.ID).SingleOrDefault();
                if (publisher_db != null)
                {

                    ModelState.AddModelError(string.Empty, "ID");
                    return View(publisher);
                }
                else
                {
                    //save to db
                    ctx.Publishers.Add(publisher);
                    ctx.SaveChanges();
                    return RedirectToAction("Publisher");

                }
            }
            else
            {
                return View(publisher);
            }
        }
        public ActionResult AddPublisher()
        {
            Publisher publisher = new Publisher();
            return View(publisher);
        }
        public ActionResult DeletePublisher(int id)
        {
            Publisher publisher = ctx.Publishers.Where(t => t.ID == id).SingleOrDefault();
            //xoa
            ctx.Publishers.Remove(publisher);
            ctx.SaveChanges();

            //redirect view
            return RedirectToAction("Publisher");
        }

        public ActionResult EditPublisher(int id)
        {

            Publisher publisher = ctx.Publishers.Where(t => t.ID == id).SingleOrDefault();

            ViewBag.Pubid = id;
            //passing data
            return View(publisher);
        }

        [HttpPost]
        public ActionResult UpdatePublisher(Publisher publisher)
        {
            //search old entity
            Publisher oldpub = ctx.Publishers.Where(t => t.ID == publisher.ID).SingleOrDefault();
            // update
            oldpub.Pub_name = publisher.Pub_name;
            ctx.SaveChanges();

            return RedirectToAction("Publisher");
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {

                //custom  --> check cToyId unique

                Category category_db = ctx.Categories.Where(t => t.ID == category.ID).SingleOrDefault();
                if (category_db != null)
                {

                    ModelState.AddModelError(string.Empty, "ID");
                    return View(category);
                }
                else
                {
                    //save to db
                    ctx.Categories.Add(category);
                    ctx.SaveChanges();
                    return RedirectToAction("Publisher");

                }
            }
            else
            {
                return View(category);
            }
        }
        public ActionResult AddCategory()
        {
            Category category= new Category();
            return View(category);
        }
        public ActionResult DeleteCategory(int id)
        {
            Category category = ctx.Categories.Where(t => t.ID == id).SingleOrDefault();
            //xoa
            ctx.Categories.Remove(category);
            ctx.SaveChanges();

            //redirect view
            return RedirectToAction("Publisher");
        }

        public ActionResult EditCategory(int id)
        {

            Category category = ctx.Categories.Where(t => t.ID == id).SingleOrDefault();

            ViewBag.cateid = id;
            //passing data
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            //search old entity
            Category oldcate = ctx.Categories.Where(t => t.ID == category.ID).SingleOrDefault();
            // update
            oldcate.Cate_name = category.Cate_name;
            oldcate.Supper_Id = category.Supper_Id;
            ctx.SaveChanges();

            return RedirectToAction("Publisher");
        }

    }
}