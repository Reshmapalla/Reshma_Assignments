using EF_Assignment_BookApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EF_Assignment_BookApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookAppContext bookAppContext;
        public BookController()
        {
           
            bookAppContext = new BookAppContext();
        }
        [HttpGet]
        public IActionResult GetAllbooks()
        {
            var books = bookAppContext.Books;
            return View(books);
        }
       [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]       
        public IActionResult Create(Book book)

        {
            if (ModelState.IsValid)
            {
                bookAppContext.Books.Add(book);
                bookAppContext.SaveChanges();
                return RedirectToAction("GetAllbooks");

            }
            else
                return View();

            
            
        }
        [HttpGet]
        public IActionResult GetBookByAuthor(string name)
        {
            var book=bookAppContext.Books.Where(n=>n.Author==name).ToList();
            return View(book);
        }
        [HttpGet]
        public IActionResult GetBookByLang(string lang)
        {
            var book= bookAppContext.Books.SingleOrDefault(n=>n.Language==lang);
            return View(book);
        }

        [HttpGet]
        public IActionResult GetBookByYear(int year)
        {
            var book= bookAppContext.Books.Where(b => b.Releasedate.Value.Year == year).ToList();
            return View(book);
        }

        [HttpGet]   
        public IActionResult Edit(int id)
        {
            var book = bookAppContext.Books.SingleOrDefault(n => n.BookId == id);
            return View(book);

        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                bookAppContext.Books.Update(book);
                bookAppContext.SaveChanges();
                return RedirectToAction("GetAllBooks");
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        { 
            var book=bookAppContext.Books.SingleOrDefault(n => n.BookId == id);
            return View(book);

        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            bookAppContext.Books.Remove(book);
            bookAppContext.SaveChanges();
            return RedirectToAction("GetAllBooks");
        }






    }
}
